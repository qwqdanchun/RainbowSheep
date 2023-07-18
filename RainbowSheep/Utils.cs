using System;
using System.IO;
using System.Runtime.InteropServices;

namespace RainbowSheep
{
    public class Utils
    {

        public static T FromBinaryReader<T>(BinaryReader reader)
        {
            T theStructure;
            byte[] bytes = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
            return theStructure;
        }

        public static bool Is32Bit(ushort Characteristics)
        {

            UInt16 IMAGE_FILE_32BIT_MACHINE = 0x0100;
            return (IMAGE_FILE_32BIT_MACHINE & Characteristics) == IMAGE_FILE_32BIT_MACHINE;
        }

        public static byte[] Read(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] rawData = new byte[stream.Length];
                stream.Read(rawData, 0, (int)stream.Length);
                stream.Close();

                return rawData;
            }
        }

        public static void MMarshal<T>(int _structLength, T _struct, uint _offset, byte[] pe)
        {
            byte[] _structBytes = new byte[_structLength];

            Array.Copy(RawMarshal(_struct), 0, pe, _offset, Marshal.SizeOf(typeof(T)));

        }

        public static byte[] RawMarshal(object anything)
        {
            int rawsize = Marshal.SizeOf(anything);
            byte[] rawdata = new byte[rawsize];
            GCHandle handle = GCHandle.Alloc(rawdata, GCHandleType.Pinned);
            Marshal.StructureToPtr(anything, handle.AddrOfPinnedObject(), false);
            handle.Free();

            return rawdata;
        }
    }
}
