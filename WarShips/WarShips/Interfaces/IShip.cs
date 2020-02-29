using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Enums;

namespace WarShips.Interfaces
{
    public interface IShip
    {
        public ShipType ShipType { get; set; }
        public int Health { get; set; }
        public int[,] Position { get; set; }
    }
}
