using System;
using System.Linq;
using WarShips.Services;

namespace WarShips
{
    class Program
    {
        static void Main(string[] args)
        {
            new FieldService().ShowField();
            Console.ReadKey();
        }
    }
}
