namespace MissionEditor.FileReaderCore.Conditions
{
    public class Dummy : Condition
    {
        public Dummy(byte[] data)
            : base(data) { }

        public override string ToString()
        {
            return Statics.ConditionNames[(int)Type];
        }
    }
}
