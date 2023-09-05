namespace LorenzoLaFarciola;

public class CellsImpl : ICells
{
    private TroopType _troop;
    private bool _clicked;

    public CellsImpl(TroopType troop, bool clicked)
    {
        this._troop = troop;
        this._clicked = clicked;
    }

    public void SetTroop(TroopType troop)
    {
        this._troop = troop;
    }

    public void SetClicked(bool clicked)
    {
        this._clicked = clicked;
    }

    public void SetChosen(bool chosen)
    {
        if (chosen)
        {
            this._clicked = true;
        }
    }

    public TroopType GetTroop()
    {
        return this._troop;
    }

    public bool GetClicked()
    {
        return this._clicked;
    }
}
