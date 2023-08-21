using MarcoFrancolini.Base.Model.Internal;


namespace MarcoFrancolini.Base.Model.BaseData;
public class Building
{
    public readonly int MAXLEVEL = 3;
    public readonly int MAXBUILDINGS = 4;
    public readonly int REFUND_TAX_PERCENTAGE = 25;
    public readonly int UPGRADE_TAX_PERCENTAGE = 15;
    public readonly int PRODUCTION_MULTIPLIER_PERCENTAGE = 0;
    public readonly int PRODUCTION_TIME_REDUCTION_PERCENTAGE = 0;

    public BuildingTypes Type { get; set; }
    public int Level { get; set;}
    public long BuildingTime { get; set; }
    public long ProductionTime { get; set; }
    public bool BeingBuilt { get; set; }
    public int BuildingProgress { get; set;}
    public int ProductionProgress { get; set; }
    public Tuple<float, float> StructurePos { get; set;}
    public ISet<Resource> ProductionAmount { get; set;}
    public ISet<Resource> BuildingValue { get; set;}

    public Building(BuildingTypes type, int level, long buildingTime, long productionTime,
        bool beingBuilt, int buildingProgress, int productionProgress, Tuple<float, float> structurePos, ISet<Resource> productionAmount,
        ISet<Resource> buildingValue)
        => (Type, Level, BuildingTime, ProductionTime, BeingBuilt, BuildingProgress,
            ProductionProgress, StructurePos, ProductionAmount, BuildingValue)
        = (type, level, buildingTime, productionTime, beingBuilt, buildingProgress,
            productionProgress, structurePos, productionAmount, buildingValue);
}
