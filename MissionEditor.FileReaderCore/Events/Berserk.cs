namespace MissionEditor.FileReaderCore.Events
{
    public class Berserk : Event
    {
        public byte FactionIndex;

        public Berserk(byte[] data)
            : base(data)
        {
            FactionIndex = RawData[(int)ByteIndices.FactionIndex];
        }

        public override void WriteData()
        {
            RawData[(int)ByteIndices.FactionIndex] = FactionIndex;
        }

        public override string ToString()
        {
            var type = Statics.EventNames[Type];
            var faction = Statics.FactionNames[FactionIndex];

            return string.Format("{0}: Faction {1} goes berserk!{2}", type, faction, PrintConditions());
        }

        public enum ByteIndices
        {
            FactionIndex = 15
        }
    }
}
