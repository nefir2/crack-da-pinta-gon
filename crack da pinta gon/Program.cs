using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using CIO;
using zxcqwe;

namespace crack_da_pinta_gon
{
	class Program
	{
		[DllImport("user32.dll", SetLastError = true)] //this is things from windows api.
		[return: MarshalAs(UnmanagedType.Bool)] //https://habr.com/ru/company/otus/blog/598409/?ysclid=lacmcadxbe475507780
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);

		private const int HWND_TOPMOST = -1;
		private const int SWP_NOMOVE = 0x0002;
		private const int SWP_NOSIZE = 0x0001;


		/// <summary>
		/// поле хранящее значение типа <see cref="bool"/>, означающее:<br/>
		/// добавлена ли новая папка с помощью ввода, или нет.
		/// </summary>
		/// <remarks>
		/// <see langword="true"/> если новую папку ввели, <br/>
		/// <see langword="false"/> если новую папку выбрали из списка.
		/// </remarks>
		private static bool isInputed;
		/// <summary>
		/// стандартные пути папок для вывода в виде выбираемых элементов из списка.
		/// </summary>
		private static string[] some_folders;
		/// <summary>
		/// хранилище списка 
		/// </summary>
		private const string the_base_path = @"\\26k-10-dc10\studocredir\uc33_9\ \history"; // @"C:\users\1\desktop\examples.txt"

		/// <summary>
		/// запуск программы.
		/// </summary>
		static void Main()
		{
			Console.ForegroundColor = ConsoleColor.DarkGray;

			if (File.Exists(the_base_path)) some_folders = File.ReadAllLines(the_base_path);
			else some_folders = new string[] { };
			while (true)
			{
				string the_folder = GetTheFolder();
				try
				{
					Process.Start(the_folder); //await Task.Run(() => Process.Start(the_folder));
					if (isInputed) { File.AppendAllText(the_base_path, the_folder + "\n"); isInputed = false; }
					if (File.Exists(the_base_path)) some_folders = File.ReadAllLines(the_base_path);
				}
				catch (Exception ex) { ColorFormat.Write($"%0ошибка: {ex.Message}\n\n", ConsoleColor.Red); }

				if (Retry()) { Console.Clear(); continue; }
				else break;
			}
		}

		/// <summary>
		/// вывод сообщения для повтора работы программы и ожидания выбора.
		/// </summary>
		/// <returns>
		/// <see langword="true"/> если пользователь выбрал продолжение работы программы, <br/>
		/// <see langword="false"/> если пользователь выбрал завершение работы программы.
		/// </returns>
		private static bool Retry()
		{
			ConsoleColor Default = Console.ForegroundColor;
			ColorFormat.Write("продолжить выполнение программы? %0y%1/%2n",ConsoleColor.Green, Default, ConsoleColor.DarkRed);
			while (true)
			{
				string ans = Console.ReadKey(true).KeyChar.ToString();
				if (ans == "y") { Console.WriteLine(); return true; }
				else if (ans == "n") return false;
				else continue;
			}
		}
		/// <summary>
		/// метод получения пути папки из ввода в консоли.
		/// </summary>
		/// <returns>путь к какой-либо папке типа <see cref="string"/>.</returns>
		private static string GetTheFolder()
		{
			int choice;
			while (true)
			{
				Console.WriteLine("выберите одну из имеющихся папок, или введите свою.");
				//ColorFormat.Write($"-2. %0удалить историю открытых папок.\n", ConsoleColor.DarkRed);
				ColorFormat.Write($"-1. %0ввести свою папку.\n", ConsoleColor.DarkGreen);
				for (int i = 0; i < some_folders.Length; i++) ColorFormat.Write($"{i}. %0\"{some_folders[i]}\";\n", i % 2 == 0 ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed);
				try
				{
					Console.Write("\nвыберите один из вариантов: ");
					string input = Console.ReadLine();
					if (input.Contains("1000") && input.Contains("-") && input.Contains("7"))
					{
						IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;
						_ = SetWindowPos(hWnd, new IntPtr(HWND_TOPMOST), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);



						Console.Clear();
						Process.Start("https://www.youtube.com/watch?v=f3inPekeRYI");
						Console.ForegroundColor = ConsoleColor.Red;
						var stdTitle = Console.Title;
						Console.Title = "1000 - 7";
						zxc.zxcqwe();
						Console.Title = stdTitle;
						Console.ForegroundColor = ColorFormat.DefaultFore;
						_ = SetWindowPos(hWnd, new IntPtr(0), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
						continue;
					}
					choice = int.Parse(input);
					if (choice == -1) //choice == some_folders.Length
					{
						Console.Write("введите путь папки: ");
						isInputed = true;
						return Console.ReadLine(); //встроить парсер пути
					}
					else if (choice == -2) //choice == some_folders.Length + 1
					{
						if (File.Exists(the_base_path)) File.Delete(the_base_path);
						some_folders = new string[] { };
						Console.Clear();
						continue;
					}
					else if (choice == -26)
					{
						Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
						Console.Clear();
						continue;
					}
					else if (choice < -2 || choice >= some_folders.Length)
					{
						Console.Clear();
						ColorFormat.Write("%0ошибка: введённое значение оказалось больше или меньше допущенных.\n\n", ConsoleColor.Red);
						continue;
					}
					break;
				}
				catch (Exception ex)
				{
					ColorFormat.Write($"%0ошибка: {ex.Message}\n\n", ConsoleColor.Red);
					continue;
				}
			}
			return some_folders[choice];
		}
	}
}