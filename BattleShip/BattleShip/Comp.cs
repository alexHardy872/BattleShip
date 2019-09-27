using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Comp : Player
    {

        public List<string> directions;
        public Comp(string nameIn)
        {
            name = nameIn;
            score = 0;
            directions = new List<string>() { "up", "down", "right", "left" };
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
            while (allShipsSet == false)
            {
                foreach (Ship ship in listShips)
                {
                                 
                    playerShipGrid.BuildGrid();

                    int row = GetRandomNum(19);
                    int col = GetRandomNum(19);

                    bool successfulPlacement;

                    do
                    {
                        string direction = GetRandomDirection();

                        successfulPlacement = PlaceShip(row, col, ship, direction);
                    }
                    while (successfulPlacement == false);
     

                }

                playerShipGrid.BuildGrid();
                allShipsSet = true;

            }


        }


      





        public string GetRandomDirection()
        {
            int random = GetRandomNum(3);
            string direction = directions[random];
            return direction;
        }

        

        public int GetRandomNum(int range)
        {
            Random random = new Random();
            int selection = random.Next(0, range);
            return selection;
        }


        public bool PlaceShip(int row, int col, Ship ship, string direction) // return bool if succedful or not for validation
        {
            switch (direction)
            {
                case "down":
                    if (row + ship.size >= playerShipGrid.stringGrid.GetLength(0))
                    {
                        
                        return false;
                    }
                    else
                    {
                        

                        for (int i = 1; i < ship.size; i++)
                        {
                            if (playerShipGrid.stringGrid[row + i, col] != "[ ]")
                            {
                              
                                return false;
                            }
                            else
                            {
                                playerShipGrid.stringGrid[row + i, col] = ship.key;

                            }

                        }

                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;

                case "up":
                    if (row - ship.size < 0)
                    {
                        
                        return false;
                    }
                    else
                    {
                        

                        for (int i = 1; i < ship.size; i++)
                        {
                            if (playerShipGrid.stringGrid[row - i, col] != "[ ]")
                            {
                                
                                return false;
                            }
                            else
                            {
                                playerShipGrid.stringGrid[row - i, col] = ship.key;

                            }

                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
                case "right":
                    if (col + ship.size >= playerShipGrid.stringGrid.GetLength(1))
                    {
                        return false;
                    }
                    else
                    {
                       

                        for (int i = 1; i < ship.size; i++)
                        {
                            if (playerShipGrid.stringGrid[row, col + i] != "[ ]")
                            {
                                
                                return false;
                            }
                            else
                            {
                                playerShipGrid.stringGrid[row, col + i] = ship.key;

                            }

                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
                case "left":
                    if (col - ship.size < 0)
                    {
                        
                        return false;
                    }
                    else
                    {
                        

                        for (int i = 1; i < ship.size; i++)
                        {
                            if (playerShipGrid.stringGrid[row, col - i] != "[ ]")
                            {
                                
                                return false;
                            }
                            else
                            {
                                playerShipGrid.stringGrid[row, col - i] = ship.key;

                            }

                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
            }

            return true;
        }
    }
}
