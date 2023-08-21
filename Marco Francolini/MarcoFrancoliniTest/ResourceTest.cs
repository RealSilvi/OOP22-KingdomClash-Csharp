using MarcoFrancolini;

namespace MarcoFrancoliniTest;

[TestClass]
public class ResourceTest
{
    [TestMethod]
    public void TestResource()
    {
        Resource resource = new Resource(ResourceType.WHEAT, 10);
        Assert.IsTrue(new Resource(ResourceType.WHEAT, 10).Equals(resource));
    }
}
