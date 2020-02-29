using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Enums;
using WarShips.Interfaces;

namespace WarShips.Domain
{
    public class OneDeck : IShip
    {
        public ShipType ShipType { get; set; }
        public int Health { get; set; }
        public int[,] Position { get; set; }

        public OneDeck(int[,] pos)
        {
            ShipType = ShipType.one;
            Health = 1;
            Position = pos;
        }
    }
}
