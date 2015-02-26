using System;
using System.IO;

namespace MissionEditor.FileReaderCore
{
    public static class Exts
    {
        public static byte[] ReadBytes(this Stream s, int count)
        {
            var ret = new byte[count];
            s.ReadBytes(ret, 0, count);
            return ret;
        }

        public static void ReadBytes(this Stream s, byte[] buffer, int offset, int count)
        {
            while (count > 0)
            {
                int bytesRead;
                if ((bytesRead = s.Read(buffer, offset, count)) == 0)
                    throw new EndOfStreamException();
                offset += bytesRead;
                count -= bytesRead;
            }
        }

        public static ushort ReadUShort(this Stream s)
        {
            return BitConverter.ToUInt16(s.ReadBytes(2), 0);
        }

        public static int ReadInt(this Stream s)
        {
            return BitConverter.ToInt32(s.ReadBytes(4), 0);
        }

        public static uint ReadUInt(this Stream s)
        {
            return BitConverter.ToUInt32(s.ReadBytes(4), 0);
        }

        public static byte ReadUByte(this Stream s)
        {
            return ReadBytes(s, 1)[0];
        }
    }
}