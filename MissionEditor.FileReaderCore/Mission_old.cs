using System;
using System.IO;

namespace MissionEditor.FileReaderCore
{
    public class Mission_old
    {
        /// <summary> Tech level per faction </summary>
        public byte[] HouseTechLevel;
        /// <summary> Starting money per faction </summary>
        public int[] StartingMoney;
        public byte[] UnknownRegion1;
        /// <summary> ? per faction </summary>
        public byte[] HouseIndexAllocation;
        /// <summary> AI section per faction? </summary>
        public AISection[] AISection;
        /// <summary> DiplomacyRow per faction </summary>
        public DiplomacyRow[] Diplomacy;
        public Event[] events = new Event[64];
        public Condition[] conditions = new Condition[48];
        public byte[] tilesetImageName = new byte[200];
        public byte[] tilesetDataName = new byte[200];
        public byte eventCount;
        public byte conditionCount;        
        public Int32 timeLimit;
        public byte[] unknownRegion4 = new byte[692];

        //public void LoadFromFile(string filename)
        //{
        //    var fs = new FileStream(filename, FileMode.Open);
        //    var br = new BinaryReader(fs);

        //    br.Read(houseTechLevel, 0, houseTechLevel.Length);

        //    for (var i = 0; i < startingMoney.Length; i++)
        //    {
        //        startingMoney[i] = br.ReadInt32();
        //    }

        //    br.Read(unknownRegion1, 0, unknownRegion1.Length);
        //    br.Read(houseIndexAllocation, 0, houseIndexAllocation.Length);

        //    for (var i = 0; i < 8; i++)
        //    {
        //        for (var j = 0; j < 7608; j++)
        //        {
        //            ai[i, j] = br.ReadByte();
        //        }
        //    }

        //    for (var i = 0; i < 8; i++)
        //    {
        //        for (var j = 0; j < 8; j++)
        //        {
        //            diplomacy[i, j] = br.ReadByte();
        //        }
        //    }

        //    for (var i = 0; i < events.Length; i++)
        //    {
        //        events[i] = new Event();
        //        events[i].raw = br.ReadBytes(72);
        //    }

        //    for (var i = 0; i < conditions.Length; i++)
        //    {
        //        conditions[i] = new Condition();
        //        conditions[i].raw = br.ReadBytes(28);
        //    }

        //    br.Read(tilesetImageName, 0, tilesetImageName.Length);
        //    br.Read(tilesetDataName, 0, tilesetDataName.Length);

        //    eventCount = br.ReadByte();
        //    conditionCount = br.ReadByte();
        //    timeLimit = br.ReadInt32(); // Signed
        //    br.Read(unknownRegion4, 0, unknownRegion4.Length);

        //    br.Close();
        //    fs.Close();
        //}

        //public void SaveToFile(string filename)
        //{
        //    var fs = new FileStream(filename, FileMode.Create);
        //    var bw = new BinaryWriter(fs);
        //    bw.Write(houseTechLevel);

        //    for (var i = 0; i < startingMoney.Length; i++)
        //    {
        //        bw.Write(startingMoney[i]);
        //    }

        //    bw.Write(unknownRegion1);
        //    bw.Write(houseIndexAllocation);

        //    for (var i = 0; i < 8; i++)
        //    {
        //        for (var j = 0; j < 7608; j++)
        //        {
        //            bw.Write(ai[i, j]);
        //        }
        //    }

        //    for (var i = 0; i < 8; i++)
        //    {
        //        for (var j = 0; j < 8; j++)
        //        {
        //            bw.Write(diplomacy[i, j]);
        //        }
        //    }       

        //    for (var i = 0; i < events.Length; i++)
        //    {
        //        bw.Write(events[i].raw);
        //    }

        //    for (var i = 0; i < conditions.Length; i++)
        //    {
        //        bw.Write(conditions[i].raw);
        //    }

        //    bw.Write(tilesetImageName);
        //    bw.Write(tilesetDataName);

        //    bw.Write(eventCount);
        //    bw.Write(conditionCount);
        //    bw.Write(timeLimit);
        //    bw.Write(unknownRegion4);

        //    bw.Close();
        //    fs.Close();
        //}

        public static string GetEventDescriptionFromIndex(int index)
        {
            switch (index)
            {
                case 0: return "Reinforcement";
                case 1: return "Starport Delivery";
                case 2: return "Diplomacy";
                case 4: return "Beserk";
                case 6: return "Unknown6";
                case 9: return "Related to first 50 bytes";
                case 10: return "Mission Win";
                case 11: return "Mission Fail";
                case 14: return "Reveal Map";
                case 15: return "Time Limit Related";
                case 16: return "Time Limit Disable";
                case 17: return "Message";
                case 18: return "Unit Spawn";
                case 19: return "Set Condition";
                default: return "Invalid Unknown";
            }
        }

        public static string GetConditionDescriptionFromIndex(int index)
        {
            switch (index)
            {
                case 0: return "BuildingExists";
                case 1: return "UnitExists";
                case 2: return "Interval";
                case 3: return "Timer";
                case 4: return "Casualties";
                case 5: return "BaseDestroyed";
                case 6: return "UnitsDestroyed";
                case 7: return "Unit In Tile";
                case 8: return "Cash";
                case 9: return "DummyCondition";
                default: return "Unknown";
            }
        }
    }
}
