//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace crack_da_pinta_gon
//{
//	class MainClass
//	{
//		internal static void Main()
//		{
//			ConsoleColor[] colors = new ConsoleColor[16];
//			for (int i = 0; i < 16; i++) { colors[i] = (ConsoleColor)i; }
//			do
//			{
//				ColorFormat.Write($"%9&{{15}}ошибка: %7&{{10}}произошла ошибка%{{\n", true, colors);
//			} while (Retry());

//			Console.ReadKey();
//		}
//		private static bool Retry()
//		{
//			ConsoleColor Default = Console.ForegroundColor;
//			ColorFormat.Write("продолжить выполнение программы? %0y%1/%2n", ConsoleColor.Green, Default, ConsoleColor.DarkRed);
//			while (true)
//			{

//				string ans = Console.ReadKey(true).KeyChar.ToString();
//				if (ans == "y")
//				{
//					Console.WriteLine();
//					return true;
//				}
//				else if (ans == "n") return false;
//				else continue;
//			}
//		}
//	}
//}