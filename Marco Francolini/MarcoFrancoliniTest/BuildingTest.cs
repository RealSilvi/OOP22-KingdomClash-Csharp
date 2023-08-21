using MarcoFrancolini.Base.Model.BaseData;
using MarcoFrancolini.Base.Model.Internal;

namespace MarcoFrancoliniTest;
[TestClass]
public class BuildingTest
{
    [TestMethod]
    public void CreateStandardBuilding()
    {
        IBuildingBuilder buildingBuilder = new BuildingBuilder();
        Building createdBuilding = buildingBuilder
            .MakeStandardBuilding(BuildingTypes.FARM, 0);
        Assert.IsNotNull(createdBuilding);
        Assert.AreEqual(createdBuilding.Level, 0);
        Assert.AreEqual(createdBuilding.Type, BuildingTypes.FARM);
        Assert.IsFalse(createdBuilding.BeingBuilt);
        Assert.AreEqual(0, createdBuilding.BuildingProgress);
        Assert.AreEqual(0, createdBuilding.BuildingProgress);
        Assert.IsTrue(BuildingTypes.FARM.Cost.SetEquals(createdBuilding.BuildingValue));
        
    }
}
