using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Comp : Player
    {
        private Random rand;
        private List<string> directions;
        private bool lastMoveHit;
      
        private Tuple<int, int> lastHit;

        public Comp(string nameIn)
       
        {
            name = nameIn;
            rand = new Random(Guid.NewGuid().GetHashCode());
            directions = new List<string>() { "up", "down", "right", "left" };
            
        }

        public override void PositionShips()
        {
            while (allShipsSet == false)
            {
                foreach (Ship ship in listShips)
                {                             
                  //  playerShipGrid.BuildGrid();
                    int row;
                    int col;
                    do
                    {
                        row = GetRandomNum(0, playerShipGrid.BoardSize);
                        col = GetRandomNum(0, playerShipGrid.BoardSize);
                    }
                    while (playerShipGrid.stringGrid[row, col] != "[ ]");
                    bool successfulPlacement;
                    do
                    {
                        string direction = GetRandomDirection();

                        successfulPlacement = PlaceShip(row, col, ship, direction);
                    }
                    while (successfulPlacement == false);
                }
               // playerShipGrid.BuildGrid();
                allShipsSet = true;
            }
        }

        private string GetRandomDirection()
        {
            int random = GetRandomNum(0,directions.Count);
            string direction = directions[random];
            return direction;
        }
   
        private int GetRandomNum(int min, int max)
        {
           int number =  rand.Next(min, max);   
           return number;
        }

        private bool PlaceShip(int row, int col, Ship ship, string direction)
        {
             bool checkBoundries = ShipValidations.QuickCheckBounds(row, col, ship, direction, playerShipGrid.BoardSize) == false ? false : true;
            if (checkBoundries == false)
            {
                return false;
            }
            else
            {
                for (int i = 1; i < ship.size; i++)
                {
                    bool checkForShips = ShipValidations.QuickCheckEmpty(row, col, i, ship, direction, playerShipGrid.stringGrid) == false ? false : true;
                    if (checkForShips == false)
                    { 
                        return false;
                    }
                }
                for (int i = 1; i < ship.size; i++)
                {
                    ShipValidations.NextPosition(row, col, i, ship, direction, playerShipGrid.stringGrid);
                }

                playerShipGrid.stringGrid[row, col] = ship.key;
            }
            return true;
        }

        public override Tuple<int, int> SendAttackCords()
        {
            int row;
            int col;

            do
            {
                row = GetRandomNum(0, playerShipGrid.BoardSize);
                col = GetRandomNum(0, playerShipGrid.BoardSize);           
            }
            while ( playerHitGrid.stringGrid[row, col] != "[ ]");

            return Tuple.Create(row, col);

        }

        public override bool RecieveAttack(Tuple<int, int> attack)
        {
            int row = attack.Item1;
            int col = attack.Item2;

            if (playerShipGrid.stringGrid[row, col] == "[ ]")
            {
                playerShipGrid.stringGrid[row, col] = "[M]";
                return false;
            }
            else
            {
                string shipID = playerShipGrid.stringGrid[row, col];
                playerShipGrid.stringGrid[row, col] = "[X]";
                CheckShipSink(shipID);
                
                          
                return true;
            }


        }

        public override void UpdateHitMap(bool didHit, Tuple<int, int> coords)
        {
            int row = coords.Item1;
            int col = coords.Item2;

            if (didHit == true)
            {
                playerHitGrid.stringGrid[row, col] = "[X]";
                lastHit = coords;
            }
            else
            {
                playerHitGrid.stringGrid[row, col] = "[M]";
                       
            }

            //playerHitGrid.BuildGrid();
        }

        public override bool CheckShipSink(string input)
        {

            for ( int i = 0; i < playerShipGrid.BoardSize; i++)
            {
                for ( int j = 0; j < playerShipGrid.BoardSize;  j++)
                {
                    if (playerShipGrid.stringGrid[i,j] == input)
                    {
                        return false;
                    }


                }
            }
         

            lives -= 1;

           
            string shipName = UI.GetShipName(input);
            UI.Important("YOU SUNK " + name + "'s " + shipName+"!");
                return true;    
        }


       



    }
}
