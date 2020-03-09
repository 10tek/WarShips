using System;
using System.Linq;
using System.Text;
using WarShips.Services;

namespace WarShips
{
    class Program
    {
        static void Main(string[] args)
        {

            var field = new FieldService();
            field.ShowField();
            field.ControlCursor();
            Console.ReadKey();
        }
    }
}
