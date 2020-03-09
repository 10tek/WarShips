using System;
using System.Linq;

namespace WarShips
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }

        public static void ShowMap()
        {
            var letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
            Console.SetCursorPosition(2, 0);
            for(var i = 0; i < 10; i++)
            {
                Console.Write(" " + letters[i]);
            }
            
            Console.SetCursorPosition(25, 0);
            for(var i = 0; i < 10; i++)
            {
                Console.Write(" " + letters[i]);
            }

            for (var i = 1; i <= 10; i++)
            {
                Console.SetCursorPosition(1 - (i)/10, i);
                Console.Write(i);
            }

            for (var i = 1; i <= 10; i++)
            {
                Console.SetCursorPosition(22, i);
                Console.Write(i);
            }

            Console.SetCursorPosition(2, 11);
            for (var i = 0; i < 10; i++)
            {
                Console.Write(" " + letters[i]);
            }
        }
    }
}
