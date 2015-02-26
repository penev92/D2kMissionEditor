using System;
using System.Collections.Generic;
using System.Linq;

namespace MissionEditor.FileReaderCore
{
    public class Event : MissionFileItem
    {
        public const int ByteCount = 72;
        public const int NumberOfMappedConditionsByteIndex = 12;
        public const int EventTypeByteIndex = 13;
        public const int FirstMappedConditionByteIndex = 19;
        public const int MaxMappedConditionsCount = 14;
        public const int FirstMappedConditionRequiredValueByteIndex = 33;

        public readonly EventType Type;

        public override sealed byte[] RawData { get; set; }
        public int MappedConditionCount;

        public Event(byte[] data)
        {
            RawData = new byte[ByteCount];
            Array.Copy(data, RawData, ByteCount);
            Type = (EventType)data[EventTypeByteIndex];
            MappedConditionCount = data[NumberOfMappedConditionsByteIndex];
        }

        public IEnumerable<byte> GetMappedConditions()
        {
            for (var i = 0; i < MappedConditionCount; i++)
                yield return RawData[FirstMappedConditionByteIndex + i];
        }

        public IEnumerable<byte> GetMappedConditionsRequiredValues()
        {
            for (var i = 0; i < MappedConditionCount; i++)
                yield return RawData[FirstMappedConditionRequiredValueByteIndex + i];
        }

        public virtual void WriteData()
        {
            throw new NotImplementedException("Base class Event does not implement method WriteData()!");
        }

        public override bool IsBlank()
        {
            return RawData.All(t => t == 0);
        }

        public override string ToString()
        {
            return string.Empty;
        }

        public string PrintConditions()
        {
            var text = string.Empty;

            var conditions = GetMappedConditions().ToList();
            var conditionValues = GetMappedConditionsRequiredValues().ToList();

            var needsTrue = new List<int>();

            for (var i = 0; i < MappedConditionCount; i++)
                if (conditionValues[i] == 0)
                    needsTrue.Add(conditions[i]);

            if (needsTrue.Any())
                text += string.Format("\n    If conditions {{ {0} }} are TRUE", string.Join(", ", needsTrue));

            var needsFalse = conditions.Where(c => !needsTrue.Contains(c));
            if (needsFalse.Any())
                text += string.Format("\n    If conditions {{ {0} }} are FALSE", string.Join(", ", needsFalse));

            return text;
        }
    }

    public enum EventType
    {
        Reinforcement = 0,
        StarportDelivery = 1,
        Diplomacy = 2,
        Beserk = 4,
        Unknown6 = 6,
        RelatedToFirst50Bytes = 9,
        MissionWin = 10,
        MissionFail = 11,
        RevealMap = 14,
        TimeLimitRelated = 15,
        TimeLimitDisable = 16,
        Message = 17,
        UnitSpawn = 18,
        SetCondition = 19,
        InvalidUnknown
    }
}
