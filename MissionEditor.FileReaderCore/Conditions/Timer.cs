using System;

namespace MissionEditor.FileReaderCore.Conditions
{
    public class Timer : Condition
    {
        public UInt32 Time;
        public byte ComparisonFunction;

        public Timer(byte[] data)
            : base(data)
        {
            Time = BitConverter.ToUInt32(RawData, (int)ByteIndices.Time);
            ComparisonFunction = RawData[(int)ByteIndices.ComparisonFunction];
        }

        public override void WriteData()
        {
            BitConverter.GetBytes(Time).CopyTo(RawData, (int)ByteIndices.Time);
            ComparisonFunction = RawData[(int)ByteIndices.ComparisonFunction];
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            var function = Statics.ComparisonFunctions[ComparisonFunction];
            return string.Format("{0}: TRUE if time is {1} {2}.", condition, function, Time);
        }
        
        public enum ByteIndices
        {
            Time = 0,
            ComparisonFunction = 27
        }
    }
}
