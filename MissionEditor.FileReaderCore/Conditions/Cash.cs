using System;

namespace MissionEditor.FileReaderCore.Conditions
{
    public class Cash : Condition
    {
        public UInt32 CashAmmount;

        public Cash(byte[] data)
            : base(data)
        {
            CashAmmount = BitConverter.ToUInt32(RawData, (int)ByteIndices.CashAmmount);
        }

        public override void WriteData()
        {
            BitConverter.GetBytes(CashAmmount).CopyTo(RawData, (int)ByteIndices.CashAmmount);
        }

        public override string ToString()
        {
            var condition = Statics.ConditionNames[(int)Type];
            return string.Format("{0}: TRUE if {1} cash has been collected by the player.", condition, CashAmmount);
        }

        public enum ByteIndices
        {
            CashAmmount = 8
        }
    }
}
