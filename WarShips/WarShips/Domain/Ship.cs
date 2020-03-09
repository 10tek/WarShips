using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Enums;
using WarShips.Interfaces;

namespace WarShips.Domain
{
    public class Ship : IShip
    {
        public ShipType ShipType { get; set; }
        public int Health { get; set; }
        public int[,] Position { get; set; }
    }
}
