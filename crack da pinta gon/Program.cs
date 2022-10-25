//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace crack_da_pinta_gon
//{
//	class Program
//	{
//		static void Main()
//		{
//			while (true)
//			{
//				string the_folder = GetTheFolder();
//				try { Process.Start(the_folder); } //await Task.Run(() => Process.Start(the_folder));
//				catch (Exception ex)
//				{
//					ColorFormat.Write($"%ошибка: {ex.Message}\n", ConsoleColor.Red);
//				}


//				if (Retry()) { Console.Clear(); continue; }
//				else break;
//			}
//			//Endl("нажмите любую клавишу для завершения программы . . . ");
//		}
//		private static bool Retry()
//		{
//			Console.Write("продолжить выполнение программы? ");
//			var Default = Console.ForegroundColor;
//			Console.ForegroundColor = ConsoleColor.Green;
//			Console.Write("y");
//			Console.ForegroundColor = Default;
//			Console.Write("/");
//			Console.ForegroundColor = ConsoleColor.DarkRed;
//			Console.Write("n");

//			Console.ForegroundColor = Default;
//			while (true)
//			{
//				string ans = Console.ReadKey(true).KeyChar.ToString();
//				Console.WriteLine();
//				if (ans == "y") return true;
//				else if (ans == "n") return false;
//				//else continue;
//			}
//		}
//		private static string GetTheFolder()
//		{
//			string[] some_folders = new string[]
//			{
//				@"\\26k-10-dc10\studocredir",
//				@"C:\",
//			};
//			Console.WriteLine($"выберите одну из имеющихся папок, или введите свою.");
//			for (int i = 0; i < some_folders.Length; i++) Console.WriteLine($"{i + 1}. \"{some_folders[i]}\";");
//			Console.WriteLine($"{some_folders.Length + 1}. ввести свою папку.");
//			int choice;
//			while (true)
//			{
//				try
//				{
//					Console.Write("\nвыберите один из вариантов: ");
//					choice = int.Parse(Console.ReadLine()) - 1;
//					if (choice == some_folders.Length)
//					{
//						Console.Write("введите путь папки: ");
//						return Console.ReadLine(); //встроить парсер пути
//					}
//					else if (choice < 0 || choice > some_folders.Length)
//					{
//						Console.WriteLine("введённое значение оказалось больше или меньше допущенных.");
//						continue;
//					}
//					break;
//				}
//				catch (Exception ex)
//				{
//					Console.WriteLine(ex.Message);
//					continue;
//				}
//			}
//			string the_folder = some_folders[choice];

//			return the_folder;
//		}
//	}
//}