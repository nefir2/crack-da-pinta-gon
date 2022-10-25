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
			do { 
				ColorFormat.Write($"%ошибка: %произошла ошибка", ConsoleColor.DarkRed, ConsoleColor.Red);
				Console.Write("");
			} while(Retry());
		}
		private static bool Retry()
		{
			ConsoleColor Default = Console.ForegroundColor;
			ColorFormat.Write("продолжить выполнение программы? %y%/%n", ConsoleColor.Green, Default, ConsoleColor.DarkRed);
			while (true)
			{

				string ans = Console.ReadKey(true).KeyChar.ToString();
				Console.WriteLine();
				if (ans == "y") return true;
				else if (ans == "n") return false;
				else continue;
			}
		}
	}
}