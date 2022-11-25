using System.Numerics;

namespace SkelFinder
{
    internal class Bone
    {
        string name;
        Matrix4x4 matrix;
        int parent;
        string sparent;

        public Bone()
        {
            identity();
        }
        public Bone(string _name, Matrix4x4 _matrix, int _parent)
        {
            name = _name;
            matrix = _matrix;
            parent = _parent;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Matrix4x4 Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        public int Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        public string SParent
        {
            get { return sparent; }
            set { sparent = value; }
        }

        void identity()
        {
            name = "bone";
            matrix = new Matrix4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
            parent = -1;
        }
        public void replaceRotation(Matrix4x4 _matrix)
        {
            Vector3 pos = new Vector3(matrix.M41, matrix.M42, matrix.M43);
            matrix = _matrix;
            matrix.M41 = pos.X;
            matrix.M41 = pos.Y;
            matrix.M41 = pos.Z;
        }

        public void replacePosition(Vector3 pos)
        {
            matrix.M41 = pos.X;
            matrix.M41 = pos.Y;
            matrix.M41 = pos.Z;
        }
    }
}
