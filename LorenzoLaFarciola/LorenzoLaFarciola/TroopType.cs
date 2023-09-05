namespace LorenzoLaFarciola;

using System;
using System.Collections.Generic;
using System.Linq;

public enum TroopType
{
    Axe,
    Sword,
    Hammer,
    Mace,
    AxeDefence,
    SwordDefence,
    HammerDefence,
    MaceDefence
}

public static class TroopTypeImpl
{
    private static readonly Dictionary<TroopType, TroopType> CounterList =
        new Dictionary<TroopType, TroopType>
        {
            { TroopType.Axe, TroopType.AxeDefence },
            { TroopType.Sword, TroopType.SwordDefence },
            { TroopType.Hammer, TroopType.HammerDefence },
            { TroopType.Mace, TroopType.MaceDefence }
        };

    private static readonly Random RnGenerator = new Random();

    public static TroopType GetRandomTroop()
    {
        return Enum.GetValues(typeof(TroopType))
            .Cast<TroopType>()
            .OrderBy(t => RnGenerator.Next())
            .First();
    }

    public static TroopType? GetNullable(this TroopType troopToCheck)
    {
        if (CounterList.ContainsKey(troopToCheck))
        {
            return CounterList[troopToCheck];
        }

        return CounterList.FirstOrDefault(troopEntry => troopEntry.Value == troopToCheck).Key;
    }

    public static bool IsDefense(this TroopType troopType)
    {
        return !CounterList.ContainsKey(troopType);
    }
}
