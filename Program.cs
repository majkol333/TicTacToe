using System.IO;

namespace TicTacToe
{
	class Program
	{
		public static int length = 3;
		public static char symbol = '#';
		public static Area area = new Area(length, symbol);
		public static string? input, final;
		public static int converted, outX, outY;
		public static Random random = new();
		public static bool play;
		
		static int Main()
		{
			Console.WriteLine(@"--------------
TIC TAC TOE
--------------

Press Enter to proceed");
			Console.ReadLine();
			DataSystem.LoadData();
			do
			{
				area.Reset();
                Console.Clear();
				do
				{   
					do // User move
					{
						area.Display();
						Console.WriteLine("Make your move");
						Func.MakeMove("Enter your x axis value (1-3): ", 1, length);
						outX = converted;
						Func.MakeMove("Enter your y axis value (1-3): ", 1, length);
						outY = converted;

						if (area.baseField[3 - outY][outX - 1] == symbol)
						{
							area.baseField[3 - outY][outX - 1] = 'O';
							break;
						}
						Console.WriteLine($@"Incorrect move
({outX}, {outY}) = {area.baseField[3 - outY][outX - 1]}
This place is taken.
Try something else.");
						Func.ReadClear();
					} while (true);
					
					Func.turnout = Func.CheckTurnout();
					
					if (Func.turnout == Func.Turnout.Pending && !Func.isFull())
					{
						while (true) // Computer move
						{
							outX = random.Next(0, 3);
							outY = random.Next(0, 3);
							if (area.baseField[outY][outX] == symbol)
							{
								area.baseField[outY][outX] = 'X';
								break;
							}
						}
					}
					
					Func.turnoutFirst = Func.CheckTurnout();
					if (Func.turnoutFirst != Func.Turnout.Error) Func.turnout = Func.turnoutFirst;

				} while (Func.turnout == Func.Turnout.Pending && !Func.isFull());

				Console.Clear();
				area.Display();
				Console.WriteLine("GAME OVER");
				switch (Func.turnout)
				{
					case Func.Turnout.UserWon:
						Console.WriteLine("USER WON");
						DataSystem.data[0]++;
						break;
					case Func.Turnout.ComputerWon:
						Console.WriteLine("COMPUTER WON");
						DataSystem.data[1]++;
						break;
					case Func.Turnout.Pending:
						Console.WriteLine("It's a draw");
						DataSystem.data[2]++;
						break;
					case Func.Turnout.Error:
						Console.WriteLine("ERROR: Found both user and computer winning\nPress Enter to turn off app");
						Console.ReadKey();
						break;
				}

				Console.WriteLine("Press y if you want to play again");
				input = Console.ReadLine();
			} while (input.Trim().ToLower() == "y");
			DataSystem.SaveData();
			return 0;
		}
	}
}
