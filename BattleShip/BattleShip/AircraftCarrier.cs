using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BattleShip
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier()
        {
            size = 5;
            name = "Aircraft Carrier";
            key = "[A]";
        }
    }
}
