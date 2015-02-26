using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MissionEditor.FileReaderCore.Conditions;
using MissionEditor.FileReaderCore.Events;

namespace MissionEditor.FileReaderCore
{
    public static class FileReader
    {
        public static Mission ParseMissionFile(string filePath)
        {
            var mission = ReadFile(filePath);
            mission = FixUp(mission);

            return mission;
        }

        static Mission ReadFile(string filePath)
        {
            var mission = new Mission();

            var fileStream = new FileStream(filePath, FileMode.Open);
            var binaryReader = new BinaryReader(fileStream);

            // 1. House Tech level
            binaryReader.Read(mission.HouseTechLevel, 0, mission.HouseTechLevel.Length);

            // 2. Starting money
            for (var i = 0; i < mission.StartingMoney.Length; i++)
                mission.StartingMoney[i] = binaryReader.ReadInt32();

            // 3. Unknown region of 40 bytes
            binaryReader.Read(mission.UnknownRegion1, 0, mission.UnknownRegion1.Length);

            // 4. House index allocation
            binaryReader.Read(mission.HouseIndexAllocation, 0, mission.HouseIndexAllocation.Length);

            // 5. AI Section
            for (var i = 0; i < mission.AISection.Length; i++)
                mission.AISection[i] = new AISection(binaryReader.ReadBytes(AISection.ByteCount));

            // 6. Diplomacy
            for (var i = 0; i < mission.Diplomacy.Length; i++)
                mission.Diplomacy[i] = new DiplomacyRow(binaryReader.ReadBytes(DiplomacyRow.ByteCount));

            // 7. Events
            for (var i = 0; i < mission.Events.Length; i++)
                mission.Events[i] = EventFactory.CreateEvent(binaryReader.ReadBytes(Event.ByteCount));

            // 8. Conditions
            for (var i = 0; i < mission.Conditions.Length; i++)
                mission.Conditions[i] = ConditionFactory.CreateCondition(binaryReader.ReadBytes(Condition.ByteCount));

            // 9. Tileset image name
            binaryReader.Read(mission.TilesetImageName, 0, mission.TilesetImageName.Length);

            // 10. Tileset data file name
            binaryReader.Read(mission.TilesetDataName, 0, mission.TilesetDataName.Length);

            // 11. Active events count
            mission.EventCount = binaryReader.ReadByte();

            // 12. Active conditions count
            mission.ConditionCount = binaryReader.ReadByte();

            // 13. Time limit
            mission.TimeLimit = binaryReader.ReadInt32();

            // 14. Unknown region of remaining bytes
            binaryReader.Read(mission.UnknownRegion2, 0, mission.UnknownRegion2.Length);

            binaryReader.Close();
            fileStream.Close();

            return mission;
        }

        static Mission FixUp(Mission mis)
        {
            var mission = new Mission
                {
                    AISection = mis.AISection,
                    ConditionCount = mis.ConditionCount,
                    Diplomacy = mis.Diplomacy,
                    EventCount = mis.EventCount,
                    HouseIndexAllocation = mis.HouseIndexAllocation,
                    HouseTechLevel = mis.HouseTechLevel,
                    StartingMoney = mis.StartingMoney,
                    TilesetDataName = mis.TilesetDataName,
                    TilesetImageName = mis.TilesetImageName,
                    TimeLimit = mis.TimeLimit,
                    UnknownRegion1 = mis.UnknownRegion1,
                    UnknownRegion2 = mis.UnknownRegion2,
                    Conditions = new Condition[Mission.MaxConditionCount],
                    Events = new Event[Mission.MaxEventCount]
                };

            for (var i = 0; i < mission.Conditions.Length; i++)
                if (i < mission.ConditionCount)
                    mission.Conditions[i] = mis.Conditions[i];

            for (var i = 0; i < mission.Events.Length; i++)
                if (i < mission.EventCount)
                    mission.Events[i] = mis.Events[i];

            return mission;
        }

        public static void DumpDataToFile(Mission fileInfo, string filePath)
        {
            var stringBuilder = new StringBuilder();

            PrintPerHouse("Tech levels", fileInfo.HouseTechLevel, stringBuilder);
            PrintPerHouse("Starting money", fileInfo.StartingMoney, stringBuilder);
            PrintPerHouse("House allocation index", fileInfo.HouseIndexAllocation, stringBuilder);
            PrintPerHouse("AI Section", fileInfo.AISection, stringBuilder);
            PrintPerHouse("Diplomacy", fileInfo.Diplomacy, stringBuilder);

            PrintAsList("Events", fileInfo.Events, fileInfo.EventCount, stringBuilder);
            PrintAsList("Conditions", fileInfo.Conditions, fileInfo.ConditionCount, stringBuilder);

            PrintValue("Tileset", fileInfo.Tileset, stringBuilder);
            PrintValue("Tileset Data", fileInfo.TilesetData, stringBuilder);
            PrintValue("Time limit", fileInfo.TimeLimit, stringBuilder);

            File.WriteAllText(filePath, stringBuilder.ToString());
        }

        static void PrintPerHouse<T>(string sectionTitle, IList<T> values, StringBuilder stringBuilder)
        {
            var index = 0;

            stringBuilder.AppendFormat("---------------------------------------------------------------------------{0}{0}", Environment.NewLine);
            stringBuilder.AppendFormat("{0}:{1}{1}", sectionTitle, Environment.NewLine);

            stringBuilder.Append("Atreides: ");
            stringBuilder.AppendLine(values[index++].ToString());

            stringBuilder.Append("Harkonnen: ");
            stringBuilder.AppendLine(values[index++].ToString());

            stringBuilder.Append("Ordos: ");
            stringBuilder.AppendLine(values[index++].ToString());

            stringBuilder.Append("Corrino: ");
            stringBuilder.AppendLine(values[index++].ToString());

            stringBuilder.Append("Fremen: ");
            stringBuilder.AppendLine(values[index++].ToString());

            stringBuilder.Append("Smugglers: ");
            stringBuilder.AppendLine(values[index++].ToString());

            stringBuilder.Append("Mercenaries: ");
            stringBuilder.AppendLine(values[index++].ToString());

            stringBuilder.Append("Creeps: ");
            stringBuilder.AppendLine(values[index].ToString());
            stringBuilder.AppendLine();
        }

        static void PrintAsList<T>(string sectionTitle, IList<T> values, int valuesCount, StringBuilder stringBuilder)
        {
            stringBuilder.AppendFormat("---------------------------------------------------------------------------{0}{0}", Environment.NewLine);
            stringBuilder.AppendFormat("{0}: ({1} active){2}{2}", sectionTitle, valuesCount, Environment.NewLine);

            for (var i = 0; i < valuesCount; i++)
                if (values[i] != null)
                    stringBuilder.AppendLine(string.Format("{0}. {1}", i, values[i]));

            stringBuilder.AppendLine();
        }

        static void PrintValue<T>(string sectionTitle, T value, StringBuilder stringBuilder)
        {
            stringBuilder.AppendFormat("---------------------------------------------------------------------------{0}{0}", Environment.NewLine);
            stringBuilder.AppendFormat("{0}:{2}{2}{1}{2}{2}", sectionTitle, value, Environment.NewLine);
        }
    }
}
