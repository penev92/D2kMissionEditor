using System;
using System.Linq;

namespace MissionEditor.FileReaderCore
{
    public class AISection : MissionFileItem
    {
        public const int ByteCount = 7608;
        
        public override sealed byte[] RawData { get; set; }

        public AISection(byte[] data)
        {
            RawData = new byte[ByteCount];
            Array.Copy(data, RawData, ByteCount);
        }

        public override bool IsBlank()
        {
            return RawData.All(t => t == 0);
        }

        public override string ToString()
        {
            // Current implementation until we can actually make use of this
            return string.Empty;
        }
    }
}
