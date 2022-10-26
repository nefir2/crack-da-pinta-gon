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
			//ColorFormat.Write($"{{int a}}");
			//do
			//{
			//	ColorFormat.Write($"%0ошибка: %1&0произошла ошибка\n", ConsoleColor.DarkRed, ConsoleColor.Red);
			//} while (Retry());
			Console.WriteLine("{0} {0} {1}", 0, 1);
			Console.ReadKey();
		}
		private static bool Retry()
		{
			ConsoleColor Default = Console.ForegroundColor;
			ColorFormat.Write("продолжить выполнение программы? %y%/%n", ConsoleColor.Green, Default, ConsoleColor.DarkRed);
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