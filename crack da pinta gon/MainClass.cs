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
			ColorFormat.Write($"%ошибка: %произошла ошибка", ConsoleColor.DarkRed, ConsoleColor.Red);
			Console.ReadKey(true);
		}
	}
}
