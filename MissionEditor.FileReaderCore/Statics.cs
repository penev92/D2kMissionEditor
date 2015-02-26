using System.Collections.Generic;

namespace MissionEditor.FileReaderCore
{
    public static class Statics
    {
        public static readonly char[] ComparisonFunctions = { '>', '<', '=', '%' };

        public static readonly string[] FactionNames =
            {
                "Atreides",
                "Harkonnen",
                "Ordos",
                "Corrino",
                "Fremen",
                "Smugglers",
                "Mercenaries",
                "Neutral"
            };

        // String array because fetching by index works
        public static readonly string[] ConditionNames =
            {
                "Building Exists",
                "Unit Exists",
                "Interval",
                "Timer",
                "Casualties",
                "Base Destroyed",
                "Units Destroyed",
                "Unit In Tile",
                "Cash",
                "Dummy Condition",
                "Unknown"
            };

        // Dictionary because there are indices whose meaning we don't know and we skip them
        public static readonly Dictionary<EventType, string> EventNames = new Dictionary<EventType, string>()
            {
                {EventType.Reinforcement, "Reinforcement"},
                {EventType.StarportDelivery, "Starport Delivery"},
                {EventType.Diplomacy, "Diplomacy"},
                {EventType.Beserk, "Beserk"},
                {EventType.Unknown6, "Unknown6"},
                {EventType.MissionWin, "Mission Win"},
                {EventType.MissionFail, "Mission Fail"},
                {EventType.RevealMap, "Reveal Map"},
                {EventType.TimeLimitDisable, "Time Limit Disable"},
                {EventType.Message, "Message"},
                {EventType.UnitSpawn, "Unit Spawn"},
                {EventType.SetCondition, "Set Condition"},
            };

        static readonly string[] UnitNames =
            {
                "Light Infantry",
                "Trooper",
                "Engineer",
                "Thumper",
                "Sardaukar",
                "Trike",
                "Raider",
                "Quad",
                "Harvester",
                "A Combat Tank",
                "H Combat Tank",
                "O Combat Tank",
                "MCV",
                "Missile Tank",
                "Deviator",
                "Seige Tank",
                "Sonic Tank",
                "Devastator",
                "Carryall",
                "A Carryall",
                "Ornithopter (useless)",
                "Stealth Fremen",
                "Fremen",
                "Saboteur",
                "Death Hand Missle",
                "Glitched Unit",
                "Frigate (starport)",
                "Grenadier",
                "Stealth Raider",
                "MP Sardaukar"
            };

        static readonly string[] BuildingNames =
            {
                "Atreides Construction Yard",
                "Harkonnen Construction Yard",
                "Ordos Construction Yard",
                "Imperial Construction Yard",
                "Atreides Concrete",
                "Harkonnen Concrete",
                "Ordos Concrete",
                "Atreides Test Concrete",
                "Harkonnen Test Concrete",
                "Ordos Test Concrete",
                "Atreides Wind Trap",
                "Harkonnen Wind Trap",
                "Ordos Wind Trap",
                "Atreides Barracks",
                "Harkonnen Barracks",
                "Ordos Barracks",
                "Fremen Barracks",
                "Atreides Wall",
                "Harkonnen Wall",
                "Ordos Wall",
                "Atreides Refinery",
                "Harkonnen Refinery",
                "Ordos Refinery",
                "Atreides Medium Gun Turret",
                "Harkonnen Medium Gun Turret",
                "Ordos Medium Gun Turret",
                "Atreides Outpost",
                "Harkonnen Outpost",
                "Ordos Outpost",
                "Atreides Large Gun Turret",
                "Harkonnen Large Gun Turret",
                "Ordos Large Gun Turret",
                "Atreides High Tech Factory",
                "Harkonnen High Tech Factory",
                "Ordos High Tech Factory",
                "Atreides Light Factory",
                "Harkonnen Light Factory",
                "Ordos Light Factory",
                "Atreides Silo",
                "Harkonnen Silo",
                "Ordos Silo",
                "Atreides Heavy Factory",
                "Harkonnen Heavy Factory",
                "Ordos Heavy Factory",
                "Mercenary Heavy Factory",
                "Imperial Heavy Factory",
                "Atreides Star Port",
                "Harkonnen Star Port",
                "Ordos Star Port",
                "Smuggler Star Port",
                "Atreides Repair Pad",
                "Harkonnen Repair Pad",
                "Ordos Repair Pad",
                "Atreides Research Centre",
                "Harkonnen Research Centre",
                "Ordos Research Centre",
                "Atreides Palace",
                "Harkonnen Palace",
                "Ordos Palace",
                "Imperial Palace",
                "Special Harkonnen Outpost",
                "Special Ordos Outpost"
            };

        public static string GetUnitNameFromIndex(int index)
        {
            if (index >= 0 && index < UnitNames.Length)
                return UnitNames[index];

            return "Invalid";
        }

        public static string GetBuildingNameFromIndex(int index)
        {
            if (index >= 0 && index < BuildingNames.Length)
                return BuildingNames[index];

            return "Invalid";
        }
    }
}
