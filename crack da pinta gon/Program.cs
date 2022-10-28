//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace crack_da_pinta_gon
//{
//	class Program
//	{
//		/// <summary>
//		/// поле хранящее значение типа <see cref="bool"/>, означающее:<br/>
//		/// добавлена ли новая папка с помощью ввода, или нет.
//		/// </summary>
//		/// <remarks>
//		/// <see langword="true"/> если новую папку ввели, <br/>
//		/// <see langword="false"/> если новую папку выбрали из списка.
//		/// </remarks>
//		private static bool isInputed;
//		/// <summary>
//		/// стандартные пути папок для вывода в виде выбираемых элементов из списка.
//		/// </summary>
//		private static string[] some_folders;
//		/// <summary>
//		/// хранилище списка 
//		/// </summary>
//		private const string the_base_path = @"\\26k-10-dc10\studocredir\ахтамовв\examples.txt"; // @"C:\users\1\desktop\examples.txt"

//		/// <summary>
//		/// запуск программы.
//		/// </summary>
//		static void Main()
//		{
//			if (File.Exists(the_base_path)) some_folders = File.ReadAllLines(the_base_path);
//			else some_folders = new string[] { };
//			while (true)
//			{
//				string the_folder = GetTheFolder();
//				try 
//				{
//					Process.Start(the_folder); //await Task.Run(() => Process.Start(the_folder));
//					if (isInputed) { File.AppendAllText(the_base_path, the_folder + "\n"); isInputed = false; }
//					if (File.Exists(the_base_path)) some_folders = File.ReadAllLines(the_base_path);
//				} 
//				catch (Exception ex) { ColorFormat.Write($"%{{0}}ошибка: {ex.Message}\n", true, ConsoleColor.Red); }

//				if (Retry()) { Console.Clear(); continue; }
//				else break;
//			}
//		}

//		/// <summary>
//		/// вывод сообщения для повтора работы программы и ожидания выбора.
//		/// </summary>
//		/// <returns>
//		/// <see langword="true"/> если пользователь выбрал продолжение работы программы, <br/>
//		/// <see langword="false"/> если пользователь выбрал завершение работы программы.
//		/// </returns>
//		private static bool Retry()
//		{
//			ConsoleColor Default = Console.ForegroundColor;
//			ColorFormat.Write("продолжить выполнение программы? %0y%1/%2n", true, ConsoleColor.Green, Default, ConsoleColor.DarkRed);
//			while (true)
//			{
//				string ans = Console.ReadKey(true).KeyChar.ToString();
//				if (ans == "y") { Console.WriteLine(); return true; }
//				else if (ans == "n") return false;
//				else continue;
//			}
//		}
//		private static string GetTheFolder()
//		{
//			Console.WriteLine("выберите одну из имеющихся папок, или введите свою.");
//			for (int i = 0; i < some_folders.Length; i++) ColorFormat.Write($"{i + 1}. %0\"{some_folders[i]}\";\n", true, i % 2 == 0 ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed);
//			ColorFormat.Write($"{some_folders.Length + 1}. %0ввести свою папку.\n", true, ConsoleColor.DarkGreen);
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
//						isInputed = true;
//						return Console.ReadLine(); //встроить парсер пути
//					}
//					else if (choice < 0 || choice > some_folders.Length)
//					{
//						ColorFormat.Write("%0ошибка: введённое значение оказалось больше или меньше допущенных.\n", true, ConsoleColor.Red);
//						continue;
//					}
//					break;
//				}
//				catch (Exception ex)
//				{
//					ColorFormat.Write("%0ошибка: " + ex.Message, true, ConsoleColor.Red);
//					continue;
//				}
//			}
//			return some_folders[choice];
//		}
//	}
//}