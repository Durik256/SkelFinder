using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static SkelFinder.myBinaryReader;

namespace SkelFinder
{
    public partial class Form1 : Form
    {
        public static System.Windows.Forms.TextBox debugBox;
        Bone[] bones;
        public Form1()
        {
            InitializeComponent();
            debugBox = txtDebugBox;

            pic3D.MouseWheel += MyMouseWheel;

            selectedAll();
        }

        private void btnReadSkel_Click(object sender, EventArgs e)
        {
            debugBox.Text = "";
            string template = "";
            
            if (numericBones.Value <= 0)
            {
                debugBox.Text = "need indicate the number of bones";
                return;
            }

            if (ListMode)
            {
                if (listBoxTemp.Items.Count > 0)
                {
                    foreach (var item in listBoxTemp.Items)
                        template += item.ToString() + Environment.NewLine;
                }
                else
                {
                    debugBox.Text = "need template";
                    return;
                }
            }
            else
            {
                if (textBoxTemp.Text.Length > 0)
                    template = textBoxTemp.Text;
                else
                {
                    debugBox.Text = "need template";
                    return;
                }
            }

            if (string.IsNullOrEmpty(filePath))
            {
                debugBox.Text = "Please open file!";
                return;
            }

            if (!File.Exists(filePath))
            {
                debugBox.Text = "Wrong path file!";
                return;
            }

            int numBones = Convert.ToInt32(numericBones.Value);
            bones = new Bone[numBones];
            for (int i = 0; i < bones.Length; i++)
                bones[i] = new Bone();

            Endian endian = Endian.Little;
            
            if(checkBigE.Checked)
                endian = Endian.Big;

            using (myBinaryReader br = new myBinaryReader(File.OpenRead(filePath), Encoding.ASCII, endian))
            {
                bones = Parser.ParseTemplate(br, template, numBones, checkMultiply.Checked);
            }

            if (bones != null)
                SkelInit();
        }

        //---------------------------------3D_VIEW----------------------------------------
        #region
        Skel skel;

        int rX = 0;
        int rY = 0;

        void SkelInit()
        {
            rX = 0;
            rY = 0;

            skel = new Skel(bones);
            checkRenderName.Enabled = true;
            render();
        }

        void render()
        {
            if (skel == null)
                return;

            //Set the rotation values
            skel.RotateX = -rX;
            skel.RotateY = rY;

            Point origin = new Point(pic3D.Width / 2, pic3D.Height / 2);
            pic3D.Image = skel.drawSkel(origin);
        }

        void reset3Dview()
        {
            if (skel == null)
                return;

            rX = 0;
            rY = 0;
            
            skel.calcZcamera();
            render();
        }
        
