namespace LorenzoLaFarciola;

using System;
using System.Collections.Generic;
using System.Linq;

    public class EntityDataImpl : IEntityData
    {
        private readonly int _totalTroops;
        private readonly int _handTroops;
        private Dictionary<int, CellsImpl> _entityTroop;
        private readonly Random _random = new Random();

        public EntityDataImpl()
        {
            _entityTroop = new Dictionary<int, CellsImpl>();
            _handTroops = 5;
            _totalTroops = 10;

        for (int i = 0; i < _handTroops; i++)
            {
                _entityTroop[i] = new CellsImpl(TroopTypeImpl.GetRandomTroop(), false);
            }
        }

        public void SetEntityTroop(Dictionary<int, CellsImpl> entityTroop)
        {
            this._entityTroop = entityTroop;
        }

        public Dictionary<int, CellsImpl> GetEntityTroop()
        {
            return _entityTroop;
        }

        public void AddEntityTroop(int key)
        {
            _entityTroop[key].SetClicked(true);
        }

        public void RemoveEntityTroop(int key)
        {
            _entityTroop[key].SetClicked(false);
            _entityTroop[key].SetChosen(false);
        }

        public CellsImpl GetCells(int key)
        {
            return _entityTroop[key];
        }

        public List<TroopType> GetSelected()
        {
            return _entityTroop.Values.Where(cell => cell.GetClicked()).Select(cell => cell.GetTroop()).ToList();
        }

        public List<TroopType> GetNotSelected()
        {
            return _entityTroop.Values.Where(cell => !cell.GetClicked()).Select(cell => cell.GetTroop()).ToList();
        }

        public Dictionary<int, TroopType> ChangeNotSelectedTroop()
        {
            Dictionary<int, TroopType> troopChanged = new Dictionary<int, TroopType>();
            for (int i = 0; i < _handTroops; i++)
            {
                if (!_entityTroop[i].GetClicked())
                {
                    TroopType newTroop = TroopTypeImpl.GetRandomTroop();
                    _entityTroop[i].SetTroop(newTroop);
                    troopChanged[i] = newTroop;
                }
            }
            return troopChanged;
        }

        public void SetClickedToChosen()
        {
            foreach (var key in _entityTroop)
            {
                if (key.Value.GetClicked())
                {
                    key.Value.SetChosen(true);
                }
            }
        }

        public int SelectRandomTroop()
        {
            List<int> keys = _entityTroop.Keys.Where(key => !_entityTroop[key].GetClicked()).ToList();
            int chosenKey = _random.Next(keys.Count);
            return keys[chosenKey];
        }

        public bool IsMatch(TroopType troop)
        {
            TroopType? matched = TroopTypeImpl.GetNullable(troop);
            return matched.HasValue && GetSelected().Contains(matched.Value);
        }

        public int GetKeyFromTroop(TroopType troop)
        {
            if (!GetNotSelected().Contains(troop)) return -1;
            for (int i = 0; i < _handTroops; i++)
            {
                if (_entityTroop[i].GetTroop().Equals(troop) && !_entityTroop[i].GetClicked())
                {
                    return i;
                }
            }
            return -1;
        }

        private static List<TroopType?> GetOrderedField(IEntityData playerData, IEntityData botData)
        {
        List<TroopType?> playerOptionalList = new List<TroopType?>();
        List<TroopType?> botOptionalList = new List<TroopType?>();

        for (int i = 0; i < 8; i++)
        {
            int a = i;
            playerOptionalList.AddRange(playerData.GetSelected()
                .Where(x => Array.IndexOf(Enum.GetValues(typeof(TroopType)), x) == a)
                .Select(x => (TroopType?)x));
            Nullable<TroopType> troopCurrent = (Nullable<TroopType>)Enum.GetValues(typeof(TroopType)).GetValue(a);
            TroopType troopNullable = TroopTypeImpl.GetNullable(troopCurrent!.Value)!.Value;
            botOptionalList.AddRange(botData.GetSelected()
                .Where(x => x == troopNullable)
                .Select(x => (TroopType?)x));
            int b;
            int differenceSize;
            if (playerOptionalList.Count < botOptionalList.Count)
            {
                differenceSize = botOptionalList.Count - playerOptionalList.Count;
                for (b = 0; b < differenceSize; b++)
                {
                    playerOptionalList.Add(null);
                }
            }
            else if (playerOptionalList.Count > botOptionalList.Count)
            {
                differenceSize = playerOptionalList.Count - botOptionalList.Count;
                for (b = 0; b < differenceSize; b++)
                {
                    botOptionalList.Add(null);
                }
            }
        }

        int troopsToFill = playerData.GetTotalTroops() - playerOptionalList.Count;
        for (int a = 0; a < troopsToFill; a++)
        {
            playerOptionalList.Add(null);
            botOptionalList.Add(null);
        }
        playerOptionalList.AddRange(botOptionalList);
        return playerOptionalList;
    }

        public void SetAllChosen()
        {
            foreach (var key in _entityTroop)
            {
                key.Value.SetChosen(true);
            }
        }

        public List<TroopType?> ExOrdered(IEntityData botData, IEntityData playerData)
        {
        List<TroopType?> bothOrdered = GetOrderedField(playerData, botData);
        List<TroopType?> playerOrdered = bothOrdered.GetRange(0, bothOrdered.Count / 2);
        bothOrdered.RemoveRange(0, bothOrdered.Count / 2);
        List<TroopType?> botOrdered = bothOrdered.GetRange(0, bothOrdered.Count);
        List<TroopType?> finalPlayer = new List<TroopType?>(playerData.GetTotalTroops());
        List<TroopType?> finalBot = new List<TroopType?>(playerData.GetTotalTroops());
        int maxPosition = playerData.GetTotalTroops() - 1;

        for (int a = 0; a < playerData.GetTotalTroops(); a++)
        {
            finalPlayer.Add(null);
            finalBot.Add(null);
        }

        int f = 0;
        for (int i = 0; i < playerOrdered.Count; i++)
        {
            if (playerOrdered[i].HasValue && !TroopTypeImpl.IsDefense(playerOrdered[i]!.Value))
            {
                finalPlayer[i] = playerOrdered[i];
                if (botOrdered[i].HasValue)
                {
                    finalBot[i] = botOrdered[i];
                }
                else
                {
                    finalBot[i] = null;
                }
            }
            else if (playerOrdered[i].HasValue)
            {
                finalPlayer[maxPosition - f] = playerOrdered[i];
                if (botOrdered[i].HasValue)
                {
                    finalBot[maxPosition - (f++)] = botOrdered[i];
                }
                else
                {
                    finalBot[maxPosition - (f++)] = null;
                }
            }
            else if (!playerOrdered[i].HasValue && botOrdered[i].HasValue && !TroopTypeImpl.IsDefense(botOrdered[i]!.Value))
            {
                finalBot[maxPosition - f] = botOrdered[i];
                finalPlayer[maxPosition - (f++)] = null;
            }
            else if (!playerOrdered[i].HasValue && botOrdered[i].HasValue && TroopTypeImpl.IsDefense(botOrdered[i]!.Value))
            {
                finalBot[i] = botOrdered[i];
                finalPlayer[i] = null;
            }
        }

        finalPlayer.AddRange(finalBot);
        return finalPlayer;
    }

        public int GetTotalTroops()
        {
            return _totalTroops;
        }
        
    }
