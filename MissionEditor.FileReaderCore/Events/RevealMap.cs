using System;

namespace MissionEditor.FileReaderCore.Events
{
    public class RevealMap : Event
    {
        public UInt32 CoordinateX;
        public UInt32 CoordinateY;
        public UInt32 RevealRadius;

        public RevealMap(byte[] data)
            : base(data)
        {
            CoordinateX = BitConverter.ToUInt32(RawData, (int)ByteIndices.CoordinateX);
            CoordinateY = BitConverter.ToUInt32(RawData, (int)ByteIndices.CoordinateY);
            RevealRadius = BitConverter.ToUInt32(RawData, (int)ByteIndices.RevealRadius);
        }

        public override void WriteData()
        {
            BitConverter.GetBytes(CoordinateX).CopyTo(RawData, (int)ByteIndices.CoordinateX);
            BitConverter.GetBytes(CoordinateY).CopyTo(RawData, (int)ByteIndices.CoordinateY);
            BitConverter.GetBytes(RevealRadius).CopyTo(RawData, (int)ByteIndices.RevealRadius);
        }

        public override string ToString()
        {
            var type = Statics.EventNames[Type];
            return string.Format("{0}: Reveal shroud and fog in a {1}-cell radius around ({2}, {3}).{4}",
                type, RevealRadius, CoordinateX, CoordinateY, PrintConditions());
        }

        public enum ByteIndices
        {
            CoordinateX = 0,
            CoordinateY = 4,
            RevealRadius = 14
        }
    }
}
