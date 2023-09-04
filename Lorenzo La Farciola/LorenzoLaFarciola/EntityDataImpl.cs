using System;
using System.Collections.Generic;
using System.Linq;

namespace LorenzoLaFarciola;

    public class EntityDataImpl : EntityData
    {
        private readonly int totalTroops;
        private readonly int handTroops;
        private Dictionary<int, CellsImpl> entityTroop;
        private Random random = new Random();

        public EntityDataImpl()
        {
            entityTroop = new Dictionary<int, CellsImpl>();
            handTroops = 5;
            totalTroops = 10;

        for (int i = 0; i < handTroops; i++)
            {
                entityTroop[i] = new CellsImpl(TroopTypeImpl.getRandomTroop(), false);
            }
        }

        public void setEntityTroop(Dictionary<int, CellsImpl> entityTroop)
        {
            this.entityTroop = entityTroop;
        }

        public Dictionary<int, CellsImpl> getEntityTroop()
        {
            return entityTroop;
        }

        public void addEntityTroop(int key)
        {
            entityTroop[key].setClicked(true);
        }

        public void removeEntityTroop(int key)
        {
            entityTroop[key].setClicked(false);
            entityTroop[key].setChosen(false);
        }

        public CellsImpl getCells(int key)
        {
            return entityTroop[key];
        }

        public List<TroopType> getSelected()
        {
            return entityTroop.Values.Where(cell => cell.getClicked()).Select(cell => cell.getTroop()).ToList();
        }

        public List<TroopType> getNotSelected()
        {
            return entityTroop.Values.Where(cell => !cell.getClicked()).Select(cell => cell.getTroop()).ToList();
        }

        public Dictionary<int, TroopType> changeNotSelectedTroop()
        {
            Dictionary<int, TroopType> troopChanged = new Dictionary<int, TroopType>();
            for (int i = 0; i < handTroops; i++)
            {
                if (!entityTroop[i].getClicked())
                {
                    entityTroop[i].setTroop(TroopTypeImpl.getRandomTroop());
                    troopChanged[i] = entityTroop[i].getTroop();
                }
            }
            return troopChanged;
        }

        public void setClickedToChosen()
        {
            foreach (var key in entityTroop)
            {
                if (key.Value.getClicked())
                {
                    key.Value.setChosen(true);
                }
            }
        }

        public int selectRandomTroop()
        {
            List<int> keys = entityTroop.Keys.Where(key => !entityTroop[key].getClicked()).ToList();
            int chosenKey = random.Next(keys.Count);
            return keys[chosenKey];
        }

        public bool isMatch(TroopType troop)
        {
            TroopType? matched = TroopTypeImpl.getNullable(troop);
            return matched.HasValue && getSelected().Contains(matched.Value);
        }

        public int getKeyFromTroop(TroopType troop)
        {
            if (getNotSelected().Contains(troop))
            {
                for (int i = 0; i < handTroops; i++)
                {
                    if (entityTroop[i].getTroop().Equals(troop) && !entityTroop[i].getClicked())
                    {
                        return i;
                    }
                }
            }
        return -1;
        }

        public static List<Nullable<TroopType>> getOrderedField(EntityData playerData, EntityData botData)
        {
        List<Nullable<TroopType>> playerOptionalList = new List<Nullable<TroopType>>();
        List<Nullable<TroopType>> botOptionalList = new List<Nullable<TroopType>>();
        int differenceSize;

        for (int i = 0; i < 8; i++)
        {
            int a = i;
            playerOptionalList.AddRange(playerData.getSelected()
                .Where(x => Array.IndexOf(Enum.GetValues(typeof(TroopType)), x) == a)
                .Select(x => (Nullable<TroopType>)x));
            botOptionalList.AddRange(botData.getSelected()
                .Where(x => x == TroopTypeImpl.getNullable(Enum.GetValues(typeof(TroopType))
                .Cast<TroopType>()
                .OrderBy(t => Array.IndexOf(Enum.GetValues(typeof(TroopType)), t) == a)
                .First()))
                .Select(x => (Nullable<TroopType>)x));
            int b;
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

        int troopsToFill = playerData.getTotalTroops() - playerOptionalList.Count;
        for (int a = 0; a < troopsToFill; a++)
        {
            playerOptionalList.Add(null);
            botOptionalList.Add(null);
        }
        playerOptionalList.AddRange(botOptionalList);
        return playerOptionalList;
    }

        public void setAllChosen()
        {
            foreach (var key in entityTroop)
            {
                key.Value.setChosen(true);
            }
        }

        public List<Nullable<TroopType>> exOrdered(EntityData botData, EntityData playerData)
        {
        List<Nullable<TroopType>> bothOrdered = getOrderedField(playerData, botData);
        List<Nullable<TroopType>> playerOrdered = bothOrdered.GetRange(0, bothOrdered.Count / 2);
        List<Nullable<TroopType>> botOrdered = bothOrdered.GetRange(bothOrdered.Count / 2, bothOrdered.Count);
        List<Nullable<TroopType>> finalPlayer = new List<Nullable<TroopType>>(playerData.getTotalTroops());
        List<Nullable<TroopType>> finalBot = new List<Nullable<TroopType>>(playerData.getTotalTroops());
        int maxPosition = playerData.getTotalTroops() - 1;

        for (int a = 0; a < playerData.getTotalTroops(); a++)
        {
            finalPlayer.Add(null);
            finalBot.Add(null);
        }

        int f = 0;
        for (int i = 0; i < playerOrdered.Count; i++)
        {
            if (playerOrdered[i].HasValue && !TroopTypeImpl.isDefense(playerOrdered[i].Value))
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
            else if (!playerOrdered[i].HasValue && botOrdered[i].HasValue && !TroopTypeImpl.isDefense(botOrdered[i].Value))
            {
                finalBot[maxPosition - f] = botOrdered[i];
                finalPlayer[maxPosition - (f++)] = null;
            }
            else if (!playerOrdered[i].HasValue && botOrdered[i].HasValue && TroopTypeImpl.isDefense(botOrdered[i].Value))
            {
                finalBot[i] = botOrdered[i];
                finalPlayer[i] = null;
            }
        }

        finalPlayer.AddRange(finalBot);
        return finalPlayer;
    }

        public int getTotalTroops()
        {
            return totalTroops;
        }
    }
