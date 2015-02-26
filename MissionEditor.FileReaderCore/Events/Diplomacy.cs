namespace MissionEditor.FileReaderCore.Events
{
    public class Diplomacy : Event
    {
        public byte FactionIndex;
        public byte DestinationFactionIndex;
        public byte Allegiance;

        public Diplomacy(byte[] data)
            : base(data)
        {
            FactionIndex = RawData[(int)ByteIndices.FactionIndex];
            DestinationFactionIndex = RawData[(int)ByteIndices.DestinationFactionIndex];
            Allegiance = RawData[(int)ByteIndices.Allegiance];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.FactionIndex] = FactionIndex;
            RawData[(int)ByteIndices.DestinationFactionIndex] = DestinationFactionIndex;
            RawData[(int)ByteIndices.Allegiance] = Allegiance;
        }

        public override string ToString()
        {
            var type = Statics.EventNames[Type];
            var faction1 = Statics.FactionNames[FactionIndex];
            var faction2 = Statics.FactionNames[DestinationFactionIndex];
            
            return string.Format("{0}: {1} changes diplomacy with {2} to {3}.{4}",
                type, faction1, faction2, Allegiance, PrintConditions());
        }

        public enum ByteIndices
        {
            FactionIndex = 15,
            DestinationFactionIndex = 16,
            Allegiance = 17
        }
    }
}
