using LorenzoLaFarciola;
using NUnit.Framework;

namespace LorenzoLaFarciolaTest;

[TestFixture]
public class EntityDataImplTest
{
    private EntityDataImpl _entityTroopPlayer = null!;
    private EntityDataImpl _entityTroopBot = null!;
    
    [Test, Order(1)]
    public void Initialize()
    {
        _entityTroopPlayer = new EntityDataImpl();
        _entityTroopPlayer.GetCells(0).SetClicked(false);
        _entityTroopPlayer.GetCells(0).SetTroop(TroopType.Axe);
        _entityTroopPlayer.GetCells(1).SetClicked(false);
        _entityTroopPlayer.GetCells(1).SetTroop(TroopType.Sword);
        _entityTroopPlayer.GetCells(2).SetClicked(false);
        _entityTroopPlayer.GetCells(2).SetTroop(TroopType.Hammer);
        _entityTroopPlayer.GetCells(3).SetClicked(false);
        _entityTroopPlayer.GetCells(3).SetTroop(TroopType.Mace);
        _entityTroopPlayer.GetCells(4).SetClicked(false);
        _entityTroopPlayer.GetCells(4).SetTroop(TroopType.AxeDefence);
        
        _entityTroopBot = new EntityDataImpl();
        _entityTroopBot.GetCells(0).SetClicked(false);
        _entityTroopBot.GetCells(0).SetTroop(TroopType.Hammer);
        _entityTroopBot.GetCells(1).SetClicked(false);
        _entityTroopBot.GetCells(1).SetTroop(TroopType.Sword);
        _entityTroopBot.GetCells(2).SetClicked(false);
        _entityTroopBot.GetCells(2).SetTroop(TroopType.Axe);
        _entityTroopBot.GetCells(3).SetClicked(false);
        _entityTroopBot.GetCells(3).SetTroop(TroopType.SwordDefence);
        _entityTroopBot.GetCells(4).SetClicked(false);
        _entityTroopBot.GetCells(4).SetTroop(TroopType.MaceDefence);
    }

    [Test, Order(2)]
    public void TestEntityDataImpl()
    {
        Assert.IsTrue(TroopType.Axe.Equals(_entityTroopPlayer.GetCells(0).GetTroop()));
    }

    [Test, Order(3)]
    public void TestSelected()
    {
        _entityTroopPlayer.GetCells(0).SetClicked(true);
        _entityTroopPlayer.GetCells(1).SetClicked(true);
        List<TroopType> expected = new List<TroopType>();
        expected.Add(TroopType.Axe);
        expected.Add(TroopType.Sword);
        Assert.AreEqual(expected.Count, _entityTroopPlayer.GetSelected().Count);
        CollectionAssert.AreEquivalent(expected, _entityTroopPlayer.GetSelected());
    }
    
    //questa funzione potrebbe anche fallire perchè è presente
    //un assert.AreNotEqual che confronta la differenza tra le truppe.
    //Il cambiamento delle truppe è casuale, di conseguenza, potrebbe
    //capitare che la truppa venga cambiata in un'altra uguale, restituendo errore.
    [Test, Order(4)]
    public void TestChangeNotSelectedTroop()
    {
        _entityTroopPlayer.GetCells(0).SetClicked(true);
        _entityTroopPlayer.GetCells(1).SetClicked(true);
        _entityTroopPlayer.GetCells(2).SetClicked(false);
        _entityTroopPlayer.GetCells(3).SetClicked(false);
        _entityTroopPlayer.GetCells(4).SetClicked(false);

        Dictionary<int, CellsImpl> originalTroop = new Dictionary<int, CellsImpl>();
        for (int i = 0; i < 5; i++)
        {
            TroopType troop = _entityTroopPlayer.GetCells(i).GetTroop();
            bool clicked = _entityTroopPlayer.GetCells(i).GetClicked();
            originalTroop.Add(i, new CellsImpl(troop, clicked));
        }
        Dictionary<int, TroopType> troopChanged = _entityTroopPlayer.ChangeNotSelectedTroop();
        
        Assert.IsTrue(troopChanged.ContainsKey(2) && troopChanged.ContainsKey(3) && troopChanged.ContainsKey(4));
        
        foreach (var key in troopChanged)
        {
            Console.WriteLine("s");
            Console.WriteLine(originalTroop[key.Key].GetTroop());
            Assert.AreNotEqual(originalTroop[key.Key].GetTroop(), key.Value);
            Assert.IsFalse(_entityTroopPlayer.GetCells(key.Key).GetClicked());
        }
    }

    [Test, Order(5)]
    public void TestIsMatch()
    {
        _entityTroopPlayer.GetCells(0).SetClicked(true);
        _entityTroopPlayer.GetCells(1).SetClicked(true);
        
        Assert.IsTrue(_entityTroopPlayer.IsMatch(TroopType.SwordDefence));
        Assert.IsFalse(_entityTroopPlayer.IsMatch(TroopType.Axe));
        Assert.IsFalse(_entityTroopPlayer.IsMatch(TroopType.HammerDefence));
        Assert.IsFalse(_entityTroopPlayer.IsMatch(TroopType.Hammer));
        Assert.IsFalse(_entityTroopPlayer.IsMatch(TroopType.Mace));
    }
    
    [Test, Order(6)]
    public void TestExOrdered()
    {
        _entityTroopPlayer.GetCells(0).SetTroop(TroopType.AxeDefence);
        _entityTroopPlayer.GetCells(1).SetTroop(TroopType.AxeDefence);
        _entityTroopPlayer.GetCells(2).SetTroop(TroopType.Axe);
        _entityTroopPlayer.GetCells(3).SetTroop(TroopType.Mace);
        _entityTroopPlayer.GetCells(4).SetTroop(TroopType.Sword);
        _entityTroopPlayer.GetCells(0).SetClicked(true);
        _entityTroopPlayer.GetCells(1).SetClicked(false);
        _entityTroopPlayer.GetCells(2).SetClicked(true);
        _entityTroopPlayer.GetCells(3).SetClicked(false);
        _entityTroopPlayer.GetCells(4).SetClicked(false);
        
        _entityTroopBot.GetCells(0).SetClicked(false);
        _entityTroopBot.GetCells(1).SetClicked(false);
        _entityTroopBot.GetCells(2).SetClicked(true);
        _entityTroopBot.GetCells(3).SetClicked(true);
        _entityTroopBot.GetCells(4).SetClicked(false);

        List<TroopType?> bothOrdered = _entityTroopPlayer.ExOrdered(_entityTroopBot, _entityTroopPlayer);
        List<TroopType?> pc = bothOrdered.GetRange(0, bothOrdered.Count / 2);
        bothOrdered.RemoveRange(0, bothOrdered.Count / 2);
        List<TroopType?> bc = bothOrdered.GetRange(0, bothOrdered.Count);
        List<TroopType?> expected = new List<TroopType?>();
    
        for (int i = 0; i < bothOrdered.Count * 2; i++)
        {
            expected.Add(null);
        }
    
        expected[0] = TroopType.Axe;
        expected[9] = TroopType.AxeDefence;
        expected[11] = TroopType.SwordDefence;
        expected[19] = TroopType.Axe;

        Assert.AreEqual(expected.GetRange(0, expected.Count / 2), pc);
        expected.RemoveRange(0, expected.Count / 2);
        Assert.AreEqual(expected.GetRange(0, expected.Count), bc);
    }
    
}