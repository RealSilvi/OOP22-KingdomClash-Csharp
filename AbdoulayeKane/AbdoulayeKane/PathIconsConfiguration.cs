using Microsoft.VisualBasic.CompilerServices;

namespace AbdoulayeKane;

public class PathIconsConfiguration
{
    public enum BuildingTypes
    {
        FARM,
        LUMBERJACK,
        HALL
        
    }

    private readonly string directoryPath = "OOP22-KingdomClash-Csharp\\AbdoulayeKane\\city\\buildings";
    private Dictionary<BuildingTypes, Dictionary<int, String>> buildings;

    public PathIconsConfiguration() {
        buildings = new Dictionary<BuildingTypes, Dictionary<int, string>>()
        {
            {
                BuildingTypes.FARM, new Dictionary<int, String>()
                {
                    { 1, directoryPath + "farm1.png" },
                    { 2, directoryPath + "farm2.png" },
                    { 3, directoryPath + "farm3.png" }
                }
            },
            {
                BuildingTypes.HALL, new Dictionary<int, string>()
                {
                    { 1, directoryPath + "hall1.png" },
                    { 2, directoryPath + "hall2.png" },
                    { 3, directoryPath + "hall3.png" } 
                }
            },
            {
                BuildingTypes.LUMBERJACK, new Dictionary<int, string>()
                {
                    { 1, directoryPath + "lumberjack1.png" },
                    { 2, directoryPath + "lumberjack2.png" },
                    { 3, directoryPath + "lumberjack3.png" } 
                }
            }

        };

    }
    
    public String GetBuilding( BuildingTypes type, int level){
        if (level > 3 || level < 1)
        {
            return buildings[type][1];
        }
        else
        {
            return buildings[type][level];
        }
    }

    public Dictionary<BuildingTypes, Dictionary<int, String>> getDictionary()
    {
        return buildings;
    }
    
}