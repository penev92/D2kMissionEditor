using System;

namespace MissionEditor.FileReaderCore.Conditions
{
    public class UnitInTile : Condition
    {
        public UInt32 RunCount;
        public UInt32 CoordinateX;
        public UInt32 CoordinateY;

        public UnitInTile(byte[] data)
            : base(data)
        {
            RunCount = BitConverter.ToUInt32(RawData, (int)ByteIndices.RunCount);
            CoordinateX = BitConverter.ToUInt32(RawData, (int)ByteIndices.CoordinateX);
            CoordinateY = BitConverter.ToUInt32(RawData, (int)ByteIndices.CoordinateY);
        }

        public override void WriteData()
        {
            BitConverter.GetBytes(RunCount).CopyTo(RawData, (int)ByteIndices.RunCount);
            BitConverter.GetBytes(CoordinateX).CopyTo(RawData, (int)ByteIndices.CoordinateX);
            BitConverter.GetBytes(CoordinateY).CopyTo(RawData, (int)ByteIndices.CoordinateY);
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            return string.Format("{0}: TRUE when a unit enters tile ({1}, {2}). Run {3} times.",
                condition, CoordinateX, CoordinateY, RunCount);
        }

        public enum ByteIndices
        {
            RunCount = 8,
            CoordinateX = 12,
            CoordinateY = 16
        }
    }
}
