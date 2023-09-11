using AbdoulayeKane;
namespace TestProject;

[TestFixture]
public class CityConfigurationTest
{
    CityConfiguration cityConfiguration = new CityConfiguration();
    
    [Test]
    public void GetHeight()
    {
        
        int height = cityConfiguration.GetHeight();
        Assert.IsTrue(height == 5);
    }

    [Test]
    public void GetWidth()
    {
        int width = cityConfiguration.GetHeight();
        Assert.IsTrue(width == 5);
    }
}