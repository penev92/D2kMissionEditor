using System;

namespace MissionEditor.FileReaderCore.Events
{
    public class Message : Event
    {
        public UInt32 Unknown;
        public UInt32 MessageIndex;

        public Message(byte[] data)
            : base(data)
        {
            Unknown = BitConverter.ToUInt32(RawData, (int)ByteIndices.Unknown);
            MessageIndex = BitConverter.ToUInt32(RawData, (int)ByteIndices.MessageIndex);
        }
        
        public override void WriteData()
        {
            BitConverter.GetBytes(Unknown).CopyTo(RawData, (int)ByteIndices.Unknown);
            BitConverter.GetBytes(MessageIndex).CopyTo(RawData, (int)ByteIndices.MessageIndex);
        }

        public override string ToString()
        {
            var type = Statics.EventNames[Type];
            return string.Format("{0}: Display message with index {1} to the player.{2}",
                type, MessageIndex, PrintConditions());
        }

        public enum ByteIndices
        {
            Unknown = 8,
            MessageIndex = 68
        }
    }
}
