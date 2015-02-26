using System;

namespace MissionEditor.FileReaderCore
{
    [Serializable]
    public class Mission
    {
        public const int FactionCount = 8;
        public const int MaxEventCount = 64;
        public const int MaxConditionCount = 48;

        /// <summary> Tech level per faction </summary>
        public byte[] HouseTechLevel;

        /// <summary> Starting money per faction </summary>
        public int[] StartingMoney;

        public byte[] UnknownRegion1;

        /// <summary> ? per faction </summary>
        public byte[] HouseIndexAllocation;

        /// <summary> AI section per faction </summary>
        public AISection[] AISection;

        /// <summary> DiplomacyRow per faction </summary>
        public DiplomacyRow[] Diplomacy;

        public Event[] Events;
        public Condition[] Conditions;
        public char[] TilesetImageName;
        public char[] TilesetDataName;
        public byte EventCount;
        public byte ConditionCount;
        public int TimeLimit;
        public byte[] UnknownRegion2;

        public string Tileset { get { return new string(TilesetImageName).Replace("\0", ""); } }
        public string TilesetData { get { return new string(TilesetDataName).Replace("\0", ""); } }

        public Mission()
        {
            HouseTechLevel = new byte[FactionCount];
            StartingMoney = new int[FactionCount];
            UnknownRegion1 = new byte[40];
            HouseIndexAllocation = new byte[FactionCount];
            AISection = new AISection[FactionCount];
            Diplomacy = new DiplomacyRow[FactionCount];
            Events = new Event[MaxEventCount];
            Conditions = new Condition[MaxConditionCount];
            TilesetImageName = new char[200];
            TilesetDataName = new char[200];
            UnknownRegion2 = new byte[692];
        }
    }
}
