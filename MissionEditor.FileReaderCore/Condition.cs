using System;
using System.Linq;

namespace MissionEditor.FileReaderCore
{
    public class Condition : MissionFileItem
    {
        public const int ByteCount = 28;
        public const int ConditionTypeByteIndex = 25;

        public readonly ConditionType Type;

        public override sealed byte[] RawData { get; set; }

        public Condition(byte[] data)
        {
            RawData = new byte[ByteCount];
            Array.Copy(data, RawData, ByteCount);
            Type = (ConditionType)data[ConditionTypeByteIndex];
        }

        public virtual void WriteData()
        {
            throw new NotImplementedException("Base class Condition does not implement method WriteData()!");
        }

        public override bool IsBlank()
        {
            return RawData.All(t => t == 0);
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }

    public enum ConditionType
    {
        BuildingExists = 0,
        UnitExists = 1,
        Interval = 2,
        Timer = 3,
        Casualties = 4,
        BaseDestroyed = 5,
        UnitsDestroyed = 6,
        UnitInTile = 7,
        Cash = 8,
        DummyCondition = 9,
        Unknown
    }
}
