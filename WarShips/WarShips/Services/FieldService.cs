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

                for (var i = x; i < iCount; i++)
                {
                    for (var j = y; j < jCount; j++)
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

        public void AttackAttemp(int x, int y)
        {
            //TODO
            Console.SetCursorPosition(x, y);
            Console.WriteLine(@"\");
        }

        public void MoveLeft(ref int x, ref int y)
        {
            Console.SetCursorPosition(x > 25 ? --x : x, y);
        }

        public void MoveRight(ref int x, ref int y)
        {
            Console.SetCursorPosition(x < 34 ? ++x : x, y);
        }

        public void MoveUp(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y > 1 ? --y : y);
        }

        public void MoveDown(ref int x, ref int y)
        {
            Console.SetCursorPosition(x, y < 10 ? y++ : y);
        }

        public void ControlCursor()
        {
            var x = 25;
            var y = 1;

            Console.SetCursorPosition(25, 1);
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.LeftArrow)
                {
                    MoveLeft(ref x, ref y);
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    MoveRight(ref x, ref y);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    MoveUp(ref x, ref y);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    MoveDown(ref x, ref y);
                }
                else if (key == ConsoleKey.Spacebar)
                {
                    AttackAttemp(x, y);
                }
            }
        }
    }
}
