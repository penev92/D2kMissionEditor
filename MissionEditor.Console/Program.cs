using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using MissionEditor.FileReaderCore;

namespace MissionEditor.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            var filePath = @"E:\Work\Programming\C#\OpenRA\Dune2000\Resources\MISSIONS\_A5V1.MIS";

            //var bytes = File.ReadAllBytes(filePath);
            //var mission = new MissionStruct();
            //var m = ByteArrayToStructure(bytes);


            var mission = FileReaderCore.FileReader.ParseMissionFile(filePath);

            FileReaderCore.FileReader.DumpDataToFile(mission, "testDump.txt");

            return;

            var miss = ByteArrayToStructure(File.ReadAllBytes(filePath));

            //var fs = File.Open(filePath, FileMode.Open);
            //var binaryFormatter = new BinaryFormatter();
            //MissionTest mis = (MissionTest)binaryFormatter.Deserialize(fs);

        }

        static MissionTest ByteArrayToStructure(byte[] bytes)
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var stuff = (MissionTest)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(MissionTest));
            handle.Free();
            return stuff;
        }

        object ByteArrayToStructure(byte[] bytearray, object structureObj, int position)
        {
            var length = Marshal.SizeOf(structureObj);
            var ptr = Marshal.AllocHGlobal(length);
            Marshal.Copy(bytearray, 0, ptr, length);
            structureObj = Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(bytearray, position), structureObj.GetType());
            Marshal.FreeHGlobal(ptr);
            return structureObj;
        }   
    }
}
