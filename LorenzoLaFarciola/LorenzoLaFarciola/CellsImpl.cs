namespace LorenzoLaFarciola;

public class CellsImpl : ICells
{
    private TroopType _troop;
    private bool _clicked;

    public CellsImpl(TroopType troop, bool clicked)
    {
        _troop = troop;
        _clicked = clicked;
    }

    public void SetTroop(TroopType troop)
    {
        _troop = troop;
    }

    public void SetClicked(bool clicked)
    {
        _clicked = clicked;
    }

    public void SetChosen(bool chosen)
    {
        if (chosen)
        {
            _clicked = true;
        }
    }

    public TroopType GetTroop()
    {
        return _troop;
    }

    public bool GetClicked()
    {
        return _clicked;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is CellsImpl other)
        {
            return _troop == other._troop && _clicked == other._clicked;
        }
        return false;
    }
        
    public override int GetHashCode()
    {
        return HashCode.Combine(_troop, _clicked);
    }
    
}
