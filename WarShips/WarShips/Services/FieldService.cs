using System;
using System.Collections.Generic;
using System.Text;
using WarShips.Domain;
using WarShips.Enums;

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

        public void ShowPlayer(Player player)
        {
            for (var i = 0; i < FIELD_SIZE; i++)
            {
                for (var j = 0; j < FIELD_SIZE; j++)
                {
                    Console.Write(player.Field[i, j]);
                }
                Console.WriteLine();
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

        /// <summary>
        /// Рандомное расположение кораблей
        /// </summary>
        /// <param name="player"></param>
        public void RandomArrangement(Player player)
        {
            var ship = CreateShip(ShipType.Four);
            player.PlaceShip(ship);
            for (var i = 0; i < 2; i++)
            {
                ship = CreateShip(ShipType.Three);
                while (!CanPlaceShip(player, ship))
                {
                    ship = CreateShip(ShipType.Three);
                }
                player.PlaceShip(ship);
            }

            for (var i = 0; i < 3; i++)
            {
                ship = CreateShip(ShipType.Two);
                while (!CanPlaceShip(player, ship))
                {
                    ship = CreateShip(ShipType.Two);
                }
                player.PlaceShip(ship);
            }


            for (var i = 0; i < 4; i++)
            {
                ship = CreateShip(ShipType.One);
                while (!CanPlaceShip(player, ship))
                {
                    ship = CreateShip(ShipType.One);
                }
                player.PlaceShip(ship);
            }
        }

        /// <summary>
        /// Создание корабля и его рандомное местоположение
        /// </summary>
        /// <param name="shipType"></param>
        /// <returns></returns>
        private Ship CreateShip(ShipType shipType)
        {
            var deckCount = (int)shipType;
            var rand = new Random();
            var ship = new Ship
            {
                ShipType = shipType,
                Health = deckCount,
                Position = new int[2, deckCount]
            };
            var x = rand.Next(deckCount - 1, FIELD_SIZE - deckCount + 1);
            var y = rand.Next(deckCount - 1, FIELD_SIZE - deckCount + 1);
            var direction = (Direction)rand.Next(0, 3);
            for (var i = 0; i < deckCount; i++)
            {
                ship.Position[0, i] = x;
                ship.Position[1, i] = y;
                direction.Move(ref x, ref y);
            }

            return ship;
        }

        /// <summary>
        /// Проверяет можно ли вставить корабль на карте игрока.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="ship"></param>
        /// <returns></returns>
        private bool CanPlaceShip(Player player, Ship ship)
        {
            for (var i = 0; i < (int)ship.ShipType; i++)
            {
                var x = ship.Position[0, i];
                var y = ship.Position[1, i];
                // проверка на соприкосновение с другими палубами
                if (
                    player.Field[x, y] == (int)Designation.Ship
                    || (FIELD_SIZE > y + 1 && player.Field[x, y + 1] == (int)Designation.Ship)
                    || (y > 0 && player.Field[x, y - 1] == (int)Designation.Ship)
                    || (FIELD_SIZE > x + 1 && player.Field[x + 1, y] == (int)Designation.Ship)
                    || (FIELD_SIZE > x + 1 && FIELD_SIZE > y + 1 && player.Field[x + 1, y + 1] == (int)Designation.Ship)
                    || (FIELD_SIZE > x + 1 && y > 0 && player.Field[x + 1, y - 1] == (int)Designation.Ship)
                    || (x > 0 && player.Field[x - 1, y] == (int)Designation.Ship)
                    || (x > 0 && FIELD_SIZE > y + 1 && player.Field[x - 1, y + 1] == (int)Designation.Ship)
                    || (x > 0 && y > 0 && player.Field[x - 1, y - 1] == (int)Designation.Ship)
                    )
                {
                    return false;
                }
            }
            return true;
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
            Console.SetCursorPosition(x, y < 10 ? ++y : y);
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
