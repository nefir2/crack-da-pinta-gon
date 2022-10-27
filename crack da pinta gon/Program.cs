using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crack_da_pinta_gon
{
	class Program
	{
		static void Main()
		{
			while (true)
			{
				string the_folder = GetTheFolder();
				try { Process.Start(the_folder); } //await Task.Run(() => Process.Start(the_folder));
				catch (Exception ex) { ColorFormat.Write($"%{{0}}ошибка: {ex.Message}\n", true, ConsoleColor.Red); }

				if (Retry()) { Console.Clear(); continue; }
				else break;
			}
			//Endl("нажмите любую клавишу для завершения программы . . . ");
		}
		private static bool Retry()
		{
			ConsoleColor Default = Console.ForegroundColor;
			ColorFormat.Write("продолжить выполнение программы? %0y%1/%2n", true, ConsoleColor.Green, Default, ConsoleColor.DarkRed);
			while (true)
			{
				string ans = Console.ReadKey(true).KeyChar.ToString();
				if (ans == "y") { Console.WriteLine(); return true; }
				else if (ans == "n") return false;
				else continue;
			}
		}
		private static string GetTheFolder()
		{
			string[] some_folders = new string[]
			{
				@"\\26k-10-dc10\studocredir",
				@"C:\",
			};
			Console.WriteLine("выберите одну из имеющихся папок, или введите свою.");
			for (int i = 0; i < some_folders.Length; i++) ColorFormat.Write($"{i + 1}. %0\"{some_folders[i]}\";\n", true, i % 2 == 0 ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed);
			Console.WriteLine($"{some_folders.Length + 1}. ввести свою папку.");
			int choice;
			while (true)
			{
				try
				{
					Console.Write("\nвыберите один из вариантов: ");
					choice = int.Parse(Console.ReadLine()) - 1;
					if (choice == some_folders.Length)
					{
						Console.Write("введите путь папки: ");
						return Console.ReadLine(); //встроить парсер пути
					}
					else if (choice < 0 || choice > some_folders.Length)
					{
						//Console.WriteLine();
						ColorFormat.Write("%0ошибка: введённое значение оказалось больше или меньше допущенных.\n", true, ConsoleColor.Red);
						continue;
					}
					break;
				}
				catch (Exception ex)
				{
					ColorFormat.Write("%0ошибка: " + ex.Message, true, ConsoleColor.Red);
					//Console.WriteLine(ex.Message);
					continue;
				}
			}
			string the_folder = some_folders[choice];

			return the_folder;
		}
	}
}