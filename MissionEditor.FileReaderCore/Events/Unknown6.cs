using System;

namespace MissionEditor.FileReaderCore.Events
{
    public class Unknown6 : Event
    {
        public byte Unknown1;
        public byte Unknown2;

        public Unknown6(byte[] data)
            : base(data)
        {
            Unknown1 = RawData[(int)ByteIndices.Unknown1];
            Unknown2 = RawData[(int)ByteIndices.Unknown2];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.Unknown1] = Unknown1;
            RawData[(int)ByteIndices.Unknown2] = Unknown2;
        }

        public override string ToString()
        {
            return Statics.EventNames[Type] + PrintConditions();
        }

        public enum ByteIndices
        {
            Unknown1 = 8,
            Unknown2 = 15
        }
    }
}
