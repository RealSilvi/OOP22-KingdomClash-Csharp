namespace LorenzoLaFarciola;

public interface ICells
{ 
    void SetTroop(TroopType troop); 
    void SetClicked(bool clicked);
    void SetChosen(bool chosen);
    TroopType GetTroop();
    bool GetClicked();
}