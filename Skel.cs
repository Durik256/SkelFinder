using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace SkelFinder
{
    class Skel
    {
        public bool printName = false;

        double xRotation = 0.0;
        double yRotation = 0.0;

        float zoom = 0;
        float maxDistance = 0;

        Vector3 camera = new Vector3();
        Vector3 skelOrigin;
        static Bone[] bones;

        Font arial = new Font("Arial", 8);
        Pen redPen = new Pen(Color.Red, 3);
        SolidBrush brush = new SolidBrush(Color.White);

        public double RotateX
        {
            get { return xRotation; }
            set { xRotation = value; }
        }

        public double RotateY
        {
            get { return yRotation; }
            set { yRotation = value; }
        }

        public void cameraZ(double delta)
        {
            if (delta < 0)
                camera.Z += maxDistance / 21;
            else
                camera.Z -= maxDistance / 21;
        }

        public Skel(Bone[] _bones)
        {
            bones = _bones;
            skelOrigin = CalcOrigin();

            zoom = Screen.PrimaryScreen.Bounds.Width / 1.5f;
            calcZcamera();
        }

        public void calcZcamera()
        {
            camera = new Vector3(skelOrigin.X, skelOrigin.Y, skelOrigin.Z + (maxDistance * 7));
        }

        public Vector3 CalcOrigin()
        {
            Vector3 origin = new Vector3();
            Vector3 Max    = new Vector3();
            Vector3 Min    = new Vector3();
            
            for (int i = 0; i < bones.Length; i++)
            {
                //X
                Min.X = Math.Min(Min.X, bones[i].Matrix.M41);
                Max.X = Math.Max(Max.X, bones[i].Matrix.M41);
                //Y
                Min.Y = Math.Min(Min.Y, bones[i].Matrix.M42);
                Max.Y = Math.Max(Max.Y, bones[i].Matrix.M42);
                //Z
                Min.Z = Math.Min(Min.Z, bones[i].Matrix.M43);
                Max.Z = Math.Max(Max.Z, bones[i].Matrix.M43);
            }
            origin.X =  (Min.X + Max.X) / 2;
            origin.Y = -(Min.Y + Max.Y) / 2;
            origin.Z =  (Min.Z + Max.Z) / 2;

            //max 
            maxDistance = Math.Max(maxDistance, Math.Abs(Min.X) + Math.Abs(Max.X));
            maxDistance = Math.Max(maxDistance, Math.Abs(Min.Y) + Math.Abs(Max.Y));
            maxDistance = Math.Max(maxDistance, Math.Abs(Min.Z) + Math.Abs(Max.Z));

            return origin;
        }

        public Bitmap drawSkel(Point drawOrigin)
        {
            //Vars
            PointF[] point3D = new PointF[bones.Length]; //Will be actual 2D drawing points
            Point tmpOrigin = new Point(0, 0);

            Vector3 point0 = new Vector3(0, 0, 0); //Used for reference

            //Set up the skel
            Vector3[] skelPoints = copyOrigVertices();

            //Apply Rotations, moving the skel to a corner then back to middle
            skelPoints = Math3D.Translate(skelPoints, skelOrigin, point0);
            skelPoints = Math3D.RotateX(skelPoints, xRotation); //The order of these
            skelPoints = Math3D.RotateY(skelPoints, yRotation); //rotations is the source
            skelPoints = Math3D.Translate(skelPoints, point0, skelOrigin);

            //Convert 3D Points to 2D
            Vector3 vec;
            for (int i = 0; i < point3D.Length; i++)
            {
                vec = skelPoints[i];
                if (vec.Z - camera.Z >= 0)
                {
                    point3D[i].X = (int)(-(vec.X - camera.X) / (-0.1f) * zoom) + drawOrigin.X;
                    point3D[i].Y = (int)( (vec.Y - camera.Y) / (-0.1f) * zoom) + drawOrigin.Y;
                }
                else
                {
                    tmpOrigin.X = (int)( (skelOrigin.X - camera.X) / (skelOrigin.Z - camera.Z) * zoom) + drawOrigin.X;
                    tmpOrigin.Y = (int)(-(skelOrigin.Y - camera.Y) / (skelOrigin.Z - camera.Z) * zoom) + drawOrigin.Y;

                    point3D[i].X =  (vec.X - camera.X) / (vec.Z - camera.Z) * zoom + drawOrigin.X;
                    point3D[i].Y = -(vec.Y - camera.Y) / (vec.Z - camera.Z) * zoom + drawOrigin.Y;

                    point3D[i].X = (int)point3D[i].X;
                    point3D[i].Y = (int)point3D[i].Y;
                }
            }

            Bitmap tmpBmp = new Bitmap(300, 300);//pic3D.Width; pic3D.Height;
            Graphics g = Graphics.FromImage(tmpBmp);

            for (int i = 0; i < point3D.Length; i++)
            {
                try
                {
                    g.FillRectangle(brush, point3D[i].X - 2.5f, point3D[i].Y - 2.5f, 5, 5);
                    if (printName)
                        g.DrawString(bones[i].Name, arial, brush, point3D[i]);//render names
                }
                catch
                {
                    Console.WriteLine("Error Render Point");
                }

            }

            for (int i = 0; i < point3D.Length; i++)
            {
                try
                {
                    if (bones[i].Parent >= 0 && bones[i].Parent < point3D.Length)
                    g.DrawLine(redPen, point3D[i], point3D[bones[i].Parent]);
                }
                catch
                {
                    Console.WriteLine("Error Render Line");
                }
            }

            g.Dispose(); //Clean-up
            return tmpBmp;
        }
        public static Vector3[] copyOrigVertices()
        {
            Vector3[] verts = new Vector3[bones.Length];
            for (int i = 0; i < bones.Length; i++)
                verts[i] = new Vector3(bones[i].Matrix.M41 * -1, bones[i].Matrix.M42 * -1, bones[i].Matrix.M43);

            return verts;
        }
    }
}
