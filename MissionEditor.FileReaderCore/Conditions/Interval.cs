using System;

namespace MissionEditor.FileReaderCore.Conditions
{
    public class Interval : Condition
    {
        public UInt32 TimeInterval;
        public UInt32 StartDelay;
        public UInt32 RunCount;

        public Interval(byte[] data)
            : base(data)
        {
            TimeInterval = BitConverter.ToUInt32(RawData, (int)ByteIndices.TimeInterval);
            StartDelay = BitConverter.ToUInt32(RawData, (int)ByteIndices.StartDelay);
            RunCount = BitConverter.ToUInt32(RawData, (int)ByteIndices.RunCount);
        }

        public override void WriteData()
        {
            BitConverter.GetBytes(TimeInterval).CopyTo(RawData, (int)ByteIndices.TimeInterval);
            BitConverter.GetBytes(StartDelay).CopyTo(RawData, (int)ByteIndices.StartDelay);
            BitConverter.GetBytes(RunCount).CopyTo(RawData, (int)ByteIndices.RunCount);
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            return string.Format(
                "{0}: TRUE every {1} \"time units\", starting from {2} and repeating {3} times.",
                condition, TimeInterval, StartDelay, RunCount);
        }

        public enum ByteIndices
        {
            TimeInterval = 0,
            StartDelay = 4,
            RunCount = 8
        }
    }
}
