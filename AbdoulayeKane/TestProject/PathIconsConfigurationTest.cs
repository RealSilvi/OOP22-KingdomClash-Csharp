using AbdoulayeKane;
namespace TestProject;

[TestFixture]
public class PathIconsConfigurationTest
{

        public PathIconsConfiguration PathIconsConfiguration = new PathIconsConfiguration();
        
        [Test]
        public void CheckKey()
        {
                Dictionary<PathIconsConfiguration.BuildingTypes, Dictionary<int, String>> buildings =
                        PathIconsConfiguration.getDictionary();
                Assert.IsTrue(buildings.ContainsKey(PathIconsConfiguration.BuildingTypes.FARM));
                Assert.IsNotEmpty(buildings); 
        }
        
        [Test]
        public void GetBuildings()
        {
                Dictionary<PathIconsConfiguration.BuildingTypes, Dictionary<int, String>> buildings =
                        PathIconsConfiguration.getDictionary();
                Assert.AreEqual(PathIconsConfiguration.GetBuilding(PathIconsConfiguration.BuildingTypes.HALL, 5),
                        buildings[PathIconsConfiguration.BuildingTypes.HALL][1]);
                Assert.AreEqual(PathIconsConfiguration.GetBuilding(PathIconsConfiguration.BuildingTypes.LUMBERJACK, 1),
                        buildings[PathIconsConfiguration.BuildingTypes.LUMBERJACK][1]);
        }
}