using LorenzoLaFarciola;
using NUnit.Framework;

namespace LorenzoLaFarciolaTest;

[TestFixture]
public class CellsImplTest
{
    [Test]
    public void TestCellsImpl()
    {
        CellsImpl cells = new CellsImpl(TroopType.Axe, true);
        Assert.IsTrue(new CellsImpl(TroopType.Axe, true).Equals(cells));
    }
}