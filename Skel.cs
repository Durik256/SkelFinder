using System;
using System.Drawing;
using System.Windows.Forms;

namespace SkelFinder
{
    class Skel
    {
        public bool printName = false;

        double xRotation = 0.0;
        double yRotation = 0.0;
        double zRotation = 0.0;

        double zoom = 0;
        double maxDistance = 0;

        Math3D.Camera camera1 = new Math3D.Camera();
        Math3D.Point3D skelOrigin;
        static Bone[] bones;

        Font arial = new Font("Arial", 8);
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

        public double RotateZ
        {
            get { return zRotation; }
            set { zRotation = value; }
        }

        public void cameraZ(double delta)
        {
            if (delta < 0)
                camera1.Position.Z += maxDistance / 21;
            else
                camera1.Position.Z -= maxDistance / 21;
        }

        public Skel(Bone[] _bones)
        {
            bones = _bones;
            skelOrigin = CalcOrigin();

            zoom = (double)Screen.PrimaryScreen.Bounds.Width / 1.5;
            calcZcamera();
        }

        public void calcZcamera()
        {
            camera1.Position = new Math3D.Point3D(skelOrigin.X, skelOrigin.Y, skelOrigin.Z + (maxDistance * 7));
        }

        public Math3D.Point3D CalcOrigin()
        {
            Math3D.Point3D origin = new Math3D.Point3D(0, 0, 0);
            Math3D.Point3D Max = new Math3D.Point3D(0, 0, 0);
            Math3D.Point3D Min = new Math3D.Point3D(0, 0, 0);
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
            origin.X = (Min.X + Max.X) / 2;
            origin.Y = -(Min.Y + Max.Y) / 2;
            origin.Z = (Min.Z + Max.Z) / 2;

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

            Math3D.Point3D point0 = new Math3D.Point3D(0, 0, 0); //Used for reference

            //Set up the skel
            Math3D.Point3D[] cubePoints = copyOrigVertices();

            //Apply Rotations, moving the skel to a corner then back to middle
            cubePoints = Math3D.Translate(cubePoints, skelOrigin, point0);
            cubePoints = Math3D.RotateX(cubePoints, xRotation); //The order of these
            cubePoints = Math3D.RotateY(cubePoints, yRotation); //rotations is the source
            cubePoints = Math3D.RotateZ(cubePoints, zRotation); //of Gimbal Lock
            cubePoints = Math3D.Translate(cubePoints, point0, skelOrigin);

            //Convert 3D Points to 2D
            Math3D.Point3D vec;
            for (int i = 0; i < point3D.Length; i++)
            {
                vec = cubePoints[i];
                if (vec.Z - camera1.Position.Z >= 0)
                {
                    point3D[i].X = (int)((double)-(vec.X - camera1.Position.X) / (-0.1f) * zoom) + drawOrigin.X;
                    point3D[i].Y = (int)((double)(vec.Y - camera1.Position.Y) / (-0.1f) * zoom) + drawOrigin.Y;
                }
                else
                {
                    tmpOrigin.X = (int)((double)(skelOrigin.X - camera1.Position.X) / (double)(skelOrigin.Z - camera1.Position.Z) * zoom) + drawOrigin.X;
                    tmpOrigin.Y = (int)((double)-(skelOrigin.Y - camera1.Position.Y) / (double)(skelOrigin.Z - camera1.Position.Z) * zoom) + drawOrigin.Y;

                    point3D[i].X = (float)((vec.X - camera1.Position.X) / (vec.Z - camera1.Position.Z) * zoom + drawOrigin.X);
                    point3D[i].Y = (float)(-(vec.Y - camera1.Position.Y) / (vec.Z - camera1.Position.Z) * zoom + drawOrigin.Y);

                    point3D[i].X = (int)point3D[i].X;
                    point3D[i].Y = (int)point3D[i].Y;
                }
            }

            Bitmap tmpBmp = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(tmpBmp);

            for (int i = 0; i < point3D.Length; i++)
            {
                if (point3D[i].X > 300 || point3D[i].Y > 300 || point3D[i].X < 0 || point3D[i].Y < 0)
                    continue;
                g.FillRectangle(brush, point3D[i].X - 2.5f, point3D[i].Y - 2.5f, 5, 5);
                if (printName)
                    g.DrawString(bones[i].Name, arial, brush, point3D[i]);//render names
            }
            Pen redPen = new Pen(Color.Red, 3);

            for (int i = 0; i < point3D.Length; i++)
            {
                if (bones[i].Parent >= 0 && bones[i].Parent < point3D.Length)
                    try
                    {
                        g.DrawLine(redPen, point3D[i], point3D[bones[i].Parent]);
                    }
                    catch
                    {
                        Console.WriteLine("Error Parent index");
                    }
            }

            g.Dispose(); //Clean-up

            return tmpBmp;
        }
        public static Math3D.Point3D[] copyOrigVertices()
        {
            Math3D.Point3D[] verts = new Math3D.Point3D[bones.Length];
            for (int i = 0; i < bones.Length; i++)
                verts[i] = new Math3D.Point3D(bones[i].Matrix.M41 * -1, bones[i].Matrix.M42 * -1, bones[i].Matrix.M43);

            return verts;
        }
    }
}
