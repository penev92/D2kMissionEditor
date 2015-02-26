using System;

namespace MissionEditor.FileReaderCore
{
    public class DiplomacyRow : MissionFileItem
    {
        public const int ByteCount = 8;

        public override sealed byte[] RawData { get; set; }

        public DiplomacyRow(byte[] data)
        {
            RawData = new byte[ByteCount];
            Array.Copy(data, RawData, ByteCount);
        }

        public override bool IsBlank()
        {
            throw new System.NotImplementedException("Diplomacy row does not define a method IsBlank()!");
        }

        public override string ToString()
        {
            return string.Join(",", RawData);
        }
    }
}
