using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            size = 4;
            name = "Battle Ship";
            key = "[B]";
        }
    }
}
