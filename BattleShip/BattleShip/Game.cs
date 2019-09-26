using System;
namespace BattleShip
{
    public class Game
    {
        //MEMBER VAR
        Player playerOne;
        Player playerTwo;



        //CONSTRUCTOR
        public Game()
        {
        }



        //MEMBER METHODES

        public void MasterGameFunction()
        {
            WelcomeToBattleShip();
            DisplayRules();


        }


        // Welcome, game discription sequence ect

        public void WelcomeToBattleShip()
        {
            Console.WriteLine("WELCOME TO SEASHARP BATTLESHIP!");
            Console.WriteLine();
            Console.WriteLine("Press 'ENTER' to start");
            Console.ReadLine();
        }

        public void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("The rule are simple you stupid idiot");
            Console.ReadLine();
        }

        // Play against a human or computer or sim?

        // build your grids

        // Lay down your ships // Keep in bounds

        // ask to guess coordinates to fire

        // is hit or miss?

        // retutn hit or miss

        // (computer makes 'smart' calls on hits / misses

        // track a 'sunken ship'

        // When all ships sank show winner

        // end game or start again.



    }
}
