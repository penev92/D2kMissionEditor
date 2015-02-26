namespace MissionEditor.FileReaderCore.Events
{
    public class MissionWin : Event
    {
        public MissionWin(byte[] data)
            : base(data) { }

        public override string ToString()
        {
            return Statics.EventNames[Type] + PrintConditions();
        }
    }
}
