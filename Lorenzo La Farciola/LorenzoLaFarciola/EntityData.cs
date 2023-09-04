using System.Collections.Generic;

namespace LorenzoLaFarciola;

    public interface EntityData
    {
        void setEntityTroop(Dictionary<int, CellsImpl> entityTroop);
        Dictionary<int, CellsImpl> getEntityTroop();
        void addEntityTroop(int key);
        void removeEntityTroop(int key);
        CellsImpl getCells(int key);
        List<TroopType> getSelected();
        List<TroopType> getNotSelected();
        Dictionary<int, TroopType> changeNotSelectedTroop();
        void setClickedToChosen();
        int selectRandomTroop();
        bool isMatch(TroopType troop);
        int getKeyFromTroop(TroopType troop);
        void setAllChosen();
        int getTotalTroops();
    }
