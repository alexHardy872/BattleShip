using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public abstract class Player
    {

        // Member Vars


        public string name;
        public Grid playerShipGrid;
        public Grid playerHitGrid;
        public int lives;
        public Ship destroyer;
        public Ship submarine;
        public Ship battleship;
        public Ship aircraftcarrier;
        public bool allShipsSet;
        public List<Ship> listShips;


        // Constructor

        public Player()
        {
            allShipsSet = false;
            listShips = new List<Ship>();

            destroyer = new Destroyer();
            submarine = new Submarine();
            battleship = new Battleship();
            aircraftcarrier = new AircraftCarrier();

            Ship[] ships = { destroyer, submarine, battleship, aircraftcarrier };
            listShips.AddRange(ships);
            lives = ships.Length;


        }





        // Methodes


           


        // place ships
        public abstract void CreateBoard();

       

        public abstract void PositionShips();

        public abstract Tuple<int,int> SendAttackCords();

        public abstract bool RecieveAttack(Tuple<int,int> attack);

        public abstract void UpdateHitMap(bool didHit, Tuple<int,int> Cords); // SHOW hits on your hit map

        public abstract bool CheckShipSink(string input);

        //public abstract void UpdateShipMap(); // show opponent strikes on YOUR map

        // make guesses
        




    }
}
