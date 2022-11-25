using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace SkelFinder
{
    internal static class Parser
    {
        static public Bone[] ParseTemplate(myBinaryReader br, string template, int numBones, bool multiply)
        {
            if(numBones <= 0)
            {
                printDebug("Enter number of bones!" + Environment.NewLine, true);
                return null;
            }  

            if (string.IsNullOrEmpty(template))
            {
                printDebug("Enter template!" + Environment.NewLine, true);
                return null;
            }
            bool strParent = false;

            Bone[] bones = new Bone[numBones];
            for (int i = 0; i < bones.Length; i++)
            {
                bones[i] = new Bone();
                bones[i].Name = $"bone_{i}(#SF)";
            }    
            
            Stream fs = br.BaseStream;

            string[] parts = template.ToLower().Split(new[] { "off" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                string[] cmd = part.Split('\n');//Environment.NewLine
                
                if (cmd[0].ToLower().Contains("set"))
                    fs.Seek(Convert.ToInt64(cmd[0].Split('[', ']')[1]), SeekOrigin.Begin);

                for (int i = 0; i < numBones; i++)
                {
                    if (fs.Position >= fs.Length)
                    {
                        printDebug("Error EOF!>>>" + Environment.NewLine);
                        //goto returnBones;
                        Bone[] curBones = new Bone[i];
                        for (int b = 0; b < i; b++)
                            curBones[b] = bones[b];
                        return curBones;
                    }

                    for (int c = 0; c < cmd.Length; c++)
                    {
                        if (string.IsNullOrEmpty(cmd[c]))
                            continue;

                        string[] param = cmd[c].Split('[', ']');
                        string[] arg = param[1].Trim().Split(',');

                        switch (param[0])
                        {
                            case "set":
                                break;
                            
                            case "seek":
                                long value = Convert.ToInt64(arg[0]);

                                if (arg.Length > 1)
                                {
                                    value = ParseInt(br, arg[1]);
                                    if (arg.Length > 2)
                                        value *= Convert.ToInt32(arg[2]);
                                }

                                fs.Seek(value, SeekOrigin.Current);
                                break;

                            case "quat":
                                Quaternion localQuat = new Quaternion(ParseFloat(br, arg[0]), ParseFloat(br, arg[0]), ParseFloat(br, arg[0]), ParseFloat(br, arg[0]));
                                if (arg.Length > 1)
                                {
                                    for (int j = 1; j < arg.Length; j++)
                                    {
                                        if (arg[j].Contains("norm"))
                                            localQuat = Quaternion.Normalize(localQuat);
                                        if (arg[j].Contains("inv"))
                                            localQuat = Quaternion.Inverse(localQuat);
                                    }
                                }

                                bones[i].replaceRotation(Matrix4x4.CreateFromQuaternion(localQuat));

                                //printDebug($"quad: {localQuat}");
                                printQuat(localQuat);
                                break;

                            case "erad":
                                Vector3 eulerRad = new Vector3(ParseFloat(br, arg[0]), ParseFloat(br, arg[0]), ParseFloat(br, arg[0]));
                                if (arg.Length > 1)
                                    eulerRad = transposeVec3(eulerRad, arg[1]);

                                bones[i].replaceRotation(Matrix4x4.CreateFromYawPitchRoll(eulerRad.X, eulerRad.Y, eulerRad.Z));

                                //printDebug($"euler rad: {euler Rad}");
                                printVec3(eulerRad, "euler rad");
                                break;

                            case "edeg":
                                Vector3 eulerDeg = new Vector3();

                                if (arg[0].Contains("float") || arg[0].Contains("half"))
                                    eulerDeg = new Vector3(ParseFloat(br, arg[0]), ParseFloat(br, arg[0]), ParseFloat(br, arg[0]));
                                else
                                    eulerDeg = new Vector3(ParseInt(br, arg[0]), ParseInt(br, arg[0]), ParseInt(br, arg[0]));

                                if (arg.Length > 1)
                                    eulerDeg = transposeVec3(eulerDeg, arg[1]);

                                bones[i].replaceRotation(Matrix4x4.CreateFromYawPitchRoll(eulerDeg.X, eulerDeg.Y, eulerDeg.Z));

                                //printDebug($"euler deg: {eulerDeg}");
                                printVec3(eulerDeg, "euler deg");
                                break;

                            case "mat43":
                                Matrix4x4 localMat43 = new Matrix4x4(
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]), 0,
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]), 0,
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]), 0,
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]),
                                    ParseFloat(br, arg[0]), 1);

                                if (arg.Length > 1)
                                {
                                    for (int j = 1; j < arg.Length; j++)
                                    {
                                        if (arg[j].Contains("trans"))
                                            localMat43 = transposeMat43(localMat43);
                                        if (arg[j].Contains("inv"))
                                            localMat43 = inverseMat43(localMat43);
                                    }
                                }

                                bones[i].Matrix = localMat43;

                                //printDebug($"mat43: {localMat43}");
                                printMat43(localMat43);
                                break;

                            case "mat44":
                                Matrix4x4 localMat44 = new Matrix4x4(
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]),
                                ParseFloat(br, arg[0]));

                                if (arg.Length > 1)
                                {
                                    for (int j = 1; j < arg.Length; j++)
                                    {
                                        if (arg[j].Contains("trans"))
                                            localMat44 = Matrix4x4.Transpose(localMat44);
                                        if (arg[j].Contains("inv"))
                                            Matrix4x4.Invert(localMat44, out localMat44);
                                    }
                                }

                                bones[i].Matrix = localMat44;

                                //printDebug($"mat44: {localMat44}");
                                printMat44(localMat44);
                                break;

                            case "pos":
                                Vector3 pos = new Vector3(ParseFloat(br, arg[0]), ParseFloat(br, arg[0]), ParseFloat(br, arg[0]));
                                bones[i].replacePosition(pos);

                                //printDebug($"pos: {pos}");
                                printVec3(pos);
                                break;

                            case "parent":
                                if (arg.Length > 1)
                                {
                                    strParent = true;

                                    var arr = arg.Skip(1).ToArray();
                                    string parName = readName(arr, br);
                                    bones[i].SParent = parName;

                                    printDebug($"{i} parent: {parName}" + Environment.NewLine);
                                }
                                else
                                {
                                    strParent = false;
                                    bones[i].Parent = ParseInt(br, arg[0]);

                                    printDebug($"{i} parent: {bones[i].Parent}" + Environment.NewLine);
                                }
                                break;

                            case "name":
                                string name = readName(arg, br);

                                if (name != null)
                                    bones[i].Name = name;

                                printDebug("name: " + name + Environment.NewLine);
                                break;

                            default:
                                printDebug("Unknown command: " + cmd[i] + Environment.NewLine);
                                break;
                        }
                    }
                }
            }

            if (strParent)
            {
                for (int i = 0; i < bones.Length; i++)
                {
                    int index = Array.FindIndex(bones, b => b.Name == b.SParent);
                    if (index != -1)
                        bones[i].Parent = index;
                }
            }

            if (multiply)
            {
                for (int i = 0; i < bones.Length; i++)
                {
                    if (bones[i].Parent != -1 && bones[i].Parent < bones.Length)
                    {
                        Matrix4x4 invParent = bones[i].Matrix;
                        bones[i].Matrix *= invParent;
                    }
                }
            }

            returnBones:
            return bones;
        }
        
        static void printDebug(string s, bool clear = false)
        {
            System.Windows.Forms.TextBox debugBox = Form1.debugBox;
            
            if (clear)
                debugBox.Text = "";
            
            if (!debugBox.Text.EndsWith(Environment.NewLine) && !string.IsNullOrEmpty(debugBox.Text))
                s = Environment.NewLine + s;

            debugBox.Text += s;
        }
        
        static string readName(string[] arg, myBinaryReader br)
        {
            int lenght = Convert.ToInt32(arg[0].Trim());
            if (arg.Length > 1)
            {
                lenght = ParseInt(br, arg[1]) + 1;
                if (arg.Length > 2)
                    lenght--;
            }

            if (lenght > 999)
                lenght = 999;

            if (lenght > br.BaseStream.Length - br.BaseStream.Position)
                lenght = (int)(br.BaseStream.Length - br.BaseStream.Position);

            if (lenght > 0)
            {
                string name = "";
                char[] chars = br.ReadChars(lenght);
                
                foreach (char c in chars)
                    if (!char.IsControl(c))
                        name += c;
                return name;
            }
            return null;
        }

        static int ParseInt(myBinaryReader br, string value)
        {
            //need check EOF
            value = value.ToLower().Trim();

            switch (value)
            {
                case "int64" : return (int)br.ReadInt64();
                case "int32" : return br.ReadInt32();
                case "int": return br.ReadInt32();
                case "int24" : return br.ReadInt24();
                case "int16" : return br.ReadInt16();
                case "int8"  : if (br.chekEOF(1)) { return br.ReadSByte(); } else { return 0; };
                case "uint64": return (int)br.ReadUInt64();
                case "uint32": return (int)br.ReadUInt32();
                case "uint": return (int)br.ReadUInt32();
                case "uint24": return br.ReadUInt24();
                case "uint16": return br.ReadUInt16();
                case "uint8" : return br.ReadByte();
                default: throw new ArgumentException("Unknown value: " + value);
            }
        }

        static float ParseFloat(myBinaryReader br, string value)
        {
            value = value.ToLower().Trim();

            switch (value)
            {
                case "float": return fixFloat(br.ReadSingle());
                case "half" : return fixFloat(br.ReadHalf());
                case "int16": return br.ReadInt16() / 32768f;
                case "short": return br.ReadInt16() / 32768f;
                case "int8" : if (br.chekEOF(1)) { return br.ReadSByte() / 255f; } else { return 0; };
                case "byte" : if (br.chekEOF(1)) { return br.ReadSByte() / 255f; } else { return 0; };

                default: throw new ArgumentException("Unknown value: " + value);
            }
        }
        
        static Vector3 transposeVec3(Vector3 vec3, string format = "xyz")
        {
            format = format.ToLower().Trim();
            
            switch (format)
            {
                case "xyz": return new Vector3(vec3.X, vec3.Y, vec3.Z);
                case "xzy": return new Vector3(vec3.X, vec3.Z, vec3.Y);
                case "yxz": return new Vector3(vec3.Y, vec3.X, vec3.Z);
                case "yzx": return new Vector3(vec3.Y, vec3.Z, vec3.X);
                case "zxy": return new Vector3(vec3.Z, vec3.X, vec3.Y);
                case "zyx": return new Vector3(vec3.Z, vec3.Y, vec3.X);

                default:
                    printDebug("Unknown value: " + format);
                    return vec3;
            }
        }
        
        static Matrix4x4 transposeMat43(Matrix4x4 local)
        {
            float m00 = local.M11, m01 = local.M12, m02 = local.M13,
                  m10 = local.M21, m11 = local.M22, m12 = local.M23,
                  m20 = local.M31, m21 = local.M32, m22 = local.M33;

            local.M12 = m10; local.M21 = m01;
            local.M13 = m20; local.M31 = m02;
            local.M23 = m21; local.M32 = m12;

            return local;
        }

        static Matrix4x4 inverseMat43(Matrix4x4 local)
        {
            float m00 = local.M11, m01 = local.M12, m02 = local.M13,
                  m10 = local.M21, m11 = local.M22, m12 = local.M23,
                  m20 = local.M31, m21 = local.M32, m22 = local.M33,
                  m30 = local.M41, m31 = local.M42, m32 = local.M43;

            //Determinant
            float minor00Det = m11 * m22 - m12 * m21;
            float minor01Det = m10 * m22 - m12 * m20;
            float minor02Det = m10 * m21 - m11 * m20;

            float det = 1 / m00 * minor00Det - m01 * minor01Det + m02 * minor02Det;
            
            if (Math.Abs(det - 0) <= 0.00001)
                return new Matrix4x4();
            
            Matrix4x4 m = new Matrix4x4();
            m.M11 =  (m11 * m22 - m12 * m21);
            m.M12 = -(m01 * m22 - m02 * m21);
            m.M13 =  (m01 * m12 - m02 * m11);
            m.M21 = -(m10 * m22 - m12 * m20);
            m.M22 =  (m00 * m22 - m02 * m20);
            m.M23 = -(m00 * m12 - m02 * m10);
            m.M31 =  (m10 * m21 - m11 * m20);
            m.M32 = -(m00 * m21 - m01 * m20);
            m.M33 =  (m00 * m11 - m01 * m10);
            m.M41 = -(m10 * (m21 * m32 - m22 * m31) - m11 * (m20 * m32 - m22 * m30) + m12 * (m20 * m31 - m21 * m30));
            m.M42 =  (m00 * (m21 * m32 - m22 * m31) - m01 * (m20 * m32 - m22 * m30) + m02 * (m20 * m31 - m21 * m30));
            m.M43 = -(m00 * (m11 * m32 - m12 * m31) - m01 * (m10 * m32 - m12 * m30) + m02 * (m10 * m31 - m11 * m30));
            return m;
        }

        static float fixFloat(float f)
        {
            if (Single.IsNaN(f))
                return 0;
            //f = Math.Clamp(f, -max, max);
            return f;
        }
        //Dublicate
        static void printMat44(Matrix4x4 mat)
        {
            printDebug($"mat44: (({mat.M11},{mat.M12},{mat.M13},{mat.M14}), ({mat.M21},{mat.M22},{mat.M23},{mat.M24}), ({mat.M31},{mat.M32},{mat.M33},{mat.M34}), ({mat.M41},{mat.M42},{mat.M43},{mat.M44}))" + Environment.NewLine);
        }
        
        static void printMat43(Matrix4x4 mat)
        {
            printDebug($"mat43: (({mat.M11},{mat.M12},{mat.M13}), ({mat.M21},{mat.M22},{mat.M23}), ({mat.M31},{mat.M32},{mat.M33}), ({mat.M41},{mat.M42},{mat.M43}))" + Environment.NewLine);
        }
        
        static void printQuat(Quaternion quat)
        {
            printDebug($"quat: ({quat.X},{quat.Y},{quat.Z}, {quat.W})" + Environment.NewLine);
        }
        
        static void printVec3(Vector3 vec3, string name = "vec3")
        {
            printDebug($"{name}: ({vec3.X},{vec3.Y},{vec3.Z})" + Environment.NewLine);
        }
    }
}
