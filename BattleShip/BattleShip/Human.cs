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
                        row = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the collum");
                        col = Int32.Parse(Console.ReadLine());


                        if (playerShipGrid.stringGrid[row, col] != "[ ]")
                        {
                            Console.WriteLine("This space is already taken or does not exist!");
                        }
                    }
                    while (playerShipGrid.stringGrid[row, col] != "[ ]" || row > 20 || col > 20 || row < 0 || col < 0);



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





            }
        }


        public string GetDirection(int row, int col)
        {
            // CHOOSE UP, DOWN, RIGHT, OR LEFT
            string direction;
            do
            {
                Console.WriteLine("Starting from point (" + row + ", " + col + ") In what direction would you like to extend your ship? (Type 'right', 'left', 'up' or 'down')");
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
                    if (col + ship.size >= playerHitGrid.stringGrid.GetLength(0))
                    {
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + row + ", " + col);
                        return false;
                    }
                    else
                    {
                        playerShipGrid.stringGrid[row, col] = "[0]";

                        for (int i = 1; i < ship.size + 1; i++)
                        {

                            playerShipGrid.stringGrid[row + i, col] = "[0]";
                        }

                        return true;
                    }

                case "up":
                    break;
                case "right":
                    break;
                case "left":
                    break;
            }

            return true;
        }

       
    }
}
