using System;
using System.Numerics;

namespace SkelFinder
{
    internal class Math3D
    {
        public static Vector3 RotateX(Vector3 point3D, double degrees)
        {
            //Here we use Euler's matrix formula for rotating a 3D point x degrees around the x-axis

            //[ a  b  c ] [ x ]   [ x*a + y*b + z*c ]
            //[ d  e  f ] [ y ] = [ x*d + y*e + z*f ]
            //[ g  h  i ] [ z ]   [ x*g + y*h + z*i ]

            //[ 1    0        0   ]
            //[ 0   cos(x)  sin(x)]
            //[ 0   -sin(x) cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0f; //Convert degrees to radian for .Net Cos/Sin functions
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);

            float y = (point3D.Y * cosDegrees) + (point3D.Z * sinDegrees);
            float z = (point3D.Y * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Vector3(point3D.X, y, z);
        }

        public static Vector3 RotateY(Vector3 point3D, double degrees)
        {
            //Y-axis

            //[ cos(x)   0    sin(x)]
            //[   0      1      0   ]
            //[-sin(x)   0    cos(x)]

            double cDegrees = (Math.PI * degrees) / 180.0; //Radians
            float cosDegrees = (float)Math.Cos(cDegrees);
            float sinDegrees = (float)Math.Sin(cDegrees);

            float x = (point3D.X * cosDegrees) + (point3D.Z * sinDegrees);
            float z = (point3D.X * -sinDegrees) + (point3D.Z * cosDegrees);

            return new Vector3(x, point3D.Y, z);
        }

        public static Vector3 Translate(Vector3 points3D, Vector3 oldOrigin, Vector3 newOrigin)
        {
            Vector3 difference = newOrigin - oldOrigin;
            return points3D += difference;
        }

        public static Vector3[] RotateX(Vector3[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
                points3D[i] = RotateX(points3D[i], degrees);
            
            return points3D;
        }

        public static Vector3[] RotateY(Vector3[] points3D, double degrees)
        {
            for (int i = 0; i < points3D.Length; i++)
                points3D[i] = RotateY(points3D[i], degrees);
            
            return points3D;
        }

        public static Vector3[] Translate(Vector3[] points3D, Vector3 oldOrigin, Vector3 newOrigin)
        {
            for (int i = 0; i < points3D.Length; i++)
                points3D[i] = Translate(points3D[i], oldOrigin, newOrigin);
            
            return points3D;
        }

        //Rotate using Quaternion (not used)
        public static Vector3[] Rotate(Vector3[] points3D, double xRotation, double yRotation)
        {
            Quaternion rot = Quaternion.CreateFromYawPitchRoll(-(float)((Math.PI / 180) * yRotation), (float)((Math.PI / 180) * xRotation), 0);
            for (int i = 0; i < points3D.Length; i++)
            {
                points3D[i] = Vector3.Transform(points3D[i], rot);
            }
            return points3D;
        }
    }
}
