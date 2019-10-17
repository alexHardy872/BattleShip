using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Human : Player

    {
        public bool escape;


        public Human(string nameIn)
        {
            name = nameIn;
            escape = false;
            
        }





      



        public override void PositionShips()
        {
            while (allShipsSet == false)
            {
                foreach (Ship ship in listShips)
                {
                    int row;
                    int col;

                    Console.WriteLine(" Here is your Current Board");
                    playerShipGrid.BuildGrid();
                    do
                    {
                        escape = false;
                 
                        Tuple<int,int> coords = GetRowAndCol(ship);
                         row = coords.Item1;
                         col = coords.Item2;

                        bool successfulPlacement;
                        do
                        {
                            string direction = GetDirection(row, col);
                            successfulPlacement = PlaceShip(row, col, ship, direction);
                        }
                        while (successfulPlacement == false && escape == false);
                }
                    while (escape == true) ;
                } 

                playerShipGrid.BuildGrid();

                allShipsSet = true;

            }

        }

    


        private string GetDirection(int row, int col)
        {
            string message = "Starting from point (" + (row) + ", " + (col) + ") " +
                            "In what direction would you like to extend your ship? (Type 'right', 'left', 'up' or 'down') or 'back' to try new coordinates";
            string direction = UI.GetUserInput(message);
            while (direction != "up" && direction != "down" && direction != "right" && direction != "left" && direction != "back") 
            {  
               direction = UI.RetryGetUserInput("Not a valid direction! Try again!");      
            }
            return direction;

        }

      

        private bool PlaceShip(int row, int col, Ship ship, string direction)
        {
            bool checkBoundries = ShipValidations.QuickCheckBounds(row, col, ship, direction, playerShipGrid.BoardSize) == false ? false : true;

            if (checkBoundries == false)
            {
                UI.Error("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row) + ", " + (col));
                return false;
            }
            else
            {
                for (int i = 1; i < ship.size; i++)
                {
                    bool checkForShips = ShipValidations.QuickCheckEmpty(row, col, i, ship, direction, playerShipGrid.stringGrid) == false ? false : true;

                    if (checkForShips == false)
                    {
                        UI.Error("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row) + ", " + (col));
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

 
        private Tuple<int,int> GetRowAndCol(Ship ship)
        {
            bool redoCoords;
            int row;
            int col;
            do
            {
                UI.ShipInfo(ship);

                row = UI.IntGetUserInput("Enter the row");
                col = UI.IntGetUserInput("Enter the collum");

                if (row >= playerShipGrid.BoardSize || col >= playerShipGrid.BoardSize || row < 0 || col < 0)
                {
                    UI.Error("This space does not exist!");
                    redoCoords = true;
                }
                else if (playerShipGrid.stringGrid[row, col] != "[ ]")
                {
                    UI.Error("This space is already taken!");
                    redoCoords = true;
                }
                else
                {
                    redoCoords = false;
                }
            }
            while (redoCoords == true);


            return Tuple.Create(row, col);
        }

        private Tuple<int, int> GetRowAndCol()
        {
            bool redoCoords;
            int row;
            int col;
            do
            {
                row = UI.IntGetUserInput("Enter the row");
                col = UI.IntGetUserInput("Enter the collum");

                if (row >= playerShipGrid.BoardSize || col >= playerShipGrid.BoardSize || row < 0 || col < 0)
                {
                    UI.Error("This space does not exist!");
                    redoCoords = true;
                }
                else if (playerHitGrid.stringGrid[row, col] != "[ ]")
                {
                    UI.Error("You already tried sending an attack to this space!");
                    redoCoords = true;
                }
                else
                {
                    redoCoords = false;
                }
            }
            while (redoCoords == true);
            return Tuple.Create(row, col);
        }


        public override Tuple<int,int> SendAttackCords()
        {    
            Console.WriteLine(name + ", its time to attack! Here are your current strikes");
            playerHitGrid.BuildGrid();
            return GetRowAndCol();
  
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

        public override void UpdateHitMap(bool didHit, Tuple<int,int> Cords)
        {
            int row = Cords.Item1;
            int col = Cords.Item2;

            if (didHit == true)
            {
                playerHitGrid.stringGrid[row, col] = "[X]";
                
            }
            else
            {
                playerHitGrid.stringGrid[row, col] = "[M]";
              
            }

            playerHitGrid.BuildGrid();
        }




        public override bool CheckShipSink(string input)
        {
            for (int i = 0; i < playerShipGrid.BoardSize; i++)
            {
                for (int j = 0; j < playerShipGrid.BoardSize; j++)
                {
                    if (playerShipGrid.stringGrid[i, j] == input)
                    {
                        return false;
                    }

                }
            }

            lives -= 1;
       
            string shipName = UI.GetShipName(input);
            UI.Important("YOU SUNK " + name + "'s " + shipName + "!");
            return true;
        }


      



    }
}
