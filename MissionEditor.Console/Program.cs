using MissionEditor.FileReaderCore;

namespace MissionEditor.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            var filePath = args[0];
            var outputName = args.Length > 1 ? args[1] : "testDump.txt";

            var mission = FileReaderCore.FileReader.ParseMissionFile(filePath);
            FileReaderCore.FileReader.DumpDataToFile(mission, outputName);
        }
    }
}
