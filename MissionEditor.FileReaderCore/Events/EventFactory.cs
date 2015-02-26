namespace MissionEditor.FileReaderCore.Events
{
    public class EventFactory
    {
        public static Event CreateEvent(byte[] data)
        {
            var type = (EventType)data[Event.EventTypeByteIndex];

            switch (type)
            {
                //case EventType.Reinforcement:
                //    return new Reinforcement(data);
                case EventType.Beserk:
                    return new Berserk(data);
                case EventType.RevealMap:
                    return new RevealMap(data);
                case EventType.Diplomacy:
                    return new Diplomacy(data);
                case EventType.Message:
                    return new Message(data);
                case EventType.MissionFail:
                    return new MissionFail(data);
                case EventType.MissionWin:
                    return new MissionWin(data);
                case EventType.TimeLimitDisable:
                    return new TimeLimitDisable(data);
                case EventType.Unknown6:
                    return new Unknown6(data);
                case EventType.SetCondition:
                    return new SetCondition(data);
                case EventType.Reinforcement:
                    return new Reinforcement(data);
                case EventType.StarportDelivery:
                    return new StarportDelivery(data);
                case EventType.UnitSpawn:
                    return new UnitSpawn(data);
                //case 1:
                //    return new UnitExists(data);
                //case 2:
                //    return new Interval(data);
                //case 3:
                //    return new Timer(data);
                //case 4:
                //    return new Casualties(data);
                //case 5:
                //    return new BaseDestroyed(data);
                //case 6:
                //    return new UnitsDestroyed(data);
                //case 7:
                //    return new UnitInTile(data);
                //case 8:
                //    return new Cash(data);
                //case 9:
                //    return new Dummy(data);
                default:
                    return null;
            }
        }
    }
}
