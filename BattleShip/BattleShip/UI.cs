using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    static class UI
    {






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
            Console.WriteLine("Do you want to play against 'comp' , 'player' , or watch 'sim'?");
           string gameStyle = Console.ReadLine();
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



    }
}
