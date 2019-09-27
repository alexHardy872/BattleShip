using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            size = 3;
            name = "Submarine";
            key = "[S]";
        }
    }
}
