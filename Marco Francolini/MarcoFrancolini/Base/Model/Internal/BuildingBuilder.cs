using MarcoFrancolini.Base.Model.BaseData;

namespace MarcoFrancolini.Base.Model.Internal;
public class BuildingBuilder : IBuildingBuilder
{
    private readonly Dictionary<BuildingTypes, Dictionary<int, Building>> cache;

    public BuildingBuilder ()
    {
        this.cache = new Dictionary<BuildingTypes, Dictionary<int, Building>>();
        foreach (BuildingTypes buildingType in BuildingTypes.Values)
        {
            this.cache[buildingType] = new Dictionary<int, Building>();
        }
    }

    public Building MakeStandardBuilding(BuildingTypes type, Tuple<float, float> position, int level)
    {
        if (cache[type].ContainsKey(level))
        {
            return cache[type][level];
        }

        Building standardizedBuilding = new Building(type,
            level,
            type.DefaultBuildTime,
            type.DefaultProductionTime,
            false,
            0,
            0,
            position,
            type.BaseProduction,
            IBuildingBuilder.ApplyIncrementToResourceSet(type.Cost, level));
        cache[type][level] = standardizedBuilding;
        return standardizedBuilding;
    }

    public Building MakeStandardBuilding(BuildingTypes type, int level)
    {
        return MakeStandardBuilding(type, Tuple.Create(0.0f, 0.0f), level);
    }
}
