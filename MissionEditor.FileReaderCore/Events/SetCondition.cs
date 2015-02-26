using System;

namespace MissionEditor.FileReaderCore.Events
{
    public class SetCondition : Event
    {
        public byte ConditionValue;
        public byte ConditionIndexIndex;

        public SetCondition(byte[] data)
            : base(data)
        {
            ConditionValue = RawData[(int)ByteIndices.ConditionValueIndex];
            ConditionIndexIndex = RawData[(int)ByteIndices.ConditionIndexIndex];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.ConditionValueIndex] = ConditionValue;
            RawData[(int)ByteIndices.ConditionIndexIndex] = ConditionIndexIndex;
        }

        public override string ToString()
        {
            var type = Statics.EventNames[Type];
            var value = ConditionValue == 1;

            return string.Format("{0} {1}'s value to {2}.{3}", type, ConditionIndexIndex, value, PrintConditions());
        }

        public enum ByteIndices
        {
            ConditionValueIndex = 8,
            ConditionIndexIndex = 15
        }
    }
}
