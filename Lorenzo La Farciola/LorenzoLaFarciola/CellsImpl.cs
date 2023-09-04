
    public class CellsImpl : Cells
    {
        private TroopType troop;
        private bool clicked;

        public CellsImpl(TroopType troop, bool clicked)
        {
            this.troop = troop;
            this.clicked = clicked;
        }

        public void setTroop(TroopType troop)
        {
            this.troop = troop;
        }

        public void setClicked(bool clicked)
        {
            this.clicked = clicked;
        }

        public void setChosen(bool chosen)
        {
            if (chosen)
            {
                this.clicked = true;
            }
        }

        public TroopType getTroop()
        {
            return this.troop;
        }

        public bool getClicked()
        {
            return this.clicked;
        }
    }
