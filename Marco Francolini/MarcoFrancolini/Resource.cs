using System.Text;

namespace MarcoFrancolini;
public enum ResourceType
{
    WHEAT,
    WOOD
}
public class Resource
{
    public ResourceType ResourceType { get; set; }
    public int Amount { get; set;}

    public Resource(ResourceType ResourceType, int Amount)
    {
        this.ResourceType = ResourceType;
        this.Amount = Amount;
    }
    
    public Resource(ResourceType ResourceType) : this(ResourceType, 0)
    {
    }
    
    public static string BeautifyToString(HashSet<Resource> resourceSet)
    {
        StringBuilder StringBuilder = new StringBuilder();
        foreach (var resource in resourceSet)
        {
            StringBuilder
                .Append(char.ToUpper(resource.ResourceType.ToString()[0]))
                .Append(resource.ResourceType.ToString().Substring(1).ToLower())
                .Append(": ")
                .Append(resource.Amount)
                .Append('\n');
        }
        
        string beautifiedOutput = StringBuilder.ToString();
        return beautifiedOutput.Trim();
    }
    public static ISet<Resource> CheckAndAddMissingResources(ISet<Resource> ResourceSet)
    {
        foreach (ResourceType ResourceType in Enum.GetValues(typeof(ResourceType)))
    {
        if (!ResourceSet.Any(resource => resource.ResourceType == ResourceType))
        {
            ResourceSet.Add(new Resource(ResourceType));
        }
    }
        return ResourceSet;
    }
    public Resource Clone()
    {
        return new Resource(this.ResourceType, this.Amount);
    }
    public static HashSet<Resource> DeepCopySet(ISet<Resource> resourceSet)
    {
        return resourceSet.Select(resource => resource.Clone()).ToHashSet();
    }

    public override bool Equals(object? otherResource)
    {
        if (otherResource == null)
        {
            return false;
        } 
        if (GetType() == otherResource.GetType()
            && this.ResourceType == ((Resource)otherResource).ResourceType)
        {
            return true;
        }
        return base.Equals(otherResource);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.ResourceType, this.Amount);
    }
}
