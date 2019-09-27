using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Human : Player

    {



        public Human(string nameIn)
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




        // DIsplay grid

        // set ship1

        // display grid

        // set ship 2

        // display grid

            // set ship 3

            // display grid


        public override void PositionShips()
        {




            while (allShipsSet == false)
            {
             

                
                foreach (Ship ship in listShips)
                {
                    int row;
                    int col;


                    Console.WriteLine("Here is your Current Board");
                    playerShipGrid.BuildGrid();

                    do
                    {
                        Console.WriteLine("Enter Coordinates for an open position to place your " + ship.name);
                        Console.WriteLine("( a " + ship.name + " takes up " + ship.size + " spaces)");

                        // is space open? (!= = "[ ]"

                        Console.WriteLine("Enter the row"); /// maybe use letters and number system to input D17 type deal. also validation?
                        row = (Int32.Parse(Console.ReadLine())-1);
                        Console.WriteLine("Enter the collum");
                        col = (Int32.Parse(Console.ReadLine())-1);


                        if (row > 20 || col > 20 || row < 0 || col < 0 || playerShipGrid.stringGrid[row, col] != "[ ]")
                        {
                            Console.WriteLine("This space is already taken or does not exist!");
                        }
                    }
                    while ( row > 20 || col > 20 || row < 0 || col < 0 || playerShipGrid.stringGrid[row, col] != "[ ]");



                    bool successfulPlacement;


                    do
                    {
                        string direction = GetDirection(row, col);

                        successfulPlacement = PlaceShip(row, col, ship, direction);
                    }
                    while (successfulPlacement == false);


                  


                    // set ship

                // validation





                } // end of for each iteration

                playerShipGrid.BuildGrid();
                

                allShipsSet = true;

            }

        }


        public string GetDirection(int row, int col)
        {
            // CHOOSE UP, DOWN, RIGHT, OR LEFT
            string direction;
            do
            {
                Console.WriteLine("Starting from point (" + (row+1)+ ", " + (col+1) + ") In what direction would you like to extend your ship? (Type 'right', 'left', 'up' or 'down')");
                direction = Console.ReadLine();

                if (direction != "up" && direction != "down" && direction != "right" && direction != "left")
                {
                    Console.WriteLine("Not a valid direction! Try again!");
                }

            }
            while (direction != "up" && direction != "down" && direction != "right" && direction != "left");

            return direction;
            // Now will need to validate direction and revalidate OR use it // 

        }

        public bool PlaceShip(int row, int col, Ship ship, string direction) // return bool if succedful or not for validation
        {
            switch (direction)
            {
                case "down":
                    if (row + ship.size >= playerShipGrid.stringGrid.GetLength(0))
                    {
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row+1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {
                        

                        for (int i = 1; i < ship.size; i++)
                        {
                            if (playerShipGrid.stringGrid[row + i, col] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
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
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {
                        

                        for (int i = 1; i < ship.size; i++)
                        {
                            if (playerShipGrid.stringGrid[row - i, col] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
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
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {
                        

                        for (int i = 1; i < ship.size ; i++)
                        {
                            if (playerShipGrid.stringGrid[row, col+i] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                                return false;
                            }
                            else
                            {
                                playerShipGrid.stringGrid[row, col+i] = ship.key;

                            }

                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
                case "left":
                    if (col - ship.size < 0)
                    {
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {
                        

                        for (int i = 1; i < ship.size ; i++)
                        {
                            if (playerShipGrid.stringGrid[row, col - i] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col+1));
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