        bool nFlags = false;
        int clickX, clickY;
        private void pic3D_MouseDown(object sender, MouseEventArgs e)
        {
            if (skel == null)
                return;

            Point point = new Point();
            point.X = e.X;
            point.Y = e.Y;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                nFlags = true;
                clickY = point.Y + rX;
                clickX = point.X + rY;
            }
            if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle)
            {
                reset3Dview();
            }
        }

        private void pic3D_MouseMove(object sender, MouseEventArgs e)
        {
            if (skel == null)
                return;
            
            Point point = new Point();
            point.X = e.X;
            point.Y = e.Y;

            if (nFlags && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                rX = (clickY - point.Y);
                rY = (clickX - point.X);
                render();
            }
        }

        private void MyMouseWheel(object sender, MouseEventArgs e)
        {
            if (skel != null)
            {
                skel.cameraZ(e.Delta);
                render();
            }
        }

        private void reset3D_Click(object sender, EventArgs e)
        {
            reset3Dview();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = pic3D.BackColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = MyDialog.Color;
                pic3D.BackColor = MyDialog.Color;
            }
        }

        private void checkRenderName_CheckedChanged(object sender, EventArgs e)
        {
            if (skel == null)
                return;

            skel.printName = checkRenderName.Checked;
            render();
        }

        private void pic3D_MouseUp(object sender, MouseEventArgs e)
        {
            if (skel == null)
                return;

            Point point = new Point();
            point.X = e.X;
            point.Y = e.Y;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                nFlags = false;
            }
        }
        #endregion

        //---------------------------------DEBUG------------------------------------------
        #region
        string fmt = "n2";
        private void btnClearDebug_Click(object sender, EventArgs e)
        {
            debugBox.Text = "";
        }

        private void btnPrintNames_Click(object sender, EventArgs e)
        {
            if (bones == null)
                return;

            debugBox.Text = "";

            for (int i = 0; i < bones.Length; i++)
                debugBox.Text += i + ": " + bones[i].Name + Environment.NewLine;
        }

        private void btnPrintPos_Click(object sender, EventArgs e)
        {
            if (bones == null)
                return;

            debugBox.Text = "";

            for (int i = 0; i < bones.Length; i++)
                debugBox.Text += $"{i}: ({bones[i].Matrix.M41.ToString(fmt)} {bones[i].Matrix.M42.ToString(fmt)} {bones[i].Matrix.M43.ToString(fmt)})"+ Environment.NewLine;
        }

        private void btnPrintParent_Click(object sender, EventArgs e)
        {
            if (bones == null)
                return;

            debugBox.Text = "";

            for (int i = 0; i < bones.Length; i++)
                debugBox.Text += $"{i} >> {bones[i].Parent};" + Environment.NewLine;
        }

        private void btnPrintMatrix_Click(object sender, EventArgs e)
        {
            if (bones == null)
                return;

            debugBox.Text = "";

            for (int i = 0; i < bones.Length; i++)
            {
                Matrix4x4 mats = bones[i].Matrix;
                debugBox.Text += i + ":" + Environment.NewLine +
                    "   (("+ mats.M11.ToString(fmt) + " " + mats.M12.ToString(fmt) + " " + mats.M13.ToString(fmt) + ")," + Environment.NewLine +
                    "   (" + mats.M21.ToString(fmt) + " " + mats.M22.ToString(fmt) + " " + mats.M23.ToString(fmt) + ")," + Environment.NewLine +
                    "   (" + mats.M31.ToString(fmt) + " " + mats.M32.ToString(fmt) + " " + mats.M33.ToString(fmt) + ")," + Environment.NewLine +
                    "   (" + mats.M41.ToString(fmt) + " " + mats.M42.ToString(fmt) + " " + mats.M43.ToString(fmt) + "))" + Environment.NewLine;
            }
        }
        #endregion

        //--------------------------------TEMPLATE----------------------------------------
        #region
        bool ListMode = true;
        private void btnClearTemp_Click(object sender, EventArgs e)
        {
            if (ListMode)
                listBoxTemp.Items.Clear();
            else
                textBoxTemp.Text = "";
        }

        private void btnDelSelCMD_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBoxTemp);
            selectedItems = listBoxTemp.SelectedItems;

            if (listBoxTemp.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBoxTemp.Items.Remove(selectedItems[i]);
            }
        }

        private void btnMoveSelUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(listBoxTemp, -1);
        }

        private void btnMoveSelDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(listBoxTemp, 1);
        }

        static void MoveSelectedItem(ListBox listBox, int direction)
        {
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
                return;

            int newIndex = listBox.SelectedIndex + direction;

            if (newIndex < 0 || newIndex >= listBox.Items.Count)
                return;

            object selected = listBox.SelectedItem;

            var checkedListBox = listBox as CheckedListBox;
            var checkState = CheckState.Unchecked;
            if (checkedListBox != null)
                checkState = checkedListBox.GetItemCheckState(checkedListBox.SelectedIndex);

            listBox.Items.Remove(selected);
            listBox.Items.Insert(newIndex, selected);
            listBox.SetSelected(newIndex, true);

            if (checkedListBox != null)
                checkedListBox.SetItemCheckState(newIndex, checkState);
        }
        #endregion
        
        //---------------------------------TOOLS------------------------------------------
        #region
        private void textBoxModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListMode = false;

            textBoxTemp.Visible = true;
            listBoxTemp.Visible = false;

            btnDelSelCMD.Enabled = false;
            btnMoveSelUp.Enabled = false;
            btnMoveSelDown.Enabled = false;
        }
       
        private void listBoxModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListMode = true;

            textBoxTemp.Visible = false;
            listBoxTemp.Visible = true;

            btnDelSelCMD.Enabled = true;
            btnMoveSelUp.Enabled = true;
            btnMoveSelDown.Enabled = true;
        }
        
        private void listTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ListMode)
            {
                listBoxTemp.Items.Clear();
                string[] lines = textBoxTemp.Text.Split('\n');
                foreach (string line in lines)
                    if(!string.IsNullOrEmpty(line))
                        listBoxTemp.Items.Add(line.Trim());
            }
            else
            {
                if (listBoxTemp.Items.Count > 0)
                {
                    foreach (var item in listBoxTemp.Items)
                    {
                        if (!textBoxTemp.Text.EndsWith(Environment.NewLine) && !string.IsNullOrEmpty(textBoxTemp.Text))
                            textBoxTemp.Text += Environment.NewLine;
                        
                        textBoxTemp.Text += item.ToString() + Environment.NewLine;
                    }
                }
            }
        }

        private void openTemptxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "temp|*.txt";
            openFileDialog1.Title = "Open temp File";
            
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string[] readText = File.ReadAllLines(openFileDialog1.FileName);
            string[] param = readText[0].Split(';');
            
            if (param[0] != "SF")
                return;

            checkBigE.Checked = false;
            if (param[1].Any(x => !char.IsLetter(x)))
            {
                if (Convert.ToInt32(param[1]) > 0)
                    checkBigE.Checked = true;
            }
            else
                checkBigE.Checked = Convert.ToBoolean(param[1]);

            checkMultiply.Checked = false;
            if (param[2].Any(x => !char.IsLetter(x)))
            {
                if (Convert.ToInt32(param[2]) > 0)
                    checkMultiply.Checked = true;
            }
            else
                checkMultiply.Checked = Convert.ToBoolean(param[2]);

            numericBones.Value = Convert.ToInt32(param[3]);

            if (ListMode)
            {
                listBoxTemp.Items.Clear();
                for (int i = 1; i < readText.Length; i++)
                {
                    if (!string.IsNullOrEmpty(readText[i]))
                        listBoxTemp.Items.Add(readText[i]);
                }
            }
            else
            {
                textBoxTemp.Text = "";
                for (int i = 1; i < readText.Length; i++)
                {
                    if (!string.IsNullOrEmpty(readText[i]))
                        textBoxTemp.Text += readText[i] + Environment.NewLine;
                }
            }
        }

        private void saveTemptxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "temp|*.txt";
            saveFileDialog1.Title = "Save temp File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
                return;

            string path = saveFileDialog1.FileName;
            using (var stream = new StreamWriter(path))
            {
                stream.WriteLine($"SF;{checkBigE.Checked};{checkMultiply.Checked};{numericBones.Value}");
                if (!ListMode)
                    stream.Write(textBoxTemp.Text);
                else
                {
                    if (listBoxTemp.Items.Count > 0)
                        foreach (var item in listBoxTemp.Items)
                            stream.WriteLine(item.ToString());
                }
            }
        }

        private void saveBMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveBMP();
        }
        private void githubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Durik256/SkelFinder");
        }
        private void topicOnForumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://forum.xentax.com/viewtopic.php?f=16&t=26004");
        }
        #endregion

        //---------------------------------FILE-------------------------------------------
        #region
        string filePath;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFile();
        }

        void openFile()
        {
            openFileDialog1.Filter = "";
            openFileDialog1.FileName = "Any Files with skeleton";
            openFileDialog1.Title = "Open File";

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                if (string.IsNullOrEmpty(filePath))
                    btnOpenFile.BackColor = Color.Red;
                return;
            }

            btnOpenFile.BackColor = Color.Green;
            filePath = openFileDialog1.FileName;
        }

        void WriteSkelFinder()
        {
            if (bones == null)
                return;

            saveFileDialog1.Filter = "skel|*.skelFinder";
            saveFileDialog1.Title = "Save as Skel File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
                return;

            using (var stream = File.Open(saveFileDialog1.FileName, FileMode.Create))
            {
                using (BinaryWriter skl = new BinaryWriter(stream))
                {
                    skl.Write(new char[] { 'S', 'K', 'E', 'L' });
                    skl.Write(bones.Length);
                    for (int i = 0; i < bones.Length; i++)
                    {
                        skl.Write(bones[i].Name.Length);
                        skl.Write(bones[i].Name.ToCharArray());
                        skl.Write(bones[i].Matrix.M11);
                        skl.Write(bones[i].Matrix.M12);
                        skl.Write(bones[i].Matrix.M13);
                        skl.Write(bones[i].Matrix.M21);
                        skl.Write(bones[i].Matrix.M22);
                        skl.Write(bones[i].Matrix.M23);
                        skl.Write(bones[i].Matrix.M31);
                        skl.Write(bones[i].Matrix.M32);
                        skl.Write(bones[i].Matrix.M33);
                        skl.Write(bones[i].Matrix.M41);
                        skl.Write(bones[i].Matrix.M42);
                        skl.Write(bones[i].Matrix.M43);
                        skl.Write(bones[i].Parent);
                    }
                }
            }
        }

        public void WriteSkelFinderASCII()
        {
            if (bones == null)
                return;

            saveFileDialog1.Filter = "skel|*.SFascii";
            saveFileDialog1.Title = "Save as Skel File ascii";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
                return;

            using (StreamWriter obj = new StreamWriter(saveFileDialog1.FileName))
            {
                obj.WriteLine("#SF");
                obj.WriteLine($"bones {bones.Length}");
                for (int i = 0; i < bones.Length; i++)
                {
                    obj.WriteLine($"{i} {bones[i].Name} {bones[i].Parent}");
                }

                obj.WriteLine($"matrix {bones.Length}");
                for (int i = 0; i < bones.Length; i++)
                {
                    obj.WriteLine($"{i} {bones[i].Matrix.M11} {bones[i].Matrix.M12} {bones[i].Matrix.M13} {bones[i].Matrix.M21} {bones[i].Matrix.M22} {bones[i].Matrix.M23} {bones[i].Matrix.M31} {bones[i].Matrix.M32} {bones[i].Matrix.M33} {bones[i].Matrix.M41} {bones[i].Matrix.M42} {bones[i].Matrix.M43}");
                }
            }
        }
        private void sFskelFinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteSkelFinder();
        }

        private void sFSFasciiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WriteSkelFinderASCII();
        }


        private void colladasmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bones == null)
                return;

            saveFileDialog1.Filter = "collada|*.dae";
            saveFileDialog1.Title = "Save as Collada DAE";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
                return;

            using (StreamWriter obj = new StreamWriter(saveFileDialog1.FileName))
            {
                myDAE.writeDAE(bones, obj);
            }
        }

        private void valvesmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bones == null)
                return;

            saveFileDialog1.Filter = "valve|*.smd";
            saveFileDialog1.Title = "Save as valve SMD";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
                return;

            using (StreamWriter obj = new StreamWriter(saveFileDialog1.FileName))
            {
                mySMD.writeSMD(bones, obj);
            }
        }

        void saveBMP()
        {
            Bitmap bmp = new Bitmap(pic3D.Width, pic3D.Height);
            pic3D.DrawToBitmap(bmp, pic3D.ClientRectangle);
            bmp.Save(Directory.GetCurrentDirectory() + "\\testBmp.bmp", ImageFormat.Bmp);
        }
        #endregion

        //-------------------------------COMMANDS-----------------------------------------
        #region
        void AddCMD(string cmd)
        {
            if (ListMode)
                listBoxTemp.Items.Add(cmd.ToLower());
            else
                textBoxTemp.Text += cmd.ToLower();//need chek new line
        }

        void ReplaceCMD(string cmd)
        {
            if (listBoxTemp.SelectedIndex != -1)
                listBoxTemp.Items[listBoxTemp.SelectedIndex] = cmd.ToLower();
        }
        string cmdName()
        {
            if (typeName.SelectedIndex == 0)
                return $"name[{numericName.Value}]";
            else
                return $"name[0,{typeName.Text}" + (!checkNameZero.Checked ? ",false]" : "]");
        }

        List<string> paramRotation = new List<string>();
        string cmdRotation()
        {
            string cmd = $"{formatRotation.Text}[{typeRotation.Text}";
            if (formatRotation.SelectedIndex > 2)
                cmd += $",{formatEuler.Text}";
            else
                if (paramRotation.Count > 0)
                    cmd += "," + string.Join(",", paramRotation);
            return cmd+"]";
        }

        string cmdPosition()
        {
            return $"pos[{typePosition.Text}]";
        }

        string cmdParent()
        {
            if (typeParent.SelectedIndex != 4)// not string
                return $"parent[{typeParent.Text}]";
            else// as string
            {
                if (typeNameParent.SelectedIndex == 0)
                    return $"parent[0,{numericParent.Value}]";
                else
                    return $"parent[0,0,{typeNameParent.Text}" + (!checkParentZero.Checked ? ",false]" : "]");
            }
        }
        string cmdStringSeek()
        {
            if (typeName.SelectedIndex == 0)
                return $"{numericName.Value}";
            else
                return $"0;{typeName.Text}" + (!checkNameZero.Checked ? ";false" : "");
        }
        string cmdSeek()
        {
            if (typeSeek.SelectedIndex == 0)
                return $"seek[{numericSeek.Value}]";
            else
            {
                //
                //return $"seek[0,{typeSeek.Text}" + (checkSeekMul.Checked ? $",{numericSeekMul.Value}]" : "]");
                if(checkSeekMul.Checked)
                    return $"seek[0,{typeSeek.Text},{numericSeekMul.Value}]";
                else if(checkBoxSkipFixed.Checked)
                    return $"seek[0,{typeSeek.Text},#,{cmdStringSeek()}]";
                else
                    return $"seek[0,{typeSeek.Text}]";
            }
        }

        string cmdOffset()
        {
            return $"offset[{numericOffset.Value}]";
        }
        #endregion

        //--------------------------------OTHER_UI----------------------------------------
        #region
        private void typeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkNameZero.Enabled = false;
            numericName.Enabled = false;
            if (typeName.SelectedIndex != 0)
                checkNameZero.Enabled = true;
            else
                numericName.Enabled = true;
        }

        private void formatRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            typeRotation.Items.Clear();
            typeRotation.Items.AddRange(new string[] { "FLOAT", "HALF", "SHORT", "BYTE" });

            chekRotation1.Visible = true;
            chekRotation2.Visible = true;
            formatEuler.Visible = false;

            chekRotation2.Text = "inverse";
            //paramRotation = paramRotation.Replace("NORM", "INV");
            if (formatRotation.SelectedIndex == 2)
            {
                chekRotation2.Text = "normalize";
                //paramRotation = paramRotation.Replace("INV", "NORM");
            }

            if (formatRotation.SelectedIndex > 2)
            {
                chekRotation1.Visible = false;
                chekRotation2.Visible = false;
                formatEuler.Visible = true;
                if (formatRotation.SelectedIndex == 4)
                {
                    typeRotation.Items.Clear();
                    typeRotation.Items.AddRange(new string[] { "INT32", "INT24", "INT16", "INT8", "FLOAT", "HALF" });
                }
            }

            typeRotation.SelectedIndex = 0;
        }

        private void chekRotation1_CheckedChanged(object sender, EventArgs e)
        {
            if (chekRotation1.Checked)//transpose
            {
                if (!paramRotation.Contains("trans"))
                    paramRotation.Add("trans");
            }
            else
                paramRotation.Remove("trans");
        }

        private void chekRotation2_CheckedChanged(object sender, EventArgs e)
        {
            if (chekRotation2.Checked)//inverse|normalize
            {
                if (formatRotation.SelectedIndex != 2)
                {
                    if (!paramRotation.Contains("inv") && !paramRotation.Contains("norm"))
                        paramRotation.Add("inv");
                    else
                    {
                        if (paramRotation.Contains("norm"))
                            paramRotation[paramRotation.IndexOf("norm")] = "inv";
                    }
                }
                else
                {
                    if (!paramRotation.Contains("inv") && !paramRotation.Contains("norm"))
                        paramRotation.Add("norm");
                    else
                    {
                        if (paramRotation.Contains("inv"))
                            paramRotation[paramRotation.IndexOf("inv")] = "norm";
                    }
                }
            }
            else
            {
                paramRotation.Remove("inv");
                paramRotation.Remove("norm");
            }    
        }

        private void typeParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericParent.Enabled = false;
            typeNameParent.Enabled = false;
            checkParentZero.Enabled = false;
            if(typeParent.SelectedIndex == 4)
            {
                typeNameParent.Enabled = true;
                if (typeNameParent.SelectedIndex != 0)
                    checkParentZero.Enabled = true;
                else
                    numericParent.Enabled = true;
            }
        }
        
        private void typeNameParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericParent.Enabled = false;
            checkParentZero.Enabled = false;
            if (typeNameParent.SelectedIndex != 0)
                checkParentZero.Enabled = true;
            else
                if (typeParent.SelectedIndex == 4)
                    numericParent.Enabled = true;

        }

        private void typeSeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkSeekMul.Enabled = false;
            numericSeekMul.Enabled = false;

            textBoxSkipAsName.Enabled = false;
            checkSeekMul.Enabled = false;
            checkBoxSkipFixed.Enabled = false;

            if (typeSeek.SelectedIndex != 0)
            {
                checkSeekMul.Enabled = true;
                checkBoxSkipFixed.Enabled = true;
                if (checkSeekMul.Checked)
                    numericSeekMul.Enabled = true;
                if (checkBoxSkipFixed.Checked)
                    textBoxSkipAsName.Enabled = true;

            }
        }
        
        private void checkSeekMul_CheckedChanged(object sender, EventArgs e)
        {
            numericSeekMul.Enabled = checkSeekMul.Checked;
            if (checkSeekMul.Checked)
                if (checkBoxSkipFixed.Checked)
                    checkBoxSkipFixed.Checked = false;
        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            AddCMD(cmdName());
        }

        private void btnReplaceName_Click(object sender, EventArgs e)
        {
            ReplaceCMD(cmdName());
        }

        private void btnAddRotation_Click(object sender, EventArgs e)
        {
            AddCMD(cmdRotation());
        }

        private void btnReplaceRotation_Click(object sender, EventArgs e)
        {
            ReplaceCMD(cmdRotation());
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            AddCMD(cmdPosition());
        }

        private void btnReplacePosition_Click(object sender, EventArgs e)
        {
            ReplaceCMD(cmdPosition());
        }

        private void btnAddParent_Click(object sender, EventArgs e)
        {
            AddCMD(cmdParent());
        }

        private void btnReplaceParent_Click(object sender, EventArgs e)
        {
            ReplaceCMD(cmdParent());
        }

        private void btnAddSeek_Click(object sender, EventArgs e)
        {
            AddCMD(cmdSeek());
        }

        private void btnReplaceSeek_Click(object sender, EventArgs e)
        {
            ReplaceCMD(cmdSeek());
        }

        private void btnAddOffset_Click(object sender, EventArgs e)
        {
            AddCMD(cmdOffset());
        }

        private void btnReplaceOffset_Click(object sender, EventArgs e)
        {
            ReplaceCMD(cmdOffset());
        }

        private void numericDebug_ValueChanged(object sender, EventArgs e)
        {
            fmt = $"n{numericDebug.Value}";
        }

        private void checkBoxSkipFixed_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSkipAsName.Visible = checkBoxSkipFixed.Checked;
            textBoxSkipAsName.Enabled = checkBoxSkipFixed.Checked;
            if (checkBoxSkipFixed.Checked)
                if (checkSeekMul.Checked)
                    checkSeekMul.Checked = false;
        }

        void selectedAll()
        {
            typeName.SelectedIndex = 0;
            formatRotation.SelectedIndex = 0;
            typeRotation.SelectedIndex = 0;
            typePosition.SelectedIndex = 0;
            formatEuler.SelectedIndex = 0;
            typeParent.SelectedIndex = 0;
            typeNameParent.SelectedIndex = 0;
            typeSeek.SelectedIndex = 0;
        }
        #endregion
    }
}
