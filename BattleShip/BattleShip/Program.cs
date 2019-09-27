using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace BattleShip
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.ForegroundColor = ConsoleColor.Blue;


            //Grid grid = new Grid();
            //grid.PopulateEmptyGrid();
            //grid.BuildGrid();

            Game newGame = new Game();
            newGame.MasterGameFunction();



        }
    }
}
