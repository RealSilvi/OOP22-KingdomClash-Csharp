using MarcoFrancolini.Base.Model.BaseData;

namespace MarcoFrancolini.Base.Model.Internal;

public class BuildingTypes
{
    public readonly static BuildingTypes HALL = new(30_000,
        5_000, new HashSet<Resource> 
            { new Resource(ResourceType.WHEAT, 10), new Resource(ResourceType.WOOD, 10) },
        new HashSet<Resource>
            { new Resource(ResourceType.WOOD, 50) , new Resource(ResourceType.WHEAT, 30) });
    public readonly static BuildingTypes LUMBERJACK = new(30_000,
        5_000, new HashSet<Resource> 
            { new Resource(ResourceType.WOOD, 30) },
        new HashSet<Resource>
            { new Resource(ResourceType.WOOD, 50) , new Resource(ResourceType.WHEAT, 30) });
    public readonly static BuildingTypes FARM = new(30_000,
        5_000, new HashSet<Resource> 
            { new Resource(ResourceType.WHEAT, 30) },
        new HashSet<Resource>
            { new Resource(ResourceType.WOOD, 50) , new Resource(ResourceType.WHEAT, 30) });

    public long DefaultBuildTime { get; private set;}
    public long DefaultProductionTime { get; private set;}
    public ISet<Resource> BaseProduction { get; private set;}
    public ISet<Resource> Cost { get; private set;}

    public BuildingTypes(long defaultBuildTime, long defaultProductionTime,
        ISet<Resource> baseProduction, ISet<Resource> cost)
            => (DefaultBuildTime, DefaultProductionTime, BaseProduction, Cost)
            = (defaultBuildTime, defaultProductionTime, baseProduction, cost);
    
    public static IEnumerable<BuildingTypes> Values
    {
        get 
        {
            yield return HALL;
            yield return LUMBERJACK;
            yield return FARM;
        }
    }
}

public interface IBuildingBuilder 
{
    Building MakeStandardBuilding(BuildingTypes type, Tuple<float, float> position, int level);
    Building MakeStandardBuilding(BuildingTypes type, int level);

    public static HashSet<Resource> ApplyIncrementToResourceSet(ISet<Resource> resourceSet,
        int incrementPercentage)
    {
        HashSet<Resource> modifiedSet = Resource.DeepCopySet(resourceSet);
        foreach (Resource resource in modifiedSet)
        {
            resource.Amount = Convert.ToInt32(ApplyIncrementToDouble(resource.Amount, incrementPercentage));
        }
        return modifiedSet;
    }
    private static double ApplyIncrementToDouble(double valueToIncrement,
        int incrementPercentage)
    {
        double increment = valueToIncrement * (incrementPercentage / 100.0);
        return valueToIncrement + increment;
    }
}