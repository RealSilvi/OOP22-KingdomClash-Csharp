
[TestClass]
public class EntityDataImplTest
{
    [TestMethod]
    public void TestEntityData()
    {
        EntityData entityTroops = new EntityDataImpl();
        Assert.IsTrue(new CellsImpl(TroopType.AXE, true).Equals(cells));
    }
}