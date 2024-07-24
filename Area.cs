using System;

namespace TicTacToe
{
    class Area
    {
        char symbol;
        public char[][] baseField;
        public Area(int length, char symbol)
        {
            this.baseField = new char[length][];
            this.symbol = symbol;
            for (int x = 0; x < length; x++)
            {
                this.baseField[x] = new char[length];
                for (int y = 0; y < baseField[x].Length; y++)
                {
                    this.baseField[x][y] = symbol;
                }
            }
        }
        public void Display()
        {
            for (int x = 0; x < baseField.Length; x++)
            {
                for (int y = 0; y < baseField[x].Length; y++)
                {
                    Console.Write(baseField[x][y]);
                }
                Console.WriteLine();
            }

        }
        public void Reset()
        {
            for (int x = 0; x < baseField.Length; x++)
            {
                for (int y = 0; y < baseField[x].Length; y++)
                {
                    baseField[x][y] = symbol;
                }
                Console.WriteLine();
            }
        }
    }
}