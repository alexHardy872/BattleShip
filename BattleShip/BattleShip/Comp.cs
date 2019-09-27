using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Comp : Player
    {
        public Comp(string nameIn)
        {
            name = nameIn;
            score = 0;
        }


        public override void CreateBoard()
        {
            // MAKE BOARDS

            playerShipGrid = new Grid();
            playerShipGrid.PopulateEmptyGrid();

            playerHitGrid = new Grid();
            playerHitGrid.PopulateEmptyGrid();
        }


        public override void PositionShips()
        {
            // RANDOM NUMBER: SHIPS NEED TO BE SEPERATE SPACES
        }


        /*
        public override void SelectHandState()
        {
            // RANDOMNUMBER
            // INTERPREY FROM LIST
            int random = GetRandomNum();
            string selection = HandStates[random];
            this.HandState = selection;
            SetGesture(selection);
        }

        public int GetRandomNum()
        {
            Random random = new Random();
            int selection = random.Next(0, 4);
            return selection;
        } */
    }
}
