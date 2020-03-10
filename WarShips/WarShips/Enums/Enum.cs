using System;
using System.Collections.Generic;
using System.Text;

namespace WarShips.Enums
{
    public enum ShipType
    {
        One = 1,
        Two,
        Three,
        Four
    }

    public enum Direction { Up, Right, Down, Left };

    public enum Designation
    {
        Empty,
        Ship,
        Missed,
        Injured,
        Destroyed,
    }
}
