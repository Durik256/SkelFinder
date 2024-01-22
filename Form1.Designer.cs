namespace SkelFinder
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReadSkel = new System.Windows.Forms.Button();
            this.pic3D = new System.Windows.Forms.PictureBox();
            this.reset3D = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.checkRenderName = new System.Windows.Forms.CheckBox();
            this.txtDebugBox = new System.Windows.Forms.TextBox();
            this.btnClearDebug = new System.Windows.Forms.Button();
            this.btnPrintMatrix = new System.Windows.Forms.Button();
            this.btnPrintNames = new System.Windows.Forms.Button();
            this.btnPrintPos = new System.Windows.Forms.Button();
            this.btnPrintParent = new System.Windows.Forms.Button();
            this.btnClearTemp = new System.Windows.Forms.Button();
            this.btnDelSelCMD = new System.Windows.Forms.Button();
            this.listBoxTemp = new System.Windows.Forms.ListBox();
            this.textBoxTemp = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sFskelFinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sFSFasciiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colladasmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valvesmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tollsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemptxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTemptxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBMPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicOnForumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMoveSelUp = new System.Windows.Forms.Button();
            this.btnMoveSelDown = new System.Windows.Forms.Button();
            this.checkBigE = new System.Windows.Forms.CheckBox();
            this.checkMultiply = new System.Windows.Forms.CheckBox();
            this.numericBones = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnAddOffset = new System.Windows.Forms.Button();
            this.btnReplaceOffset = new System.Windows.Forms.Button();
            this.tabCMD = new System.Windows.Forms.TabControl();
            this.tabName = new System.Windows.Forms.TabPage();
            this.btnAddName = new System.Windows.Forms.Button();
            this.btnReplaceName = new System.Windows.Forms.Button();
            this.checkNameZero = new System.Windows.Forms.CheckBox();
            this.typeName = new System.Windows.Forms.ComboBox();
            this.numericName = new System.Windows.Forms.NumericUpDown();
            this.tabRotation = new System.Windows.Forms.TabPage();
            this.btnAddRotation = new System.Windows.Forms.Button();
            this.chekRotation1 = new System.Windows.Forms.CheckBox();
            this.chekRotation2 = new System.Windows.Forms.CheckBox();
            this.btnReplaceRotation = new System.Windows.Forms.Button();
            this.typeRotation = new System.Windows.Forms.ComboBox();
            this.formatRotation = new System.Windows.Forms.ComboBox();
            this.formatEuler = new System.Windows.Forms.ComboBox();
            this.tabPosition = new System.Windows.Forms.TabPage();
            this.btnAddPosition = new System.Windows.Forms.Button();
            this.typePosition = new System.Windows.Forms.ComboBox();
            this.btnReplacePosition = new System.Windows.Forms.Button();
            this.tabParent = new System.Windows.Forms.TabPage();
            this.btnAddParent = new System.Windows.Forms.Button();
            this.checkParentZero = new System.Windows.Forms.CheckBox();
            this.typeNameParent = new System.Windows.Forms.ComboBox();
            this.btnReplaceParent = new System.Windows.Forms.Button();
            this.typeParent = new System.Windows.Forms.ComboBox();
            this.numericParent = new System.Windows.Forms.NumericUpDown();
            this.tabSeek = new System.Windows.Forms.TabPage();
            this.textBoxSkipAsName = new System.Windows.Forms.TextBox();
            this.checkBoxSkipFixed = new System.Windows.Forms.CheckBox();
            this.btnAddSeek = new System.Windows.Forms.Button();
            this.checkSeekMul = new System.Windows.Forms.CheckBox();
            this.btnReplaceSeek = new System.Windows.Forms.Button();
            this.typeSeek = new System.Windows.Forms.ComboBox();
            this.numericSeek = new System.Windows.Forms.NumericUpDown();
            this.numericSeekMul = new System.Windows.Forms.NumericUpDown();
            this.tabOffset = new System.Windows.Forms.TabPage();
            this.numericOffset = new System.Windows.Forms.NumericUpDown();
            this.numericDebug = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pic3D)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBones)).BeginInit();
            this.tabCMD.SuspendLayout();
            this.tabName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericName)).BeginInit();
            this.tabRotation.SuspendLayout();
            this.tabPosition.SuspendLayout();
            this.tabParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericParent)).BeginInit();
            this.tabSeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeekMul)).BeginInit();
            this.tabOffset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDebug)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadSkel
            // 
            this.btnReadSkel.Location = new System.Drawing.Point(244, 211);
            this.btnReadSkel.Name = "btnReadSkel";
            this.btnReadSkel.Size = new System.Drawing.Size(72, 23);
            this.btnReadSkel.TabIndex = 0;
            this.btnReadSkel.Text = "run";
            this.btnReadSkel.UseVisualStyleBackColor = true;
            this.btnReadSkel.Click += new System.EventHandler(this.btnReadSkel_Click);
            // 
            // pic3D
            // 
            this.pic3D.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pic3D.Location = new System.Drawing.Point(346, 33);
            this.pic3D.Name = "pic3D";
            this.pic3D.Size = new System.Drawing.Size(300, 300);
            this.pic3D.TabIndex = 1;
            this.pic3D.TabStop = false;
            this.pic3D.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic3D_MouseDown);
            this.pic3D.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic3D_MouseMove);
            this.pic3D.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic3D_MouseUp);
            // 
            // reset3D
            // 
            this.reset3D.Location = new System.Drawing.Point(571, 340);
            this.reset3D.Name = "reset3D";
            this.reset3D.Size = new System.Drawing.Size(75, 23);
            this.reset3D.TabIndex = 2;
            this.reset3D.Text = "reset";
            this.reset3D.UseVisualStyleBackColor = true;
            this.reset3D.Click += new System.EventHandler(this.reset3D_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnColor.Location = new System.Drawing.Point(488, 340);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 3;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // checkRenderName
            // 
            this.checkRenderName.AutoSize = true;
            this.checkRenderName.Enabled = false;
            this.checkRenderName.Location = new System.Drawing.Point(346, 339);
            this.checkRenderName.Name = "checkRenderName";
            this.checkRenderName.Size = new System.Drawing.Size(108, 20);
            this.checkRenderName.TabIndex = 4;
            this.checkRenderName.Text = "render Name";
            this.checkRenderName.UseVisualStyleBackColor = true;
            this.checkRenderName.CheckedChanged += new System.EventHandler(this.checkRenderName_CheckedChanged);
            // 
            // txtDebugBox
            // 
            this.txtDebugBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDebugBox.Location = new System.Drawing.Point(12, 240);
            this.txtDebugBox.Multiline = true;
            this.txtDebugBox.Name = "txtDebugBox";
            this.txtDebugBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDebugBox.Size = new System.Drawing.Size(328, 93);
            this.txtDebugBox.TabIndex = 5;
            this.txtDebugBox.WordWrap = false;
            // 
            // btnClearDebug
            // 
            this.btnClearDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearDebug.Location = new System.Drawing.Point(12, 339);
            this.btnClearDebug.Name = "btnClearDebug";
            this.btnClearDebug.Size = new System.Drawing.Size(49, 24);
            this.btnClearDebug.TabIndex = 6;
            this.btnClearDebug.Text = "clr";
            this.btnClearDebug.UseVisualStyleBackColor = true;
            this.btnClearDebug.Click += new System.EventHandler(this.btnClearDebug_Click);
            // 
            // btnPrintMatrix
            // 
            this.btnPrintMatrix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintMatrix.Location = new System.Drawing.Point(67, 339);
            this.btnPrintMatrix.Name = "btnPrintMatrix";
            this.btnPrintMatrix.Size = new System.Drawing.Size(72, 23);
            this.btnPrintMatrix.TabIndex = 7;
            this.btnPrintMatrix.Text = "matrix";
            this.btnPrintMatrix.UseVisualStyleBackColor = true;
            this.btnPrintMatrix.Click += new System.EventHandler(this.btnPrintMatrix_Click);
            // 
            // btnPrintNames
            // 
            this.btnPrintNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintNames.Location = new System.Drawing.Point(145, 339);
            this.btnPrintNames.Name = "btnPrintNames";
            this.btnPrintNames.Size = new System.Drawing.Size(65, 23);
            this.btnPrintNames.TabIndex = 8;
            this.btnPrintNames.Text = "name";
            this.btnPrintNames.UseVisualStyleBackColor = true;
            this.btnPrintNames.Click += new System.EventHandler(this.btnPrintNames_Click);
            // 
            // btnPrintPos
            // 
            this.btnPrintPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintPos.Location = new System.Drawing.Point(216, 339);
            this.btnPrintPos.Name = "btnPrintPos";
            this.btnPrintPos.Size = new System.Drawing.Size(63, 23);
            this.btnPrintPos.TabIndex = 9;
            this.btnPrintPos.Text = "pos";
            this.btnPrintPos.UseVisualStyleBackColor = true;
            this.btnPrintPos.Click += new System.EventHandler(this.btnPrintPos_Click);
            // 
            // btnPrintParent
            // 
            this.btnPrintParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintParent.Location = new System.Drawing.Point(285, 339);
            this.btnPrintParent.Name = "btnPrintParent";
            this.btnPrintParent.Size = new System.Drawing.Size(55, 23);
            this.btnPrintParent.TabIndex = 10;
            this.btnPrintParent.Text = "prnt";
            this.btnPrintParent.UseVisualStyleBackColor = true;
            this.btnPrintParent.Click += new System.EventHandler(this.btnPrintParent_Click);
            // 
            // btnClearTemp
            // 
            this.btnClearTemp.Location = new System.Drawing.Point(119, 211);
            this.btnClearTemp.Name = "btnClearTemp";
            this.btnClearTemp.Size = new System.Drawing.Size(43, 23);
            this.btnClearTemp.TabIndex = 11;
            this.btnClearTemp.Text = "clr";
            this.btnClearTemp.UseVisualStyleBackColor = true;
            this.btnClearTemp.Click += new System.EventHandler(this.btnClearTemp_Click);
            // 
            // btnDelSelCMD
            // 
            this.btnDelSelCMD.Location = new System.Drawing.Point(168, 211);
            this.btnDelSelCMD.Name = "btnDelSelCMD";
            this.btnDelSelCMD.Size = new System.Drawing.Size(43, 23);
            this.btnDelSelCMD.TabIndex = 12;
            this.btnDelSelCMD.Text = "dlt";
            this.btnDelSelCMD.UseVisualStyleBackColor = true;
            this.btnDelSelCMD.Click += new System.EventHandler(this.btnDelSelCMD_Click);
            // 
            // listBoxTemp
            // 
            this.listBoxTemp.FormattingEnabled = true;
            this.listBoxTemp.ItemHeight = 16;
            this.listBoxTemp.Location = new System.Drawing.Point(119, 57);
            this.listBoxTemp.Name = "listBoxTemp";
            this.listBoxTemp.Size = new System.Drawing.Size(197, 148);
            this.listBoxTemp.TabIndex = 13;
            // 
            // textBoxTemp
            // 
            this.textBoxTemp.Location = new System.Drawing.Point(119, 57);
            this.textBoxTemp.Multiline = true;
            this.textBoxTemp.Name = "textBoxTemp";
            this.textBoxTemp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTemp.Size = new System.Drawing.Size(197, 148);
            this.textBoxTemp.TabIndex = 14;
            this.textBoxTemp.Visible = false;
            this.textBoxTemp.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tollsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(655, 28);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sFskelFinderToolStripMenuItem,
            this.sFSFasciiToolStripMenuItem,
            this.colladasmdToolStripMenuItem,
            this.valvesmdToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // sFskelFinderToolStripMenuItem
            // 
            this.sFskelFinderToolStripMenuItem.Name = "sFskelFinderToolStripMenuItem";
            this.sFskelFinderToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.sFskelFinderToolStripMenuItem.Text = "SF (.skelFinder)";
            this.sFskelFinderToolStripMenuItem.Click += new System.EventHandler(this.sFskelFinderToolStripMenuItem_Click);
            // 
            // sFSFasciiToolStripMenuItem
            // 
            this.sFSFasciiToolStripMenuItem.Name = "sFSFasciiToolStripMenuItem";
            this.sFSFasciiToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.sFSFasciiToolStripMenuItem.Text = "SF (.SFascii)";
            this.sFSFasciiToolStripMenuItem.Click += new System.EventHandler(this.sFSFasciiToolStripMenuItem_Click);
            // 
            // colladasmdToolStripMenuItem
            // 
            this.colladasmdToolStripMenuItem.Name = "colladasmdToolStripMenuItem";
            this.colladasmdToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.colladasmdToolStripMenuItem.Text = "Collada (.dae)";
            this.colladasmdToolStripMenuItem.Click += new System.EventHandler(this.colladasmdToolStripMenuItem_Click);
            // 
            // valvesmdToolStripMenuItem
            // 
            this.valvesmdToolStripMenuItem.Name = "valvesmdToolStripMenuItem";
            this.valvesmdToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.valvesmdToolStripMenuItem.Text = "Valve (.smd)";
            this.valvesmdToolStripMenuItem.Click += new System.EventHandler(this.valvesmdToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tollsToolStripMenuItem
            // 
            this.tollsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBoxModeToolStripMenuItem,
            this.listBoxModeToolStripMenuItem,
            this.listTextToolStripMenuItem,
            this.openTemptxtToolStripMenuItem,
            this.saveTemptxtToolStripMenuItem,
            this.saveBMPToolStripMenuItem});
            this.tollsToolStripMenuItem.Name = "tollsToolStripMenuItem";
            this.tollsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.tollsToolStripMenuItem.Text = "Tools";
            // 
            // textBoxModeToolStripMenuItem
            // 
            this.textBoxModeToolStripMenuItem.Name = "textBoxModeToolStripMenuItem";
            this.textBoxModeToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.textBoxModeToolStripMenuItem.Text = "TextBox Mode";
            this.textBoxModeToolStripMenuItem.Click += new System.EventHandler(this.textBoxModeToolStripMenuItem_Click);
            // 
            // listBoxModeToolStripMenuItem
            // 
            this.listBoxModeToolStripMenuItem.Name = "listBoxModeToolStripMenuItem";
            this.listBoxModeToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.listBoxModeToolStripMenuItem.Text = "ListBox Mode";
            this.listBoxModeToolStripMenuItem.Click += new System.EventHandler(this.listBoxModeToolStripMenuItem_Click);
            // 
            // listTextToolStripMenuItem
            // 
            this.listTextToolStripMenuItem.Name = "listTextToolStripMenuItem";
            this.listTextToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.listTextToolStripMenuItem.Text = "list <-> text";
            this.listTextToolStripMenuItem.Click += new System.EventHandler(this.listTextToolStripMenuItem_Click);
            // 
            // openTemptxtToolStripMenuItem
            // 
            this.openTemptxtToolStripMenuItem.Name = "openTemptxtToolStripMenuItem";
            this.openTemptxtToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.openTemptxtToolStripMenuItem.Text = "open temp.txt";
            this.openTemptxtToolStripMenuItem.Click += new System.EventHandler(this.openTemptxtToolStripMenuItem_Click);
            // 
            // saveTemptxtToolStripMenuItem
            // 
            this.saveTemptxtToolStripMenuItem.Name = "saveTemptxtToolStripMenuItem";
            this.saveTemptxtToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.saveTemptxtToolStripMenuItem.Text = "save temp.txt";
            this.saveTemptxtToolStripMenuItem.Click += new System.EventHandler(this.saveTemptxtToolStripMenuItem_Click);
            // 
            // saveBMPToolStripMenuItem
            // 
            this.saveBMPToolStripMenuItem.Name = "saveBMPToolStripMenuItem";
            this.saveBMPToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.saveBMPToolStripMenuItem.Text = "save BMP";
            this.saveBMPToolStripMenuItem.Click += new System.EventHandler(this.saveBMPToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topicOnForumToolStripMenuItem,
            this.githubToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // topicOnForumToolStripMenuItem
            // 
            this.topicOnForumToolStripMenuItem.Name = "topicOnForumToolStripMenuItem";
            this.topicOnForumToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.topicOnForumToolStripMenuItem.Text = "topic on Forum";
            this.topicOnForumToolStripMenuItem.Click += new System.EventHandler(this.topicOnForumToolStripMenuItem_Click);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.githubToolStripMenuItem.Text = "github";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.githubToolStripMenuItem_Click);
            // 
            // btnMoveSelUp
            // 
            this.btnMoveSelUp.Location = new System.Drawing.Point(322, 58);
            this.btnMoveSelUp.Name = "btnMoveSelUp";
            this.btnMoveSelUp.Size = new System.Drawing.Size(18, 70);
            this.btnMoveSelUp.TabIndex = 16;
            this.btnMoveSelUp.Text = "↑";
            this.btnMoveSelUp.UseVisualStyleBackColor = true;
            this.btnMoveSelUp.Click += new System.EventHandler(this.btnMoveSelUp_Click);
            // 
            // btnMoveSelDown
            // 
            this.btnMoveSelDown.Location = new System.Drawing.Point(322, 135);
            this.btnMoveSelDown.Name = "btnMoveSelDown";
            this.btnMoveSelDown.Size = new System.Drawing.Size(18, 70);
            this.btnMoveSelDown.TabIndex = 17;
            this.btnMoveSelDown.Text = "↓";
            this.btnMoveSelDown.UseVisualStyleBackColor = true;
            this.btnMoveSelDown.Click += new System.EventHandler(this.btnMoveSelDown_Click);
            // 
            // checkBigE
            // 
            this.checkBigE.AutoSize = true;
            this.checkBigE.Location = new System.Drawing.Point(123, 35);
            this.checkBigE.Name = "checkBigE";
            this.checkBigE.Size = new System.Drawing.Size(57, 20);
            this.checkBigE.TabIndex = 18;
            this.checkBigE.Text = "bigE";
            this.checkBigE.UseVisualStyleBackColor = true;
            // 
            // checkMultiply
            // 
            this.checkMultiply.AutoSize = true;
            this.checkMultiply.Location = new System.Drawing.Point(186, 35);
            this.checkMultiply.Name = "checkMultiply";
            this.checkMultiply.Size = new System.Drawing.Size(64, 20);
            this.checkMultiply.TabIndex = 19;
            this.checkMultiply.Text = "mltply";
            this.checkMultiply.UseVisualStyleBackColor = true;
            // 
            // numericBones
            // 
            this.numericBones.Location = new System.Drawing.Point(258, 33);
            this.numericBones.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericBones.Name = "numericBones";
            this.numericBones.Size = new System.Drawing.Size(58, 22);
            this.numericBones.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackColor = System.Drawing.Color.Red;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.8F);
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOpenFile.Location = new System.Drawing.Point(322, 33);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(18, 22);
            this.btnOpenFile.TabIndex = 21;
            this.btnOpenFile.Text = "File";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnAddOffset
            // 
            this.btnAddOffset.Location = new System.Drawing.Point(6, 118);
            this.btnAddOffset.Name = "btnAddOffset";
            this.btnAddOffset.Size = new System.Drawing.Size(60, 23);
            this.btnAddOffset.TabIndex = 22;
            this.btnAddOffset.Text = "Add";
            this.btnAddOffset.UseVisualStyleBackColor = true;
            this.btnAddOffset.Click += new System.EventHandler(this.btnAddOffset_Click);
            // 
            // btnReplaceOffset
            // 
            this.btnReplaceOffset.Location = new System.Drawing.Point(67, 118);
            this.btnReplaceOffset.Name = "btnReplaceOffset";
            this.btnReplaceOffset.Size = new System.Drawing.Size(22, 23);
            this.btnReplaceOffset.TabIndex = 23;
            this.btnReplaceOffset.Text = "R";
            this.btnReplaceOffset.UseVisualStyleBackColor = true;
            this.btnReplaceOffset.Click += new System.EventHandler(this.btnReplaceOffset_Click);
            // 
            // tabCMD
            // 
            this.tabCMD.Controls.Add(this.tabName);
            this.tabCMD.Controls.Add(this.tabRotation);
            this.tabCMD.Controls.Add(this.tabPosition);
            this.tabCMD.Controls.Add(this.tabParent);
            this.tabCMD.Controls.Add(this.tabSeek);
            this.tabCMD.Controls.Add(this.tabOffset);
            this.tabCMD.Location = new System.Drawing.Point(12, 33);
            this.tabCMD.Name = "tabCMD";
            this.tabCMD.SelectedIndex = 0;
            this.tabCMD.Size = new System.Drawing.Size(105, 176);
            this.tabCMD.TabIndex = 24;
            // 
            // tabName
            // 
            this.tabName.BackColor = System.Drawing.SystemColors.Control;
            this.tabName.Controls.Add(this.btnAddName);
            this.tabName.Controls.Add(this.btnReplaceName);
            this.tabName.Controls.Add(this.checkNameZero);
            this.tabName.Controls.Add(this.typeName);
            this.tabName.Controls.Add(this.numericName);
            this.tabName.Location = new System.Drawing.Point(4, 25);
            this.tabName.Name = "tabName";
            this.tabName.Padding = new System.Windows.Forms.Padding(3);
            this.tabName.Size = new System.Drawing.Size(97, 147);
            this.tabName.TabIndex = 0;
            this.tabName.Text = "name";
            // 
            // btnAddName
            // 
            this.btnAddName.Location = new System.Drawing.Point(6, 118);
            this.btnAddName.Name = "btnAddName";
            this.btnAddName.Size = new System.Drawing.Size(60, 23);
            this.btnAddName.TabIndex = 29;
            this.btnAddName.Text = "Add";
            this.btnAddName.UseVisualStyleBackColor = true;
            this.btnAddName.Click += new System.EventHandler(this.btnAddName_Click);
            // 
            // btnReplaceName
            // 
            this.btnReplaceName.Location = new System.Drawing.Point(67, 118);
            this.btnReplaceName.Name = "btnReplaceName";
            this.btnReplaceName.Size = new System.Drawing.Size(22, 23);
            this.btnReplaceName.TabIndex = 30;
            this.btnReplaceName.Text = "R";
            this.btnReplaceName.UseVisualStyleBackColor = true;
            this.btnReplaceName.Click += new System.EventHandler(this.btnReplaceName_Click);
            // 
            // checkNameZero
            // 
            this.checkNameZero.AutoSize = true;
            this.checkNameZero.Location = new System.Drawing.Point(6, 64);
            this.checkNameZero.Name = "checkNameZero";
            this.checkNameZero.Size = new System.Drawing.Size(53, 20);
            this.checkNameZero.TabIndex = 28;
            this.checkNameZero.Text = "\\x00";
            this.checkNameZero.UseVisualStyleBackColor = true;
            // 
            // typeName
            // 
            this.typeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeName.FormattingEnabled = true;
            this.typeName.Items.AddRange(new object[] {
            "FIXED",
            "INT32",
            "INT24",
            "INT16",
            "INT8",
            "TO ZERO"});
            this.typeName.Location = new System.Drawing.Point(6, 34);
            this.typeName.Name = "typeName";
            this.typeName.Size = new System.Drawing.Size(83, 24);
            this.typeName.TabIndex = 28;
            this.typeName.SelectedIndexChanged += new System.EventHandler(this.typeName_SelectedIndexChanged);
            // 
            // numericName
            // 
            this.numericName.Location = new System.Drawing.Point(6, 6);
            this.numericName.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericName.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericName.Name = "numericName";
            this.numericName.Size = new System.Drawing.Size(83, 22);
            this.numericName.TabIndex = 28;
            // 
            // tabRotation
            // 
            this.tabRotation.BackColor = System.Drawing.SystemColors.Control;
            this.tabRotation.Controls.Add(this.btnAddRotation);
            this.tabRotation.Controls.Add(this.chekRotation1);
            this.tabRotation.Controls.Add(this.chekRotation2);
            this.tabRotation.Controls.Add(this.btnReplaceRotation);
            this.tabRotation.Controls.Add(this.typeRotation);
            this.tabRotation.Controls.Add(this.formatRotation);
            this.tabRotation.Controls.Add(this.formatEuler);
            this.tabRotation.Location = new System.Drawing.Point(4, 25);
            this.tabRotation.Name = "tabRotation";
            this.tabRotation.Padding = new System.Windows.Forms.Padding(3);
            this.tabRotation.Size = new System.Drawing.Size(97, 147);
            this.tabRotation.TabIndex = 1;
            this.tabRotation.Text = "rotation";
            // 
            // btnAddRotation
            // 
            this.btnAddRotation.Location = new System.Drawing.Point(6, 118);
            this.btnAddRotation.Name = "btnAddRotation";
            this.btnAddRotation.Size = new System.Drawing.Size(60, 23);
            this.btnAddRotation.TabIndex = 31;
            this.btnAddRotation.Text = "Add";
            this.btnAddRotation.UseVisualStyleBackColor = true;
            this.btnAddRotation.Click += new System.EventHandler(this.btnAddRotation_Click);
            // 
            // chekRotation1
            // 
            this.chekRotation1.AutoSize = true;
            this.chekRotation1.Location = new System.Drawing.Point(6, 66);
            this.chekRotation1.Name = "chekRotation1";
            this.chekRotation1.Size = new System.Drawing.Size(89, 20);
            this.chekRotation1.TabIndex = 30;
            this.chekRotation1.Text = "transpose";
            this.chekRotation1.UseVisualStyleBackColor = true;
            this.chekRotation1.CheckedChanged += new System.EventHandler(this.chekRotation1_CheckedChanged);
            // 
            // chekRotation2
            // 
            this.chekRotation2.AutoSize = true;
            this.chekRotation2.Location = new System.Drawing.Point(6, 92);
            this.chekRotation2.Name = "chekRotation2";
            this.chekRotation2.Size = new System.Drawing.Size(73, 20);
            this.chekRotation2.TabIndex = 28;
            this.chekRotation2.Text = "inverse";
            this.chekRotation2.UseVisualStyleBackColor = true;
            this.chekRotation2.CheckedChanged += new System.EventHandler(this.chekRotation2_CheckedChanged);
            // 
            // btnReplaceRotation
            // 
            this.btnReplaceRotation.Location = new System.Drawing.Point(67, 118);
            this.btnReplaceRotation.Name = "btnReplaceRotation";
            this.btnReplaceRotation.Size = new System.Drawing.Size(22, 23);
            this.btnReplaceRotation.TabIndex = 32;
            this.btnReplaceRotation.Text = "R";
            this.btnReplaceRotation.UseVisualStyleBackColor = true;
            this.btnReplaceRotation.Click += new System.EventHandler(this.btnReplaceRotation_Click);
            // 
            // typeRotation
            // 
            this.typeRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeRotation.FormattingEnabled = true;
            this.typeRotation.Items.AddRange(new object[] {
            "FLOAT",
            "HALF",
            "SHORT",
            "BYTE"});
            this.typeRotation.Location = new System.Drawing.Point(6, 36);
            this.typeRotation.Name = "typeRotation";
            this.typeRotation.Size = new System.Drawing.Size(83, 24);
            this.typeRotation.TabIndex = 29;
            // 
            // formatRotation
            // 
            this.formatRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatRotation.FormattingEnabled = true;
            this.formatRotation.Items.AddRange(new object[] {
            "MAT43",
            "MAT44",
            "QUAT",
            "ERAD",
            "EDEG"});
            this.formatRotation.Location = new System.Drawing.Point(6, 6);
            this.formatRotation.Name = "formatRotation";
            this.formatRotation.Size = new System.Drawing.Size(83, 24);
            this.formatRotation.TabIndex = 28;
            this.formatRotation.SelectedIndexChanged += new System.EventHandler(this.formatRotation_SelectedIndexChanged);
            // 
            // formatEuler
            // 
            this.formatEuler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatEuler.FormattingEnabled = true;
            this.formatEuler.Items.AddRange(new object[] {
            "XYZ",
            "XZY",
            "YXZ",
            "YZX",
            "ZXY",
            "ZYX"});
            this.formatEuler.Location = new System.Drawing.Point(6, 66);
            this.formatEuler.Name = "formatEuler";
            this.formatEuler.Size = new System.Drawing.Size(83, 24);
            this.formatEuler.TabIndex = 33;
            // 
            // tabPosition
            // 
            this.tabPosition.BackColor = System.Drawing.SystemColors.Control;
            this.tabPosition.Controls.Add(this.btnAddPosition);
            this.tabPosition.Controls.Add(this.typePosition);
            this.tabPosition.Controls.Add(this.btnReplacePosition);
            this.tabPosition.Location = new System.Drawing.Point(4, 25);
            this.tabPosition.Name = "tabPosition";
            this.tabPosition.Padding = new System.Windows.Forms.Padding(3);
            this.tabPosition.Size = new System.Drawing.Size(97, 147);
            this.tabPosition.TabIndex = 2;
            this.tabPosition.Text = "position";
            // 
            // btnAddPosition
            // 
            this.btnAddPosition.Location = new System.Drawing.Point(6, 118);
            this.btnAddPosition.Name = "btnAddPosition";
            this.btnAddPosition.Size = new System.Drawing.Size(60, 23);
            this.btnAddPosition.TabIndex = 33;
            this.btnAddPosition.Text = "Add";
            this.btnAddPosition.UseVisualStyleBackColor = true;
            this.btnAddPosition.Click += new System.EventHandler(this.btnAddPosition_Click);
            // 
            // typePosition
            // 
            this.typePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typePosition.FormattingEnabled = true;
            this.typePosition.Items.AddRange(new object[] {
            "FLOAT",
            "HALF",
            "SHORT",
            "BYTE"});
            this.typePosition.Location = new System.Drawing.Point(6, 6);
            this.typePosition.Name = "typePosition";
            this.typePosition.Size = new System.Drawing.Size(83, 24);
            this.typePosition.TabIndex = 28;
            // 
            // btnReplacePosition
            // 
            this.btnReplacePosition.Location = new System.Drawing.Point(67, 118);
            this.btnReplacePosition.Name = "btnReplacePosition";
            this.btnReplacePosition.Size = new System.Drawing.Size(22, 23);
            this.btnReplacePosition.TabIndex = 34;
            this.btnReplacePosition.Text = "R";
            this.btnReplacePosition.UseVisualStyleBackColor = true;
            this.btnReplacePosition.Click += new System.EventHandler(this.btnReplacePosition_Click);
            // 
            // tabParent
            // 
            this.tabParent.BackColor = System.Drawing.SystemColors.Control;
            this.tabParent.Controls.Add(this.btnAddParent);
            this.tabParent.Controls.Add(this.checkParentZero);
            this.tabParent.Controls.Add(this.typeNameParent);
            this.tabParent.Controls.Add(this.btnReplaceParent);
            this.tabParent.Controls.Add(this.typeParent);
            this.tabParent.Controls.Add(this.numericParent);
            this.tabParent.Location = new System.Drawing.Point(4, 25);
            this.tabParent.Name = "tabParent";
            this.tabParent.Padding = new System.Windows.Forms.Padding(3);
            this.tabParent.Size = new System.Drawing.Size(97, 147);
            this.tabParent.TabIndex = 5;
            this.tabParent.Text = "parent";
            // 
            // btnAddParent
            // 
            this.btnAddParent.Location = new System.Drawing.Point(6, 118);
            this.btnAddParent.Name = "btnAddParent";
            this.btnAddParent.Size = new System.Drawing.Size(60, 23);
            this.btnAddParent.TabIndex = 29;
            this.btnAddParent.Text = "Add";
            this.btnAddParent.UseVisualStyleBackColor = true;
            this.btnAddParent.Click += new System.EventHandler(this.btnAddParent_Click);
            // 
            // checkParentZero
            // 
            this.checkParentZero.AutoSize = true;
            this.checkParentZero.Location = new System.Drawing.Point(6, 94);
            this.checkParentZero.Name = "checkParentZero";
            this.checkParentZero.Size = new System.Drawing.Size(53, 20);
            this.checkParentZero.TabIndex = 25;
            this.checkParentZero.Text = "\\x00";
            this.checkParentZero.UseVisualStyleBackColor = true;
            // 
            // typeNameParent
            // 
            this.typeNameParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeNameParent.FormattingEnabled = true;
            this.typeNameParent.Items.AddRange(new object[] {
            "FIXED",
            "INT32",
            "INT24",
            "INT16",
            "INT8",
            "TO ZERO"});
            this.typeNameParent.Location = new System.Drawing.Point(6, 64);
            this.typeNameParent.Name = "typeNameParent";
            this.typeNameParent.Size = new System.Drawing.Size(83, 24);
            this.typeNameParent.TabIndex = 28;
            this.typeNameParent.SelectedIndexChanged += new System.EventHandler(this.typeNameParent_SelectedIndexChanged);
            // 
            // btnReplaceParent
            // 
            this.btnReplaceParent.Location = new System.Drawing.Point(67, 118);
            this.btnReplaceParent.Name = "btnReplaceParent";
            this.btnReplaceParent.Size = new System.Drawing.Size(22, 23);
            this.btnReplaceParent.TabIndex = 30;
            this.btnReplaceParent.Text = "R";
            this.btnReplaceParent.UseVisualStyleBackColor = true;
            this.btnReplaceParent.Click += new System.EventHandler(this.btnReplaceParent_Click);
            // 
            // typeParent
            // 
            this.typeParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeParent.FormattingEnabled = true;
            this.typeParent.Items.AddRange(new object[] {
            "INT32",
            "INT24",
            "INT16",
            "INT8",
            "STRING"});
            this.typeParent.Location = new System.Drawing.Point(6, 6);
            this.typeParent.Name = "typeParent";
            this.typeParent.Size = new System.Drawing.Size(83, 24);
            this.typeParent.TabIndex = 26;
            this.typeParent.SelectedIndexChanged += new System.EventHandler(this.typeParent_SelectedIndexChanged);
            // 
            // numericParent
            // 
            this.numericParent.Enabled = false;
            this.numericParent.Location = new System.Drawing.Point(6, 36);
            this.numericParent.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericParent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericParent.Name = "numericParent";
            this.numericParent.Size = new System.Drawing.Size(83, 22);
            this.numericParent.TabIndex = 27;
            // 
            // tabSeek
            // 
            this.tabSeek.BackColor = System.Drawing.SystemColors.Control;
            this.tabSeek.Controls.Add(this.textBoxSkipAsName);
            this.tabSeek.Controls.Add(this.checkBoxSkipFixed);
            this.tabSeek.Controls.Add(this.btnAddSeek);
            this.tabSeek.Controls.Add(this.checkSeekMul);
            this.tabSeek.Controls.Add(this.btnReplaceSeek);
            this.tabSeek.Controls.Add(this.typeSeek);
            this.tabSeek.Controls.Add(this.numericSeek);
            this.tabSeek.Controls.Add(this.numericSeekMul);
            this.tabSeek.Location = new System.Drawing.Point(4, 25);
            this.tabSeek.Name = "tabSeek";
            this.tabSeek.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeek.Size = new System.Drawing.Size(97, 147);
            this.tabSeek.TabIndex = 3;
            this.tabSeek.Text = "seek";
            // 
            // textBoxSkipAsName
            // 
            this.textBoxSkipAsName.Location = new System.Drawing.Point(6, 89);
            this.textBoxSkipAsName.Name = "textBoxSkipAsName";
            this.textBoxSkipAsName.ReadOnly = true;
            this.textBoxSkipAsName.Size = new System.Drawing.Size(83, 22);
            this.textBoxSkipAsName.TabIndex = 32;
            this.textBoxSkipAsName.Text = "as \"name\"";
            this.textBoxSkipAsName.Visible = false;
            // 
            // checkBoxSkipFixed
            // 
            this.checkBoxSkipFixed.AutoSize = true;
            this.checkBoxSkipFixed.Enabled = false;
            this.checkBoxSkipFixed.Location = new System.Drawing.Point(62, 64);
            this.checkBoxSkipFixed.Name = "checkBoxSkipFixed";
            this.checkBoxSkipFixed.Size = new System.Drawing.Size(36, 20);
            this.checkBoxSkipFixed.TabIndex = 31;
            this.checkBoxSkipFixed.Text = "n";
            this.checkBoxSkipFixed.UseVisualStyleBackColor = true;
            this.checkBoxSkipFixed.CheckedChanged += new System.EventHandler(this.checkBoxSkipFixed_CheckedChanged);
            // 
            // btnAddSeek
            // 
            this.btnAddSeek.Location = new System.Drawing.Point(6, 118);
            this.btnAddSeek.Name = "btnAddSeek";
            this.btnAddSeek.Size = new System.Drawing.Size(60, 23);
            this.btnAddSeek.TabIndex = 29;
            this.btnAddSeek.Text = "Add";
            this.btnAddSeek.UseVisualStyleBackColor = true;
            this.btnAddSeek.Click += new System.EventHandler(this.btnAddSeek_Click);
            // 
            // checkSeekMul
            // 
            this.checkSeekMul.AutoSize = true;
            this.checkSeekMul.Location = new System.Drawing.Point(6, 64);
            this.checkSeekMul.Name = "checkSeekMul";
            this.checkSeekMul.Size = new System.Drawing.Size(50, 20);
            this.checkSeekMul.TabIndex = 28;
            this.checkSeekMul.Text = "mul";
            this.checkSeekMul.UseVisualStyleBackColor = true;
            this.checkSeekMul.CheckedChanged += new System.EventHandler(this.checkSeekMul_CheckedChanged);
            // 
            // btnReplaceSeek
            // 
            this.btnReplaceSeek.Location = new System.Drawing.Point(67, 118);
            this.btnReplaceSeek.Name = "btnReplaceSeek";
            this.btnReplaceSeek.Size = new System.Drawing.Size(22, 23);
            this.btnReplaceSeek.TabIndex = 30;
            this.btnReplaceSeek.Text = "R";
            this.btnReplaceSeek.UseVisualStyleBackColor = true;
            this.btnReplaceSeek.Click += new System.EventHandler(this.btnReplaceSeek_Click);
            // 
            // typeSeek
            // 
            this.typeSeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeSeek.FormattingEnabled = true;
            this.typeSeek.Items.AddRange(new object[] {
            "FIXED",
            "INT32",
            "INT24",
            "INT16",
            "INT8"});
            this.typeSeek.Location = new System.Drawing.Point(6, 34);
            this.typeSeek.Name = "typeSeek";
            this.typeSeek.Size = new System.Drawing.Size(83, 24);
            this.typeSeek.TabIndex = 28;
            this.typeSeek.SelectedIndexChanged += new System.EventHandler(this.typeSeek_SelectedIndexChanged);
            // 
            // numericSeek
            // 
            this.numericSeek.Location = new System.Drawing.Point(6, 6);
            this.numericSeek.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericSeek.Name = "numericSeek";
            this.numericSeek.Size = new System.Drawing.Size(83, 22);
            this.numericSeek.TabIndex = 28;
            // 
            // numericSeekMul
            // 
            this.numericSeekMul.Location = new System.Drawing.Point(6, 90);
            this.numericSeekMul.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericSeekMul.Name = "numericSeekMul";
            this.numericSeekMul.Size = new System.Drawing.Size(83, 22);
            this.numericSeekMul.TabIndex = 28;
            this.numericSeekMul.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabOffset
            // 
            this.tabOffset.BackColor = System.Drawing.SystemColors.Control;
            this.tabOffset.Controls.Add(this.numericOffset);
            this.tabOffset.Controls.Add(this.btnAddOffset);
            this.tabOffset.Controls.Add(this.btnReplaceOffset);
            this.tabOffset.Location = new System.Drawing.Point(4, 25);
            this.tabOffset.Name = "tabOffset";
            this.tabOffset.Padding = new System.Windows.Forms.Padding(3);
            this.tabOffset.Size = new System.Drawing.Size(97, 147);
            this.tabOffset.TabIndex = 4;
            this.tabOffset.Text = "offset";
            // 
            // numericOffset
            // 
            this.numericOffset.Location = new System.Drawing.Point(6, 6);
            this.numericOffset.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericOffset.Name = "numericOffset";
            this.numericOffset.Size = new System.Drawing.Size(83, 22);
            this.numericOffset.TabIndex = 28;
            // 
            // numericDebug
            // 
            this.numericDebug.Location = new System.Drawing.Point(16, 211);
            this.numericDebug.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericDebug.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDebug.Name = "numericDebug";
            this.numericDebug.Size = new System.Drawing.Size(36, 22);
            this.numericDebug.TabIndex = 25;
            this.numericDebug.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericDebug.ValueChanged += new System.EventHandler(this.numericDebug_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 369);
            this.Controls.Add(this.numericDebug);
            this.Controls.Add(this.tabCMD);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.numericBones);
            this.Controls.Add(this.checkMultiply);
            this.Controls.Add(this.checkBigE);
            this.Controls.Add(this.btnMoveSelDown);
            this.Controls.Add(this.btnMoveSelUp);
            this.Controls.Add(this.btnDelSelCMD);
            this.Controls.Add(this.btnClearTemp);
            this.Controls.Add(this.btnPrintParent);
            this.Controls.Add(this.btnPrintPos);
            this.Controls.Add(this.btnPrintNames);
            this.Controls.Add(this.btnPrintMatrix);
            this.Controls.Add(this.btnClearDebug);
            this.Controls.Add(this.txtDebugBox);
            this.Controls.Add(this.checkRenderName);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.reset3D);
            this.Controls.Add(this.pic3D);
            this.Controls.Add(this.btnReadSkel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBoxTemp);
            this.Controls.Add(this.listBoxTemp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(673, 416);
            this.Name = "Form1";
            this.Text = "SkelFinder (by Durik256)";
            ((System.ComponentModel.ISupportInitialize)(this.pic3D)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBones)).EndInit();
            this.tabCMD.ResumeLayout(false);
            this.tabName.ResumeLayout(false);
            this.tabName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericName)).EndInit();
            this.tabRotation.ResumeLayout(false);
            this.tabRotation.PerformLayout();
            this.tabPosition.ResumeLayout(false);
            this.tabParent.ResumeLayout(false);
            this.tabParent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericParent)).EndInit();
            this.tabSeek.ResumeLayout(false);
            this.tabSeek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeekMul)).EndInit();
            this.tabOffset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDebug)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadSkel;
        private System.Windows.Forms.PictureBox pic3D;
        private System.Windows.Forms.Button reset3D;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.CheckBox checkRenderName;
        private System.Windows.Forms.TextBox txtDebugBox;
        private System.Windows.Forms.Button btnClearDebug;
        private System.Windows.Forms.Button btnPrintMatrix;
        private System.Windows.Forms.Button btnPrintNames;
        private System.Windows.Forms.Button btnPrintPos;
        private System.Windows.Forms.Button btnPrintParent;
        private System.Windows.Forms.Button btnClearTemp;
        private System.Windows.Forms.Button btnDelSelCMD;
        private System.Windows.Forms.ListBox listBoxTemp;
        private System.Windows.Forms.TextBox textBoxTemp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tollsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textBoxModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listBoxModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTemptxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTemptxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btnMoveSelUp;
        private System.Windows.Forms.Button btnMoveSelDown;
        private System.Windows.Forms.CheckBox checkBigE;
        private System.Windows.Forms.CheckBox checkMultiply;
        private System.Windows.Forms.NumericUpDown numericBones;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ToolStripMenuItem topicOnForumToolStripMenuItem;
        private System.Windows.Forms.Button btnAddOffset;
        private System.Windows.Forms.Button btnReplaceOffset;
        private System.Windows.Forms.TabControl tabCMD;
        private System.Windows.Forms.TabPage tabName;
        private System.Windows.Forms.TabPage tabRotation;
        private System.Windows.Forms.TabPage tabPosition;
        private System.Windows.Forms.Button btnAddName;
        private System.Windows.Forms.Button btnReplaceName;
        private System.Windows.Forms.CheckBox checkNameZero;
        private System.Windows.Forms.ComboBox typeName;
        private System.Windows.Forms.NumericUpDown numericName;
        private System.Windows.Forms.Button btnAddRotation;
        private System.Windows.Forms.CheckBox chekRotation1;
        private System.Windows.Forms.Button btnReplaceRotation;
        private System.Windows.Forms.ComboBox typeRotation;
        private System.Windows.Forms.ComboBox formatRotation;
        private System.Windows.Forms.Button btnAddPosition;
        private System.Windows.Forms.ComboBox typePosition;
        private System.Windows.Forms.Button btnReplacePosition;
        private System.Windows.Forms.TabPage tabSeek;
        private System.Windows.Forms.Button btnAddSeek;
        private System.Windows.Forms.NumericUpDown numericSeekMul;
        private System.Windows.Forms.CheckBox checkSeekMul;
        private System.Windows.Forms.Button btnReplaceSeek;
        private System.Windows.Forms.ComboBox typeSeek;
        private System.Windows.Forms.NumericUpDown numericSeek;
        private System.Windows.Forms.TabPage tabOffset;
        private System.Windows.Forms.NumericUpDown numericOffset;
        private System.Windows.Forms.TabPage tabParent;
        private System.Windows.Forms.Button btnAddParent;
        private System.Windows.Forms.CheckBox checkParentZero;
        private System.Windows.Forms.ComboBox typeNameParent;
        private System.Windows.Forms.Button btnReplaceParent;
        private System.Windows.Forms.NumericUpDown numericParent;
        private System.Windows.Forms.ComboBox formatEuler;
        private System.Windows.Forms.CheckBox chekRotation2;
        private System.Windows.Forms.NumericUpDown numericDebug;
        private System.Windows.Forms.ToolStripMenuItem saveBMPToolStripMenuItem;
        private System.Windows.Forms.ComboBox typeParent;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sFskelFinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sFSFasciiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colladasmdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valvesmdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxSkipFixed;
        private System.Windows.Forms.TextBox textBoxSkipAsName;
    }
}

