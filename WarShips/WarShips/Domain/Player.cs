using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Interfaces;

namespace WarShips.Domain
{
    public class Player
    {
        public string Name { get; set; }
        public List<IShip> Ships { get; set; }
        public int[,] Field { get; set; }
        public int[,] EnemyField { get; set; }
    }
}
