using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Game
    {
        public Player playerOne;
        public Player playerTwo;
        private string gameStyle;
        private bool p1Turn;
        private bool playAgain;

        public Game()
        {
            p1Turn = true;
            
        }


        public void MasterGameFunction()
        {
            UI.WelcomeToBattleShip();
            do
            {            
                gameStyle = UI.ChooseGameStyle(); 
                CreatePlayers(); 
                BuildPlayerGrids();
                SelectShips();
                PlayGame();   
                Player winner = playerOne.lives == 0 ? playerTwo : playerOne;         
                Console.WriteLine(winner.name + " is the winner! all ships sunk!");
                playAgain = UI.PlayAgain();
            }
            while (playAgain == true);

            UI.Exit();
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
            UI.Pause();
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
            if (gameStyle == "player")
            {
                UI.Pause();
                UI.ChangeScreen();
            }
            Console.Clear();
            Console.WriteLine(playerTwo.name);
            playerTwo.PositionShips();

            if (gameStyle == "player")
            {
                UI.Pause();
                UI.ChangeScreen();
            }
        }

        public void BuildPlayerGrids()
        {
            int size = UI.Limiter(UI.IntGetUserInput("What Size Board would you like to play with (min 10, max 30) ?"), 10, 30);
            
            CreateBoards(playerOne, size);
            CreateBoards(playerTwo, size);
        }

        public static void CreateBoards(Player player, int size)
        {
            // MAKE BOARDS

            player.playerShipGrid = new Grid(size);
            player.playerShipGrid.PopulateEmptyGrid();

            player.playerHitGrid = new Grid(size);
            player.playerHitGrid.PopulateEmptyGrid();
        }




    }
}
