using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crack_da_pinta_gon
{
	class MainClass
	{
		
		internal static void Main()
		{
			do
			{
				ColorFormat.Write($"%%1&0ошибка%&: %0&1произошла ошибка\n", true, ConsoleColor.Black, ConsoleColor.White);
			} while (Retry());

			Console.ReadKey();
		}
		private static bool Retry()
		{
			ConsoleColor Default = Console.ForegroundColor;
			ColorFormat.Write("продолжить выполнение программы? %0y%1/%2n", ConsoleColor.Green, Default, ConsoleColor.DarkRed);
			while (true)
			{

				string ans = Console.ReadKey(true).KeyChar.ToString();
				if (ans == "y")
				{
					Console.WriteLine();
					return true;
				}
				else if (ans == "n") return false;
				else continue;
			}
		}
	}
}