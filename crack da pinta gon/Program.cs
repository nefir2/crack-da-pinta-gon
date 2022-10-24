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
		async static Task Main(string[] args)
		{
			string the_folder = GetTheFolder();
			try { await Task.Run(() => Process.Start(the_folder)); }
			catch (Exception ex) { Console.WriteLine(ex.Message); }
			Endl("нажмите любую клавишу для завершения программы . . . ");
		}
		private static string GetTheFolder()
		{
			string[] some_folders = new string[]
			{
				@"\\26k-10-dc10\studocredir",
				@"C:\",
			};
			Console.WriteLine($"выберите одну из имеющихся папок, или введите свою: ");
			for (int i = 0; i < some_folders.Length; i++) Console.WriteLine($"{i + 1}. {some_folders[i]};");
			Console.WriteLine($"{some_folders.Length}. ввести свою папку.");
			int choice;
			while (true) 
			{
				try
				{
					Console.WriteLine("выберите один из вариантов: ");
					choice = int.Parse(Console.ReadLine()) - 1;
					if (choice == some_folders.Length)
					{
						Console.WriteLine("введите путь папки: ");
						return Console.ReadLine();
					}
					else if (choice < 0 || choice > some_folders.Length) continue;
					break;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					continue;
				}
			}
			string the_folder = some_folders[choice];

			return the_folder;
		}
		private static void Endl(string message)
		{
			Console.Write(message);
			Console.ReadKey(true);
		}
	}
}