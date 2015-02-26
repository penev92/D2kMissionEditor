namespace MissionEditor.FileReaderCore.Conditions
{
    public class UnitsDestroyed : Condition
    {
        public byte Unknown1;
        public byte FactionIndex;

        public UnitsDestroyed(byte[] data)
            : base(data)
        {
            Unknown1 = RawData[(int)ByteIndices.Unknown1];
            FactionIndex = RawData[(int)ByteIndices.FactionIndex];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.Unknown1] = Unknown1;
            RawData[(int)ByteIndices.FactionIndex] = FactionIndex;
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            var faction = Statics.FactionNames[FactionIndex];
            return string.Format("{0}: TRUE when all {0} units have been destroyed.", condition, faction);
        }

        public enum ByteIndices
        {
            Unknown1 = 8,
            FactionIndex = 24
        }
    }
}
