using System.Collections.Generic;

namespace LorenzoLaFarciola;

public interface IEntityData
{
    void SetEntityTroop(Dictionary<int, CellsImpl> entityTroop);
    Dictionary<int, CellsImpl> GetEntityTroop();
    void AddEntityTroop(int key);
    void RemoveEntityTroop(int key);
    CellsImpl GetCells(int key);
    List<TroopType> GetSelected();
    List<TroopType> GetNotSelected();
    Dictionary<int, TroopType> ChangeNotSelectedTroop();
    void SetClickedToChosen();
    int SelectRandomTroop();
    bool IsMatch(TroopType troop);
    int GetKeyFromTroop(TroopType troop);
    void SetAllChosen();
    int GetTotalTroops();
}