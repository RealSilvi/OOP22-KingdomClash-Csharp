

[TestClass]
public class CellsImplTest
{
    [TestMethod]
    public void TestCellsImpl()
    {
        CellsImpl cells = new CellsImpl(TroopType.AXE, true);
        Assert.IsTrue(new CellsImpl(TroopType.AXE, true).Equals(cells));
    }
}