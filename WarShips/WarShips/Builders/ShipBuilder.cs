﻿using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Domain;
using WarShips.Enums;
using WarShips.Interfaces;

namespace WarShips.Builders
{
    public class ShipBuilder
    {
        private readonly IShip Ship = new Ship();

        public void BuildShipType(ShipType shipType)
        {
            Ship.ShipType = shipType;
            Ship.Health = (int)shipType;
        }

        public void BuildPosition(int[,] position)
        {
            Ship.Position = position;
        }

        public IShip GetResult()
        {
            if (Ship.Position != null && Ship.Health != 0)
                return new Ship
                {
                    Health = Ship.Health,
                    Position = Ship.Position,
                    ShipType = Ship.ShipType
                };
            return null;

        }
    }
}
