using System;
using System.Collections.Generic;
using System.Linq;

    public enum TroopType
    {
        AXE,
        SWORD,
        HAMMER,
        MACE,
        AXE_DEFENCE,
        SWORD_DEFENCE,
        HAMMER_DEFENCE,
        MACE_DEFENCE
    }

    public static class TroopTypeImpl
    {
        private static readonly Dictionary<TroopType, TroopType> COUNTER_LIST =
            new Dictionary<TroopType, TroopType>
            {
                { TroopType.AXE, TroopType.AXE_DEFENCE },
                { TroopType.SWORD, TroopType.SWORD_DEFENCE },
                { TroopType.HAMMER, TroopType.HAMMER_DEFENCE },
                { TroopType.MACE, TroopType.MACE_DEFENCE }
            };

        private static readonly Random RN_GENERATOR = new Random();

        public static TroopType getRandomTroop()
        {
            return Enum.GetValues(typeof(TroopType))
                .Cast<TroopType>()
                .OrderBy(t => RN_GENERATOR.Next())
                .First();
        }

        public static TroopType? getNullable(this TroopType troopToCheck)
        {
            if (COUNTER_LIST.ContainsKey(troopToCheck))
            {
                return COUNTER_LIST[troopToCheck];
            }

            return COUNTER_LIST.FirstOrDefault(troopEntry => troopEntry.Value == troopToCheck).Key;
        }

        public static bool isDefense(this TroopType troopType)
        {
            return !COUNTER_LIST.ContainsKey(troopType);
        }
    }
