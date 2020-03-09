﻿using System;
using System.Collections.Generic;
using System.Text;

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
                Console.SetCursorPosition(i * 2 + 3, 0);
                Console.Write(letters[i]);
                Console.SetCursorPosition(i * 2 + 27, 0);
                Console.Write(letters[i]);
                Console.SetCursorPosition(1, i + 1);
                Console.Write(i);
                Console.SetCursorPosition(22, i + 1);
                Console.Write(i);
            }
        }
    }
}