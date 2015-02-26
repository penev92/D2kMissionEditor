namespace MissionEditor.FileReaderCore.Conditions
{
    public class BuildingExists : Condition
    {
        public byte FactionIndex;
        public byte BuildingIndex;

        public BuildingExists(byte[] data)
            : base(data)
        {
            FactionIndex = RawData[(int)ByteIndices.FactionIndex];
            BuildingIndex = RawData[(int)ByteIndices.BuildingIndex];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.FactionIndex] = FactionIndex;
            RawData[(int)ByteIndices.BuildingIndex] = BuildingIndex;
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            var faction = Statics.FactionNames[FactionIndex];
            var building = Statics.GetBuildingNameFromIndex(BuildingIndex);

            return string.Format("{0}: TRUE if the {1} have a {2}.", condition, faction, building);
        }

        public enum ByteIndices
        {
            FactionIndex = 24,
            BuildingIndex = 26
        }
    }
}
