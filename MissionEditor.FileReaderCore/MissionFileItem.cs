namespace MissionEditor.FileReaderCore
{
    public abstract class MissionFileItem
    {
        public abstract byte[] RawData { get; set; }
        
        public abstract bool IsBlank();
    }
}
