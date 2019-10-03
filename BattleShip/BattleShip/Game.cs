﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Game
    {
        //MEMBER VAR
        public Player playerOne;
        public Player playerTwo;
        public string gameStyle;
        public bool p1Turn;
        public bool playAgain;



        //CONSTRUCTOR
        public Game()
        {
            p1Turn = true;
        }



        //MEMBER METHODES

        public void MasterGameFunction()
        {
            do
            {

                WelcomeToBattleShip();

                ChooseGameStyle(); // VALIDATE

                CreatePlayers(); // VALIDATE

                BuildPlayerGrids();

                SelectShips();






                while (playerOne.lives > 0 && playerTwo.lives > 0)
                {
                    if (p1Turn == true) // P1 turn
                    {

                        Console.WriteLine(playerOne.name + "'s turn");
                        playerOne.playerShipGrid.BuildGrid();
                        Tuple<int, int> attack = playerOne.SendAttackCords();
                        bool wasHit = playerTwo.RecieveAttack(attack);
                        playerOne.UpdateHitMap(wasHit, attack);



                        ToggleTurn();



                    }
                    else
                    {

                        Console.WriteLine(playerTwo.name + "'s turn");
                        playerTwo.playerShipGrid.BuildGrid();
                        Tuple<int, int> attack = playerTwo.SendAttackCords();
                        bool wasHit = playerOne.RecieveAttack(attack);
                        playerTwo.UpdateHitMap(wasHit, attack);

                        ToggleTurn();


                    }
                }

                Player winner;

                if (playerOne.lives == 0)
                {
                    winner = playerTwo;
                }
                else
                {
                    winner = playerOne;
                }


                Console.WriteLine(winner.name + " is the winner! all ships sunk!");

            }
            while (playAgain == true);

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
            Console.WriteLine("The rule are simple you stupid idiot");
            Console.ReadLine();
            Console.WriteLine("The rule are simple you stupid idiot");
            Console.ReadLine();

        }

        // Play against a human or computer or sim?

        public void ChooseGameStyle()
        {
            Console.WriteLine("Do you want to play against 'comp' , 'player' , or watch 'sim'?");
            gameStyle = Console.ReadLine();

        }

        public void CreatePlayers()
        {
            switch (gameStyle)
            {
                case "player":
                    playerOne = new Human("Player 1");
                    playerTwo = new Human("Player 2");
                    break;
                case "comp":
                    playerOne = new Human("Player 1");
                    playerTwo = new Comp("Computer");
                    break;
                case "sim":
                    playerOne = new Comp("Computer 1");
                    playerTwo = new Comp("Computer 2");
                    break;
            }

        }
        // TOGGLE TURN

        public void ToggleTurn()
        {
            p1Turn = !p1Turn;
        }


        // build your grids
        // Lay down your ships // Keep in bounds


        public void SelectShips()
        {
            Console.Write(playerOne.name);
            playerOne.PositionShips();

            Console.Write(playerTwo.name);
            playerTwo.PositionShips();
        }

        public void BuildPlayerGrids()
        {
            playerOne.CreateBoard();
            playerOne.CreateBoard();

            playerTwo.CreateBoard();
            playerTwo.CreateBoard();
        }


        //Each Turn display board

        // ask to guess coordinates to fire

        // is hit or miss?

        // retutn hit or miss

        // (computer makes 'smart' calls on hits / misses

        // track a 'sunken ship'

        // When all ships sank show winner

        // end game or start again.



    }
}
