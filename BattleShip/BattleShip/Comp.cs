﻿using System;
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


        public override void CreateBoard()
        {
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
                  //  playerShipGrid.BuildGrid();
                    int row;
                    int col;
                    do
                    {
                        row = GetRandomNum(0,20);
                        col = GetRandomNum(0,20);
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
            int random = GetRandomNum(0,4);
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
            bool checkBoundries = QuickCheckBounds(row, col, ship, direction) == false ? false : true;
            if (checkBoundries == false)
            {
                return false;
            }
            else
            {
                for (int i = 1; i < ship.size; i++)
                {
                    bool checkForShips = QuickCheckEmpty(row, col, i, ship, direction) == false ? false : true;
                    if (checkForShips == false)
                    { 
                        return false;
                    }
                }
                for (int i = 1; i < ship.size; i++)
                {
                    NextPosition(row, col, i, ship, direction);
                }

                playerShipGrid.stringGrid[row, col] = ship.key;
            }
            return true;
        }

        private void NextPosition(int row, int col, int i, Ship ship, string direction)
        {
            switch (direction)
            {
                case "down":
                    playerShipGrid.stringGrid[row + i, col] = ship.key;
                    break;
                case "up":
                    playerShipGrid.stringGrid[row - i, col] = ship.key;
                    break;
                case "right":
                    playerShipGrid.stringGrid[row, col + i] = ship.key;
                    break;
                case "left":
                    playerShipGrid.stringGrid[row, col - i] = ship.key;
                    break;
            }
            
        }

        private bool QuickCheckBounds(int row, int col, Ship ship, string direction)
        {
            bool success;
            switch(direction)
            {
                case "down":
                     success = row + ship.size >= playerShipGrid.stringGrid.GetLength(0) ? false : true;
                    return success; 
                case "up":
                     success = row - ship.size < 0 ? false : true;
                    return success;                 
                case "right":
                    success = col + ship.size >= playerShipGrid.stringGrid.GetLength(1) ? false : true;
                    return success;               
                case "left":
                    success = col - ship.size < 0 ? false : true;
                    return success;             
            }
            return false;
        }

        private bool QuickCheckEmpty(int row, int col, int i , Ship ship, string direction)
        {
            bool success;
            switch (direction)
            {
                case "down":
                    success = playerShipGrid.stringGrid[row + i, col] != "[ ]" ? false : true;
                    return success;
                case "up":
                    success = playerShipGrid.stringGrid[row - i, col] != "[ ]" ? false : true;
                    return success;
                case "right":
                    success =  playerShipGrid.stringGrid[row, col + i] != "[ ]" ? false : true;
                    return success;
                case "left":
                    success = playerShipGrid.stringGrid[row, col - i] != "[ ]" ? false : true;
                    return success;
            }
            return false;
        }


        public override Tuple<int, int> SendAttackCords()
        {
            int row;
            int col;

            do
            {
                row = GetRandomNum(0,20);
                col = GetRandomNum(0,20);           
            }
            while ( playerHitGrid.stringGrid[row, col] != "[ ]" && playerHitGrid.stringGrid[row, col] == "[M]" && playerHitGrid.stringGrid[row, col] == "[X]");

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
