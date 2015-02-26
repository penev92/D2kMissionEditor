using System.Linq;

namespace MissionEditor.FileReaderCore.Conditions
{
    public class ConditionFactory
    {
        public static Condition CreateCondition(byte[] data)
        {
            var type = (ConditionType)data[Condition.ConditionTypeByteIndex];
            switch (type)
            {
                case ConditionType.BuildingExists:
                    return new BuildingExists(data);
                case ConditionType.UnitExists:
                    return new UnitExists(data);
                case ConditionType.Interval:
                    return new Interval(data);
                case ConditionType.Timer:
                    return new Timer(data);
                case ConditionType.Casualties:
                    return new Casualties(data);
                case ConditionType.BaseDestroyed:
                    return new BaseDestroyed(data);
                case ConditionType.UnitsDestroyed:
                    return new UnitsDestroyed(data);
                case ConditionType.UnitInTile:
                    return new UnitInTile(data);
                case ConditionType.Cash:
                    return new Cash(data);
                case ConditionType.DummyCondition:
                    return new Dummy(data);
                default:
                    return null;
            }
        }
    }
}
