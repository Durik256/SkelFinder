using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SkelFinder
{
    internal class mySMD
    {
        public static void writeSMD(Bone[] bones, StreamWriter obj)
        {
            obj.WriteLine("version 1");
            obj.WriteLine("nodes");
            
            //write name and parent index
            for(int i = 0; i < bones.Length; i++)
                obj.WriteLine($"  {i} \"{bones[i].Name}\"  {bones[i].Parent}");

            obj.WriteLine("end");
            obj.WriteLine("skeleton");
            obj.WriteLine("time 0");
            
            //write matrix
            for (int i = 0; i < bones.Length; i++)
            {
                Vector3 rot = new Vector3();
                Vector3 pos = new Vector3();

                if (bones[i].Parent >= 0 && bones[i].Parent < bones.Length)
                {
                    //world to local
                    Matrix4x4 mat0, mat1;
                    Matrix4x4.Invert(bones[bones[i].Parent].Matrix, out mat0);
                    mat1 = bones[i].Matrix * mat0;
                    rot = ToAngles(mat1);
                    pos = new Vector3(mat1.M41, mat1.M42, mat1.M43);
                }
                else
                {
                    rot = ToAngles(bones[i].Matrix);
                    pos = new Vector3(bones[i].Matrix.M41, bones[i].Matrix.M42, bones[i].Matrix.M43);
                }
                obj.WriteLine($"  {i} {pos.X.ToString("n6")} {pos.Y.ToString("n6")} {pos.Z.ToString("n6")} {rot.X.ToString("n6")} {rot.Y.ToString("n6")} {rot.Z.ToString("n6")}".Replace(',', '.'));
            }
            obj.WriteLine("end");
        }

        static Vector3 ToAngles(Matrix4x4 R)
        {
            float x, y, z;

            x = (float)Math.Atan2(R.M23, R.M33);
            y = (float)Math.Atan2(-R.M13, Math.Sqrt(Math.Pow(R.M23, 2) + Math.Pow(R.M33, 2)));
            z = (float)Math.Atan2(R.M12, R.M11);

            return new Vector3(x, y, z);
        }
    }
}
