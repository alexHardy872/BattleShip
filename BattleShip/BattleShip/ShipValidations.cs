using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
   public static class ShipValidations
    {

        public static void NextPosition(int row, int col, int i, Ship ship, string direction, string[,] grid)
        {
            switch (direction)
            {
                case "down":
                    grid[row + i, col] = ship.key;
                    break;
                case "up":
                    grid[row - i, col] = ship.key;
                    break;
                case "right":
                    grid[row, col + i] = ship.key;
                    break;
                case "left":
                    grid[row, col - i] = ship.key;
                    break;
            }

        }

        public static bool QuickCheckBounds(int row, int col, Ship ship, string direction, int BoardSize)
        {
            bool success;
            switch (direction)
            {
                case "down":
                    success = row + ship.size >= BoardSize ? false : true;
                    return success;
                case "up":
                    success = row - ship.size < 0 ? false : true;
                    return success;
                case "right":
                    success = col + ship.size >= BoardSize  ? false : true;
                    return success;
                case "left":
                    success = col - ship.size < 0 ? false : true;
                    return success;
            }
            return false;
        }

        public static bool QuickCheckEmpty(int row, int col, int i, Ship ship, string direction, string[,] grid)
        {
            bool success;
            switch (direction)
            {
                case "down":
                    success = grid[row + i, col] != "[ ]" ? false : true;
                    return success;
                case "up":
                    success = grid[row - i, col] != "[ ]" ? false : true;
                    return success;
                case "right":
                    success = grid[row, col + i] != "[ ]" ? false : true;
                    return success;
                case "left":
                    success = grid[row, col - i] != "[ ]" ? false : true;
                    return success;
            }
            return false;
        }


    }
}
