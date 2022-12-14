using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace SkelFinder
{
    internal static class myDAE
    {
        static daeBone[] daeBones;
        static List<int> roots;
        public static void writeDAE(Bone[] bones, StreamWriter obj)
        {
            roots = new List<int>();
            daeBones = new daeBone[bones.Length];
            
            for (int i = 0; i < bones.Length; i++)
            {
                daeBone curBone = new daeBone(bones[i].Name);
                for (int j = 0; j < bones.Length; j++)
                {
                    if (bones[j].Parent == i)
                        curBone.Child.Add(j);
                }

                if (bones[i].Parent >= 0 && bones[i].Parent < bones.Length)
                {
                    Matrix4x4 invParent;
                    Matrix4x4.Invert(bones[bones[i].Parent].Matrix, out invParent);
                    curBone.Matrix = bones[i].Matrix * invParent;
                }
                else
                {
                    roots.Add(i);
                    curBone.Matrix = bones[i].Matrix;
                }

                daeBones[i] = curBone;
            }

            obj.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            obj.WriteLine("<COLLADA xmlns=\"http://www.collada.org/2005/11/COLLADASchema\" version=\"1.4.1\">");
            obj.WriteLine("<library_visual_scenes>");
            obj.WriteLine("<visual_scene id=\"VisualSceneNode\" name=\"rdmscene\">");

            //Write Bones
            foreach(int i in roots)
            {
                writeBone(i, obj);
            }

            obj.WriteLine("</visual_scene>");
            obj.WriteLine("</library_visual_scenes>");
            obj.WriteLine("<scene>");
            obj.WriteLine("<instance_visual_scene url=\"#VisualSceneNode\"/>");
            obj.WriteLine("</scene>");
            obj.WriteLine("</COLLADA>");

            daeBones = null;
            roots = null;
        }

        static void writeBone(int i, StreamWriter obj)
        {
            obj.WriteLine($"<node id=\"{daeBones[i].Name}\" name=\"{daeBones[i].Name}\" sid=\"{daeBones[i].Name}\" type=\"JOINT\">");
            obj.WriteLine($"<matrix>{MatToString(Matrix4x4.Transpose(daeBones[i].Matrix)).Replace(',', '.')}</matrix>");
            foreach (int j in daeBones[i].Child)
            {
                writeBone(j, obj);
            }
            obj.WriteLine($"</node>");
        }

        static string MatToString(Matrix4x4 Matrix)
        {
            string f = "n6";
            return $"{Matrix.M11.ToString(f)} {Matrix.M12.ToString(f)} {Matrix.M13.ToString(f)} {Matrix.M14.ToString(f)} " +
                   $"{Matrix.M21.ToString(f)} {Matrix.M22.ToString(f)} {Matrix.M23.ToString(f)} {Matrix.M24.ToString(f)} " +
                   $"{Matrix.M31.ToString(f)} {Matrix.M32.ToString(f)} {Matrix.M33.ToString(f)} {Matrix.M34.ToString(f)} " +
                   $"{Matrix.M41.ToString(f)} {Matrix.M42.ToString(f)} {Matrix.M43.ToString(f)} {Matrix.M44.ToString(f)}";
        }
    }

    class daeBone
    {
        public string name;
        Matrix4x4 mat;
        List<int> childs;

        public daeBone(string name)
        {
            this.name = name;
            childs = new List<int>();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Matrix4x4 Matrix
        {
            get { return mat; }
            set { mat = value; }
        }

        public List<int> Child
        {
            get { return childs; }
            set { childs = value; }
        }
    }
}
