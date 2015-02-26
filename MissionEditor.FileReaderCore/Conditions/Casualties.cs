namespace MissionEditor.FileReaderCore.Conditions
{
    public class Casualties : Condition
    {
        public byte CasualtyThreshold;
        public byte Unknown1;
        public byte Unknown2;
        public byte FactionIndex;

        public Casualties(byte[] data)
            : base(data)
        {
            CasualtyThreshold = RawData[(int)ByteIndices.CasualtyThreshold];
            Unknown1 = RawData[(int)ByteIndices.Unknown1];
            Unknown2 = RawData[(int)ByteIndices.Unknown2];
            FactionIndex = RawData[(int)ByteIndices.FactionIndex];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.CasualtyThreshold] = CasualtyThreshold;
            RawData[(int)ByteIndices.Unknown1] = Unknown1;
            RawData[(int)ByteIndices.Unknown2] = Unknown2;
            RawData[(int)ByteIndices.FactionIndex] = FactionIndex;
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            var faction = Statics.FactionNames[FactionIndex];
            return string.Format("{0}: TRUE when the {1} have suffered more than {2} casualties.", condition, faction, CasualtyThreshold);
        }

        public enum ByteIndices
        {
            CasualtyThreshold = 8,
            Unknown1 = 22,
            Unknown2 = 23,
            FactionIndex = 24
        }
    }
}
