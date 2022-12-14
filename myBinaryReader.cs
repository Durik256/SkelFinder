using System;
using System.IO;
using System.Text;

namespace SkelFinder
{
    internal class myBinaryReader : BinaryReader
    {
        public enum Endian
        {
            Little,
            Big,
        }

        private readonly Endian _Endian = Endian.Little;

        public myBinaryReader(Stream input) : base(input) { }

        public myBinaryReader(Stream input, Encoding encoding) : base(input, encoding) { }

        public myBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen) { }

        public myBinaryReader(Stream input, Endian Endian) : base(input)
        {
            _Endian = Endian;
        }

        public myBinaryReader(Stream input, Encoding encoding, Endian Endian) : base(input, encoding)
        {
            _Endian = Endian;
        }

        public myBinaryReader(Stream input, Encoding encoding, bool leaveOpen, Endian Endian) : base(input, encoding, leaveOpen)
        {
            _Endian = Endian;
        }

        public override short ReadInt16() => ReadInt16(_Endian);

        public override int ReadInt32() => ReadInt32(_Endian);

        public override long ReadInt64() => ReadInt64(_Endian);

        public override ushort ReadUInt16() => ReadUInt16(_Endian);

        public override uint ReadUInt32() => ReadUInt32(_Endian);

        public override ulong ReadUInt64() => ReadUInt64(_Endian);

        public override float ReadSingle() => ReadSingle(_Endian);

        public int ReadInt24() => int24(read(3, _Endian));

        public short ReadInt16(Endian Endian) => BitConverter.ToInt16(read(sizeof(short), Endian), 0);

        public int ReadInt32(Endian Endian) => BitConverter.ToInt32(read(sizeof(int), Endian), 0);

        public long ReadInt64(Endian Endian) => BitConverter.ToInt64(read(sizeof(long), Endian), 0);

        public ushort ReadUInt16(Endian Endian) => BitConverter.ToUInt16(read(sizeof(ushort), Endian), 0);

        public int ReadUInt24() => uint24(read(3, _Endian));

        public uint ReadUInt32(Endian Endian) => BitConverter.ToUInt32(read(sizeof(uint), Endian), 0);

        public ulong ReadUInt64(Endian Endian) => BitConverter.ToUInt64(read(sizeof(ulong), Endian), 0);

        public float ReadHalf() => half(BitConverter.ToUInt16(read(sizeof(ushort), _Endian), 0));

        public float ReadSingle(Endian Endian) => BitConverter.ToSingle(read(sizeof(float), Endian), 0);

        public int int24(byte[] array) { return (array[0] | array[1] << 8 | (sbyte)array[2] << 16); }

        public int uint24(byte[] array) { return (array[0] | array[1] << 8 | array[2] << 16); }

        public float half(ushort data)
        {
            uint dataSign = (uint)data >> 15;
            uint dataExp = ((uint)data >> 10) & 0x001F;
            uint dataFrac = (uint)data & 0x03FF;

            uint floatExp = 0;
            uint floatFrac = 0;

            switch (dataExp)
            {
                case 0:
                    if (dataFrac != 0)
                    {
                        floatExp = -15 + 127;
                        while ((dataFrac & 0x200) == 0) { dataFrac <<= 1; floatExp--; }
                        floatFrac = (dataFrac & 0x1FF) << 14;
                    }
                    else { floatFrac = 0; floatExp = 0; }
                    break;
                case 31:
                    floatExp = 255;
                    floatFrac = dataFrac != 0 ? (uint)0x200000 : 0;
                    break;
                default:
                    floatExp = dataExp - 15 + 127;
                    floatFrac = dataFrac << 13;
                    break;
            }
            uint floatNum = dataSign << 31 | floatExp << 23 | floatFrac;
            return BitConverter.ToSingle(BitConverter.GetBytes(floatNum), 0);
        }

        private byte[] read(int bytesToRead, Endian Endian)
        {
            var bytesRead = ReadBytes(bytesToRead);

            if (Endian == Endian.Big)
                Array.Reverse(bytesRead);

            return bytesRead;
        }
    }
}
