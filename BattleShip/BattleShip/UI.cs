using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    static class UI
    {


        

        public static void Pause()
        {
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }



        public static void WelcomeToBattleShip()
        {
            Console.WriteLine("WELCOME TO SEASHARP BATTLESHIP!");
            Console.WriteLine();
            Console.WriteLine("Press 'ENTER' to start");
            Console.ReadLine();
        }

        public static void DisplayRules()
        {
            Console.Clear();
            Console.WriteLine("The rules are simple you stupid idiot");
            Console.ReadLine();
            Console.WriteLine("The rules are simple you stupid idiot");
            Console.ReadLine();
            Console.WriteLine("The rules are simple you stupid idiot");
            Console.ReadLine();

        }

        

        public static string ChooseGameStyle()
        {
            string gameStyle = GetUserInput("Do you want to play against 'comp' , 'player' , or watch 'sim'?");
            while (gameStyle.ToLower() != "comp" && gameStyle.ToLower() != "player" && gameStyle.ToLower() != "sim" )
            {
                gameStyle = RetryGetUserInput("Not a valid game style!");
            }
           
            return gameStyle;

        }

        public static void ChangeScreen()
        {
            Console.Clear();
            Console.WriteLine("Please Pass Computer Screen to next Player!");
            Console.ReadLine();
        }


        public static string GetUserInput(string question)
        {
            Console.WriteLine(question);
           return Console.ReadLine();
        }

        public static string RetryGetUserInput(string question)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(question);
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static void Error (string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
            
        }

        public static int ValidateInt(string test)
        {
            // try to int 
            return 10;
        }

        public static int IntGetUserInput(string message)
        {
            int output;
            string test = GetUserInput(message);

            try
            {
                output = Int32.Parse(test);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not a valid number input, please try again");
                Console.ResetColor();

                return IntGetUserInput(message);
            }

            return output;
        }

        public static void ShipInfo(Ship ship)
        {
            Console.WriteLine("Enter Coordinates for an open position to place your " + ship.name);
            Console.WriteLine("( a " + ship.name + " takes up " + ship.size + " spaces)");
        }



        public static string GetShipName(string key)
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
