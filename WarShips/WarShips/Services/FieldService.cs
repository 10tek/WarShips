using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Domain;

namespace WarShips.Services
{
    public class FieldService
    {
        private const int FIELD_SIZE = 10;

        public void ShowField()
        {
            var letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            for (var i = 0; i < FIELD_SIZE; i++)
            {
                Console.SetCursorPosition(i + 2, 0);
                Console.Write(letters[i]);
                Console.SetCursorPosition(i + 2, 11);
                Console.Write(letters[i]);
                Console.SetCursorPosition(i + 25, 0);
                Console.Write(letters[i]);
                Console.SetCursorPosition(i + 25, 11);
                Console.Write(letters[i]);
                Console.SetCursorPosition(1, i + 1);
                Console.Write(i);
                Console.SetCursorPosition(12, i + 1);
                Console.Write(i);
                Console.SetCursorPosition(24, i + 1);
                Console.Write(i);
                Console.SetCursorPosition(35, i + 1);
                Console.Write(i);
            }
        }

        /// <summary>
        /// Обводка уничтоженного корабля.
        /// </summary>
        public void EncircleShip(Player player, Ship ship)
        {
            for (var k = 0; k < (int)ship.ShipType; k++)
            {
                var x = ship.Position[0, k] - 1;
                var y = ship.Position[1, k] - 1;
                var iCount = x + 3 == 10 ? x + 3 : x + 2;
                var jCount = y + 3 == 10 ? x + 3 : x + 2;
                if (x < 0)
                {
                    iCount--;
                    x = 0;
                }
                if (y < 0)
                {
                    jCount--;
                    y = 0;
                }

                for (var i = x; i < x + 3; i++)
                {
                    for (var j = y; j < y + 3; j++)
                    {
                        player.Field[i, j] = 2;
                    }
                }
            }
            for (var k = 0; k < (int)ship.ShipType; k++)
            {
                player.Field[ship.Position[0, k], ship.Position[1, k]] = 1;
            }
        }
    }
}
