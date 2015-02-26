namespace MissionEditor.FileReaderCore.Events
{
    public class MissionFail : Event
    {
        public MissionFail(byte[] data)
            : base(data) { }

        public override string ToString()
        {
            return Statics.EventNames[Type] + PrintConditions();
        }
    }
}
