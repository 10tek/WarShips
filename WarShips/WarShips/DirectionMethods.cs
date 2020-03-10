using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Domain;
using WarShips.Enums;

namespace WarShips
{
    public static class DirectionMethods
    {
        public static int Move(this Direction direction, ref int x, ref int y)
        {
            switch (direction)
            {
                case Direction.Up: return --y;
                case Direction.Right: return ++x;
                case Direction.Down: return ++y;
                case Direction.Left: return --x;
                default: return -1;
            }
        }

        /// <summary>
        /// Вставка корабля в игрока :)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="ship"></param>
        public static void PlaceShip(this Player player, Ship ship)
        {
            for (var i = 0; i < (int)ship.ShipType; i++)
            {
                player.Field[ship.Position[0, i], ship.Position[1, i]] = (int)Designation.Ship;
            }
            player.Ships.Add(ship);
        }
    }
}
