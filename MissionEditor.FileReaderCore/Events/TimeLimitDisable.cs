namespace MissionEditor.FileReaderCore.Events
{
    public class TimeLimitDisable : Event
    {
        public TimeLimitDisable(byte[] data)
            : base(data) { }

        public override string ToString()
        {
            return Statics.EventNames[Type] + PrintConditions();
        }
    }
}

