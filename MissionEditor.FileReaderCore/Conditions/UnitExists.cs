namespace MissionEditor.FileReaderCore.Conditions
{
    public class UnitExists : Condition
    {
        public byte FactionIndex;
        public byte UnitIndex;

        public UnitExists(byte[] data)
            : base(data)
        {
            FactionIndex = RawData[(int)ByteIndices.FactionIndex];
            UnitIndex = RawData[(int)ByteIndices.UnitIndex];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.FactionIndex] = FactionIndex;
            RawData[(int)ByteIndices.UnitIndex] = UnitIndex;
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            var faction = Statics.FactionNames[FactionIndex];
            var unit = Statics.GetUnitNameFromIndex(UnitIndex);

            return string.Format("{0}: TRUE if the {1} have a {2}.", condition, faction, unit);
        }

        public enum ByteIndices
        {
            FactionIndex = 24,
            UnitIndex = 27
        }
    }
}
