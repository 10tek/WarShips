using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarShips.Domain;
using WarShips.Interfaces;
using WarShips.Services;

namespace WarShips
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player
            {
                Name = "Galym",
                Field = new int[10, 10],
                EnemyField = new int[10, 10],
                Ships = new List<IShip>()
            };
            var field = new FieldService();
            field.RandomArrangement(player);
            field.ShowPlayer(player);
            field.ControlCursor(); 
            Console.ReadKey();
        }

    }
}
