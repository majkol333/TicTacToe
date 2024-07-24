using System;

namespace TicTacToe
{
    static class Func
    {
        public static bool CheckVictory(char symbol)
        {
            for (int i = 0; i < Program.area.baseField.Length; i++) // Check signs
            {
                for (int j = 0; j < Program.area.baseField[i].Length; j++)
                {
                    if (Program.area.baseField[i][j] == symbol) // Sign no.1
                    {
                        if (i - 1 >= 0) // Can go up
                        {
                            if (Program.area.baseField[i - 1][j] == symbol) // Sign no.2
                            {
                                if (i - 2 >= 0) // Can go further
                                {
                                    if (Program.area.baseField[i - 2][j] == symbol) // Sign no.3
                                        return true;
                                }
                            }
                        }
                        if (i + 1 <= 2) // Can go down
                        {
                            if (Program.area.baseField[i + 1][j] == symbol)  // Sign no.2
                            {
                                if (i + 2 <= 2) // Can go further
                                {
                                    if (Program.area.baseField[i + 2][j] == symbol) // Sign no.3
                                        return true;
                                }
                            }
                        }
                        if (j - 1 >= 0) // Can go left
                        {
                            if (Program.area.baseField[i][j - 1] == symbol)  // Sign no.2
                            {
                                if (j - 2 >= 0) // Can go further
                                {
                                    if (Program.area.baseField[i][j - 2] == symbol) // Sign no.3
                                        return true;
                                }
                            }
                        }
                        if (j + 1 <= 2) // Can go right
                        {
                            if (Program.area.baseField[i][j + 1] == symbol)  // Sign no.2
                            {
                                if (j + 2 <= 2) // Can go further
                                {
                                    if (Program.area.baseField[i][j + 2] == symbol) // Sign no.3
                                        return true;
                                }
                            }
                        }
                        if (i + 1 <= 2 && j + 1 <= 2) // Can go bottom right
                        {
                            if (Program.area.baseField[i + 1][j + 1] == symbol)  // Sign no.2
                            {
                                if (i + 2 <= 2 && j + 2 <= 2) // Can go further
                                {
                                    if (Program.area.baseField[i + 2][j + 2] == symbol) // Sign no.3
                                        return true;
                                }
                            }
                        }
                        if (i + 1 <= 2 && j - 1 >= 0) // Can go bottom left
                        {
                            if (Program.area.baseField[i + 1][j - 1] == symbol)  // Sign no.2
                            {
                                if (i + 2 <= 2 && j - 2 >= 0) // Can go further
                                {
                                    if (Program.area.baseField[i + 2][j - 2] == symbol) // Sign no.3
                                        return true;
                                }
                            }
                        }
                    }
                }
            }

            return false; // If nothing found, assume no victory
        }
        public static bool isFull()
        {
                for (int x = 0; x < Program.area.baseField.Length; x++)
                {
                    for (int y = 0; y < Program.area.baseField[x].Length; y++)
                    {
                        if (Program.area.baseField[x][y] == Program.symbol) // Symbol found
                            return false;
                }
                }
                return true;
        }
        public static void MakeMove(string output, int min, int max)
        {
            bool innerAccept;

            do
            {
                Console.Write(output);
                Program.input = Console.ReadLine();
                innerAccept = (int.TryParse(Program.input, out Program.converted)) && ((Program.converted == null)?false:((Program.converted <= max) && (Program.converted >= min)));
            } while (!innerAccept);
        }
        public static void ReadClear()
        {
            Console.ReadLine();
            Console.Clear();
        }   
        public enum Turnout
        {
            UserWon,
            ComputerWon,
            Pending, // No winners
            Error // Both winners
        }
        public static Turnout CheckTurnout()
        {
            bool userWon, computerWon;

            userWon = CheckVictory('O');
            computerWon = CheckVictory('X');

            if (userWon && !computerWon)
                return Turnout.UserWon;
            else if (!userWon && computerWon)
                return Turnout.ComputerWon;
            else if (!userWon && !computerWon)
                return Turnout.Pending;
            else
                return Turnout.Error;
        }
        public static Turnout turnoutFirst;
        public static Turnout turnout;    
    }
}