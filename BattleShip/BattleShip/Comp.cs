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
        public bool lastMoveHit;
        public int lastRow;
        public int lastCol;
        public int lastHitRow;
        public int lastHitCol;
        public int lastMissRow;
        public int lastMissCol;





        public Comp(string nameIn)
       
        {
            name = nameIn;
            
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

                    int row;
                    int col;

                    do
                    {
                        row = GetRandomNum(20);
                        col = GetRandomNum(20);

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
            Random random = new Random(Guid.NewGuid().GetHashCode());
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
                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {

                            if (playerShipGrid.stringGrid[row + i, col] != "[ ]")
                            {

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
                    if (row - ship.size < 0)
                    {
                        
                        return false;
                    }
                    else
                    {
                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {

                            if (playerShipGrid.stringGrid[row - i, col] != "[ ]")
                            {

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
                    if (col + ship.size >= playerShipGrid.stringGrid.GetLength(1))
                    {
                        return false;
                    }
                    else
                    {
                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {

                            if (playerShipGrid.stringGrid[row, col+i] != "[ ]")
                            {

                                return false;
                            }
                        }

                        for (int i = 1; i < ship.size; i++)
                        {
                       
                                playerShipGrid.stringGrid[row, col + i] = ship.key;

                            

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
                        //CHECK SHIP SIZE
                        for (int i = 1; i < ship.size; i++)
                        {

                            if (playerShipGrid.stringGrid[row, col-i] != "[ ]")
                            {

                                return false;
                            }
                        }


                        for (int i = 1; i < ship.size; i++)
                        {
                     
                                playerShipGrid.stringGrid[row, col - i] = ship.key;

                            

                        }
                        playerShipGrid.stringGrid[row, col] = ship.key;
                    }
                    break;
            }

            return true;
        }


        public override Tuple<int, int> SendAttackCords()
        {
        
  
            int row;
            int col;

            do
            {

                row = GetRandomNum(20);

                col = GetRandomNum(20);
              
            }
            while (row > 20 || col > 20 || row < 0 || col < 0 || playerHitGrid.stringGrid[row, col] != "[ ]");

            if (playerHitGrid.stringGrid[row, col] == "[M]" || playerHitGrid.stringGrid[row, col] == "[X]")
            {
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

        public override void UpdateHitMap(bool didHit, Tuple<int, int> Cords)
        {
            int row = Cords.Item1;
            int col = Cords.Item2;

            if (didHit == true)
            {

                playerHitGrid.stringGrid[row, col] = "[X]";
                lastHitRow = row;
                lastHitCol = col;
                

            }
            else
            {
                playerHitGrid.stringGrid[row, col] = "[M]";
                lastMissRow = row;
                lastMissCol = col;
               
            }

            playerHitGrid.BuildGrid();
        }


        public override bool CheckShipSink(string input)
        {

            for ( int i = 0; i < playerShipGrid.stringGrid.GetLength(0); i++)
            {
                for ( int j = 0; j < playerShipGrid.stringGrid.GetLength(1);  j++)
                {
                    if (playerShipGrid.stringGrid[i,j] == input)
                    {
                        return false;
                    }


                }
            }
         

            lives -= 1;

            // CheckLives();

            // SINK NOTIFICATION!
            string shipName = getShipName(input);
            Console.Write("YOU SUNK " + name + "'s " + shipName+"!");
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
