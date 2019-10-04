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
                    int row;
                    int col;

                    Console.WriteLine("Here is your Current Board");
                    playerShipGrid.BuildGrid();

                    do
                    {
                        escape = false;
                        bool redoCoords;
                        do
                        {
                            Console.WriteLine("Enter Coordinates for an open position to place your " + ship.name);
                            Console.WriteLine("( a " + ship.name + " takes up " + ship.size + " spaces)");

                            Console.WriteLine("Enter the row"); /// maybe use letters and number system to input D17 type deal. also validation?


                            row = (Int32.Parse(Console.ReadLine()) - 1);
                            Console.WriteLine("Enter the collum");
                            col = (Int32.Parse(Console.ReadLine()) - 1);


                            if (row >= 20 || col >= 20 || row < 0 || col < 0)
                            {
                                Console.WriteLine("This space does not exist!");
                                redoCoords = true;

                            }
                            else if (playerShipGrid.stringGrid[row, col] != "[ ]")
                            {
                                Console.WriteLine("This space is already taken");
                                redoCoords = true;
                            }
                            else
                            {
                                redoCoords = false;
                            }
                        }
                        while (redoCoords == true);


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


        public string GetDirection(int row, int col)
        {
            // CHOOSE UP, DOWN, RIGHT, OR LEFT
            string direction;
            do
            {
                Console.WriteLine("Starting from point (" + (row+1)+ ", " + (col+1) + ") In what direction would you like to extend your ship? (Type 'right', 'left', 'up' or 'down') or 'back' to try new coordinates");
                direction = Console.ReadLine();

                if (direction != "up" && direction != "down" && direction != "right" && direction != "left" && direction != "back")
                {
      
                    
                    Console.WriteLine("Not a valid direction! Try again!");
                }

            }
            while (direction != "up" && direction != "down" && direction != "right" && direction != "left" && direction != "back");

            return direction;
            // Now will need to validate direction and revalidate OR use it // 

        }

        public bool PlaceShip(int row, int col, Ship ship, string direction) // return bool if succedful or not for validation
        {
            switch (direction)
            {
                case "down":
                    if (row + ship.size > playerShipGrid.stringGrid.GetLength(0))
                    {
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row+1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {

                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {

                            if (playerShipGrid.stringGrid[row + i, col] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                                return false;
                            }
                        }


                        for (int i = 1; i < ship.size; i++)
                        {
                          
                                playerShipGrid.stringGrid[row + i, col] = ship.key;
                                                   
                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;

                case "up":
                    if (row - ship.size < -1)
                    {
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {
                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {

                            if (playerShipGrid.stringGrid[row - i, col] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                                return false;
                            }
                        }

                        for (int i = 1; i < ship.size; i++)
                        {
                           
                                playerShipGrid.stringGrid[row - i, col] = ship.key;

                            

                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
                case "right":
                    if (col + ship.size > playerShipGrid.stringGrid.GetLength(1))
                    {
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {
                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {

                            if (playerShipGrid.stringGrid[row, col+i] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                                return false;
                            }
                        }

                        for (int i = 1; i < ship.size ; i++)
                        {                        
                                playerShipGrid.stringGrid[row, col+i] = ship.key;
                       
                       }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
                case "left":
                    if (col - ship.size < -1)
                    {
                        Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                        return false;
                    }
                    else
                    {
                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {
                            if (playerShipGrid.stringGrid[row, col-i] != "[ ]")
                            {
                                Console.WriteLine("Not enough room to fit this" + ship.name + " " + ship.size + " spaces " + direction + " of (" + (row + 1) + ", " + (col + 1));
                                return false;
                            }
                        }

                        for (int i = 1; i < ship.size ; i++)
                        {  
                                playerShipGrid.stringGrid[row, col - i] = ship.key;
                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
                case "back":
                    escape = true;
                    break;
            }

            return true;
        }




        public override Tuple<int,int> SendAttackCords()
        {
            // DISPLAY HIT BOARD
            // SELECT COORINATES TO ATTACK

            // PLACE EITHER 'X' OR 'o'

            // update opponenets main grid with X or o

            Console.WriteLine(name + ", its time to attack! Here are your current strikes");
            playerHitGrid.BuildGrid();

            int row;
            int col;

            do
            {
         
                Console.WriteLine("Enter the row"); /// maybe use letters and number system to input D17 type deal. also validation?

                row = (Int32.Parse(Console.ReadLine()) - 1);
                Console.WriteLine("Enter the collum");
                col = (Int32.Parse(Console.ReadLine()) - 1);


                if (row > 20 || col > 20 || row < 0 || col < 0 || playerHitGrid.stringGrid[row, col] != "[ ]")
                {
                    Console.WriteLine("This space is already taken or does not exist!");
                }
            }
            while (row > 20 || col > 20 || row < 0 || col < 0 || playerHitGrid.stringGrid[row, col] != "[ ]");

            if (playerHitGrid.stringGrid[row,col] == "[M]" || playerHitGrid.stringGrid[row, col] == "[X]")
            {
                Console.WriteLine("You have already tried this space!");
                return SendAttackCords();
            }

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

        public override void UpdateHitMap(bool didHit, Tuple<int,int> Cords)
        {
            int row = Cords.Item1;
            int col = Cords.Item2;

            if (didHit == true)
            {
                playerHitGrid.stringGrid[row, col] = "[X]";
                Console.WriteLine("HIT!");
            }
            else
            {
                playerHitGrid.stringGrid[row, col] = "[M]";
                Console.WriteLine("MISS!");
            }

            playerHitGrid.BuildGrid();
        }




        public override bool CheckShipSink(string input)
        {

            for (int i = 0; i < playerShipGrid.stringGrid.GetLength(0); i++)
            {
                for (int j = 0; j < playerShipGrid.stringGrid.GetLength(1); j++)
                {
                    if (playerShipGrid.stringGrid[i, j] == input)
                    {
                        return false;
                    }


                }
            }


            lives -= 1;

            // CheckLives();

            // SINK NOTIFICATION!
            string shipName = getShipName(input);
            Console.WriteLine("YOU SUNK " + name + "'s " + shipName + "!");
            return true;
        }


        public string getShipName(string key)
        {

            switch (key)
            {
                case "[D]":
                    return "Destroyer";
                    ;
                case "[S]":
                    return "Submarine";

                case "[B]":
                    return "BattleShip";

                case "[A]":
                    return "Aircraft Carrier";
                default:
                    return "Ship";


            }

        }



    }
}
