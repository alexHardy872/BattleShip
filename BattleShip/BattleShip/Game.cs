using System;
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
                UI.WelcomeToBattleShip();
                gameStyle = UI.ChooseGameStyle(); 
                CreatePlayers(); 
                BuildPlayerGrids();
                SelectShips();
                PlayGame();   
                Player winner = playerOne.lives == 0 ? playerTwo : playerOne;         
                Console.WriteLine(winner.name + " is the winner! all ships sunk!");
            }
            while (playAgain == true);
        }

        public void PlayGame()
        {
            while (playerOne.lives > 0 && playerTwo.lives > 0)
            {
                if (p1Turn == true) // P1 turn
                {
                    PlayerTurn(playerOne, playerTwo);
                    ToggleTurn();
                }
                else
                {
                    if (gameStyle == "comp")
                    {
                        ComputerTurn(playerTwo, playerOne);
                    }
                    else
                    {
                        PlayerTurn(playerTwo, playerOne);
                    }
                    ToggleTurn();
                }
            }
        }

        public void PlayerTurn(Player current, Player other)
        {
            Console.WriteLine(current.name + "'s turn");
            current.playerShipGrid.BuildGrid();
            UI.Pause();
            Tuple<int, int> attack = current.SendAttackCords();
            Console.WriteLine(current.name + " sent an attack to " + attack);
            bool wasHit = other.RecieveAttack(attack);
            string result = wasHit == true ? "hit" : "miss";
            Console.WriteLine(result.ToUpper());
            current.UpdateHitMap(wasHit, attack);
            UI.Pause();
            if (gameStyle == "player")
            {
                UI.ChangeScreen();
            }

        }

        public void ComputerTurn(Player current, Player other)
        {    
            Tuple<int, int> attack = current.SendAttackCords();
            Console.WriteLine(current.name + " sent an attack to " + attack);
            bool wasHit = other.RecieveAttack(attack);
            string result = wasHit == true ? "hit" : "miss";
            Console.WriteLine(result.ToUpper());
            current.UpdateHitMap(wasHit, attack);
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
       

        public void ToggleTurn()
        {
            Console.Clear();
            p1Turn = !p1Turn;
        }


        


        public void SelectShips()
        {
            Console.WriteLine(playerOne.name);
            playerOne.PositionShips();
            if (gameStyle != "sim")
            {
                UI.Pause();
                UI.ChangeScreen();
            }
            Console.Clear();
            Console.WriteLine(playerTwo.name);
            playerTwo.PositionShips();
        }

        public void BuildPlayerGrids()
        {
            playerOne.CreateBoard();
            playerOne.CreateBoard();

            playerTwo.CreateBoard();
            playerTwo.CreateBoard();
        }


  

    }
}
