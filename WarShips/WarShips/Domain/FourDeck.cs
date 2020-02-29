using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Enums;
using WarShips.Interfaces;

namespace WarShips.Domain
{
    public class FourDeck : IShip
    {
        public ShipType ShipType { get; set; }
        public int Health { get; set; }
        public int[,] Position { get; set; }

        public FourDeck(int[,] pos)
        {
            ShipType = ShipType.four;
            Health = 4;
            Position = pos;
        }
    }
}
