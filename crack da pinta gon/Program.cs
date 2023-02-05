using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Diagnostics;
using System.Runtime.InteropServices;

using CIO;
using zxcqwe;

namespace crack_da_pinta_gon
{
	class Program
	{
		/// <summary>
		/// поле со стандартным титулом программы 
		/// </summary>
		private static string title;
		/// <summary>
		/// существует ли файл в пути <see cref="the_base_path"/>.
		/// </summary>
		private static bool isExists;
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
		private const string the_base_path = @"\\26k-10-dc10\studocredir\uc33_9\ \history"; //@"C:\users\1\desktop\examples.txt" 
		static Program() => title = Console.Title;
		/// <summary>
		/// запуск программы.
		/// </summary>
		private static void Main(string[] args)
		{
			foreach (var s in args) Console.Write(s + " : ");
			string arg = "";
			if (args.Length > 0)
			{
				string prog = args[0];
				StringBuilder ar = new StringBuilder("");
				if (args.Length > 1)
				{
					for (int i = 1; i < args.Length; i++) ar = ar.Append(args[i]);
				}

				Process.Start(prog, ar.ToString());
				return;
			}
			//for (int i = 0; i < args.Length; i++)
			//{
			//	if (args[i] == "virus") arg = args[i];
			//}
			//сделать консоль незакрываемой

			Console.ForegroundColor = ConsoleColor.DarkGray;

			if (IsExists(the_base_path)) some_folders = File.ReadAllLines(the_base_path);
			else some_folders = new string[] { };
			while (true)
			{
				string the_folder = GetTheFolder(arg);
				try
				{
					Process.Start(the_folder); //await Task.Run(() => Process.Start(the_folder));
					if (isInputed) { File.AppendAllText(the_base_path, the_folder + "\n"); isInputed = false; }
					if (File.Exists(the_base_path)) some_folders = File.ReadAllLines(the_base_path);
				}
				catch (Exception ex) { ColorFormat.Write($"%0ошибка: {ex.Message}\n\n", ConsoleColor.Red); }

				//if (Retry()) { Console.Clear(); continue; }
				//else break;
			}
		}
		/// <summary>
		/// проверка существования файла по указанному пути.
		/// </summary>
		/// <param name="path">путь, в котором должен находится файл.</param>
		/// <returns><see langword="true"/> если файл существует, иначе <see langword="false"/>.</returns>
		private static bool IsExists(string path)
		{ 
			//ColorFormat.Write($"%0waiting for \"{path}\". . . ", ConsoleColor.Green);
			isExists = File.Exists(path);

			//ColorFormat.Write($"\n\n%0path: %2{path}\n%0is existing: %1{isExists}\n\n\n", ConsoleColor.White, isExists ? ConsoleColor.Green : ConsoleColor.Red, ConsoleColor.Blue);
			return isExists;
		}
		/// <summary>
		/// метод вывода информации о работе программы в консоль.
		/// </summary>
		private static void Debug()
		{
			//ColorFormat.Write($"%0waiting for \"{the_base_path}\". . . ", ConsoleColor.Green);
			//bool isExists = File.Exists(the_base_path);
			var varColor = ConsoleColor.White;
			var truColor = ConsoleColor.Green;
			var falColor = ConsoleColor.Red;
			var litColor = ConsoleColor.Blue;
			ColorFormat.Write($"%0isInputed: %1{isInputed}\n", varColor, isInputed ? truColor : falColor);
			ColorFormat.Write($"%0path: %2{the_base_path}\n%0isExists: %1{isExists}\n", varColor, isExists ? truColor : falColor, litColor);
			if (some_folders.Length > 0)
			{
				ColorFormat.Write("%0some_folders: \n", varColor);
				for (int i = 0; i < some_folders.Length; i++)
				{
					var isEven = i % 2 == 0;
					ColorFormat.Write($"%0&2{i}:	%1{some_folders[i]}\n", isEven ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed, litColor, isEven ? ConsoleColor.Gray : ConsoleColor.DarkGray); //varColor
				}
				Console.WriteLine();
			}
			else ColorFormat.Write($"%0some_folders: %1{some_folders}\n\n", varColor, litColor);
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
			ColorFormat.Write("продолжить выполнение программы? %0y%1/%2n", ConsoleColor.Green, Default, ConsoleColor.DarkRed);
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
		private static string GetTheFolder(string input)
		{
			bool isUsed = false;
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
					if (input == "" || isUsed) input = Console.ReadLine();
					else isUsed = true;
					string lowinput = input.ToLower();
					if (input.Contains("1000") && input.Contains("-") && input.Contains("7")) //сделать парсер для этой команды.
					{
						SetTopmost(true);

						Console.Clear();
						Process.Start("https://www.youtube.com/watch?v=f3inPekeRYI");
						Console.ForegroundColor = ConsoleColor.Red;
						var stdTitle = Console.Title;
						Console.Title = "1000 - 7";
						zxc.zxcqwe();
						Console.Title = stdTitle;
						Console.ForegroundColor = ColorFormat.DefaultFore;
						SetTopmost(false);
						continue;
					}
					else if (lowinput.Contains("exit"))
					{
						choice = -3;
						Closer(3);
						break;
					}
					else if (lowinput.Equals("virus")) //считывание нажатий https://www.cyberforum.ru/csharp-beginners/thread2170178.html
					{
						Hider(true);
						while (true)
						{
							for (int i = 0; i < 10; i++)
							{
								Process.Start("https://www.youtube.com/watch?v=QJJYpsA5tv8");
								Thread.Sleep(3000);
								Hider(false);
							}
						}
					}
					else if (lowinput.StartsWith("open"))
					{
						bool Kavichkas = false, isError = false;
						StringBuilder inp = new StringBuilder(input);
						inp.Remove(0, 5);
						//Process.Start("https://www.youtube.com/watch?v=R8lHaEZYpCU");
						if (inp.Length <= 0) ColorFormat.Write("%0usage: open {name of program}\n", ConsoleColor.Red);
						int spacepos = -1;

						int? firstKavichka = null;
						int? secondKavichka = null;
						for (int i = 0; i < inp.Length; i++)
						{
							if (inp[i] == '\"')
							{
								Kavichkas = true;
								spacepos = -1;
								if (firstKavichka is null) firstKavichka = i;
								else if (secondKavichka is null) secondKavichka = i;
								else
								{
									ColorFormat.WriteLine("%0найдена лишняя кавычка.", ConsoleColor.Red);
									isError = true;
									break;
								}
							}
							if (inp[i] == ' ') //нахождение первого пробела после названия программы.
							{
								spacepos = i;
								if (!Kavichkas) break;
							}
						}
						if (isError) continue;
						string program, args = "";
						if (!(firstKavichka is null) && !(secondKavichka is null)) program = ColorFormat.Cut(inp.ToString(), (int)(firstKavichka + 1), (int)secondKavichka);
						else program = ColorFormat.Cut(inp.ToString(), 0, spacepos == -1 ? inp.Length : spacepos);
						//Console.WriteLine(program);
						Process opened;
						if (spacepos != -1)
						{
							int prln = program.Length + (firstKavichka is null ? 0 : 1) + (secondKavichka is null ? 0 : 1);
							inp.Remove(0, prln);
							string inpu = inp.ToString().Trim();
							args = ColorFormat.Cut(inpu, 0, inpu.Length);
							opened = Process.Start(program, args);
						}
						else opened = Process.Start(program);
						//Console.WriteLine(args);
						//SetTopmost(opened.MainWindowHandle, true);
						//Console.Clear();
						Thread.Sleep(1000);
						continue;
					}
					else if (lowinput.Equals("bash"))
					{
						Process.Start("C:/program files/git/git-bash.exe");
						//Console.Clear();
						continue;
					}
					else if (lowinput.Contains("title"))
					{
						if (input.Length <= 6) Console.WriteLine(Console.Title + "\n\n");
						else
						{
							string name = ColorFormat.Cut(input, 6, input.Length);
							if (name.ToLower().Equals("%default%")) Console.Title = title;
							else Console.Title = name;
						}
						continue;
					}
					else if (lowinput.Contains("twink"))
					{
						//https://www.cyberforum.ru/csharp-net/thread2695637.html
						continue;
					}
					else if (
							lowinput.Contains("rick") && (lowinput.Contains("roll") || lowinput.Contains("astley")) ||
							lowinput.Contains("never") && lowinput.Contains("gonna") && lowinput.Contains("give") && lowinput.Contains("you") && lowinput.Contains("up")
						)
					{
						Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
						continue;
					}
					else if (lowinput.StartsWith("debug"))
					{
						//Console.Clear();
						Debug(); //можно и настроить параметры команды, чтобы выводило только определённое поле.
						continue;
					}
					else if (lowinput.StartsWith("clr") || lowinput.StartsWith("clear"))
					{
						Console.Clear();
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
						//Console.Clear();
						continue;
					}
					else if (choice == -26)
					{
						Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
						//Console.Clear();
						continue;
					}
					else if (choice == -3) ShowMessageBox("гений", "решил мне тут потыкать программу, да? тогда лови кучу ошибок в консоль, если конечно увидишь как она их выводит.");
					else if (choice < -2 || choice >= some_folders.Length)
					{
						//Console.Clear();
						ColorFormat.Write("%0ошибка: введённое значение оказалось больше или меньше допущенных.\n\n", ConsoleColor.Red);
						continue;
					}
					break;
				}
				catch (Exception ex)
				{
					//Console.Clear();
					ColorFormat.Write($"%0ошибка: {ex.Message}\n\n", ConsoleColor.Red);
					continue;
				}
			}
			if (choice == -3) throw new Exception("было вызвано исключение пользователем. экстренное закрытие консоли.\nи вот ты на полном серьёзе читаешь это?"); //
			return some_folders[choice];
		}

		//private static (string, string) ParseProgramAndArgs(string toParse)
		//{
		//	bool Kavichkas = false, isError = false;
		//	StringBuilder inp = new StringBuilder(toParse);
		//	inp.Remove(0, 5);
		//	//Process.Start("https://www.youtube.com/watch?v=R8lHaEZYpCU");
		//	if (inp.Length <= 0) ColorFormat.Write("%0usage: open {name of program}\n", ConsoleColor.Red);
		//	int spacepos = -1;

		//	int? firstKavichka = null;
		//	int? secondKavichka = null;
		//	for (int i = 0; i < inp.Length; i++)
		//	{
		//		if (inp[i] == '\"')
		//		{
		//			Kavichkas = true;
		//			spacepos = -1;
		//			if (firstKavichka is null) firstKavichka = i;
		//			else if (secondKavichka is null) secondKavichka = i;
		//			else
		//			{
		//				ColorFormat.WriteLine("%0найдена лишняя кавычка.", ConsoleColor.Red);
		//				isError = true;
		//				break;
		//			}
		//		}
		//		if (inp[i] == ' ') //нахождение первого пробела после названия программы.
		//		{
		//			spacepos = i;
		//			if (!Kavichkas) break;
		//		}
		//	}
		//	if (isError) continue;
		//	string program, args = "";
		//	if (!(firstKavichka is null) && !(secondKavichka is null)) program = ColorFormat.Cut(inp.ToString(), (int)(firstKavichka + 1), (int)secondKavichka);
		//	else program = ColorFormat.Cut(inp.ToString(), 0, spacepos == -1 ? inp.Length : spacepos);
		//	//Console.WriteLine(program);
		//	Process opened;
		//	if (spacepos != -1)
		//	{
		//		int prln = program.Length + (firstKavichka is null ? 0 : 1) + (secondKavichka is null ? 0 : 1);
		//		inp.Remove(0, prln);
		//		string inpu = inp.ToString().Trim();
		//		args = ColorFormat.Cut(inpu, 0, inpu.Length);
		//		opened = Process.Start(program, args);
		//	}
		//	else opened = Process.Start(program);
		//	//Console.WriteLine(args);
		//}

		#region WINDOWS API
		private static IntPtr hWnd;
		#region imports
		//https://habr.com/ru/company/otus/blog/598409/?ysclid=lacmcadxbe475507780
		[DllImport("user32.dll", SetLastError = true)][return: MarshalAs(UnmanagedType.Bool)] public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);
		[DllImport("user32.dll")] public static extern int MessageBox(IntPtr hwnd, String text, String caption, int options);
		private const int HWND_TOPMOST_ON = -1;
		private const int HWND_TOPMOST_OFF = -2; //добавлено собственноручно, методом тыка.
		private const int SWP_NOMOVE = 0x0002;
		private const int SWP_NOSIZE = 0x0001;
		[DllImport("user32.dll")] public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_HIDE = 0;
		const int SW_SHOW = 5;
		[DllImport("kernel32.dll")] public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")] public static extern void ExitProcess([In] uint uExitCode);


		#region keyhook
		//https://www.cyberforum.ru/csharp-beginners/thread2170178.html
		public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam); //Callback делегат(для вызова callback метода)
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] public static extern short GetAsyncKeyState(int vKey);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)][return: MarshalAs(UnmanagedType.Bool)] public static extern bool UnhookWindowsHookEx(IntPtr hhk);
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)] public static extern IntPtr GetModuleHandle(string lpModuleName);
		#endregion не будет работать без прав, нужен доступ к new Process().MainModule
		#endregion

		/// <summary>
		/// установка главного окна поверх всех окон.
		/// </summary>
		/// <param name="topmost">
		/// если значение <see langword="true"/>, консоль поверх всех окон, <br/>
		/// иначе если <see langword="false"/> - не поверх всех окон.
		/// </param>
		public static void SetTopmost(bool topmost)
		{
			hWnd = Process.GetCurrentProcess().MainWindowHandle;

			_ = SetWindowPos(
				hWnd,
				new IntPtr(topmost ? HWND_TOPMOST_ON : HWND_TOPMOST_OFF),
				0, 0, 0, 0,
				SWP_NOMOVE | SWP_NOSIZE
			);
		}
		/// <summary>
		/// установка указанного окна поверх всех окон.
		/// </summary>
		/// <param name="hWnd">окно, к которому применяется метод.</param>
		/// <param name="topmost">
		/// если значение <see langword="true"/>, консоль поверх всех окон, <br/>
		/// иначе если <see langword="false"/> - не поверх всех окон.
		/// </param>
		public static void SetTopmost(IntPtr hWnd, bool topmost)
		{
			hWnd = Process.GetCurrentProcess().MainWindowHandle;

			_ = SetWindowPos(
				hWnd,
				new IntPtr(topmost ? HWND_TOPMOST_ON : HWND_TOPMOST_OFF),
				0, 0, 0, 0,
				SWP_NOMOVE | SWP_NOSIZE
			);
		}
		/// <summary>
		/// вызов диалогового окна.
		/// </summary>
		/// <param name="caption">название (title) окна.</param>
		/// <param name="message">сообщение в самом окне.</param>
		public static void ShowMessageBox(string caption, string message)
		{
			MessageBox(IntPtr.Zero, message, caption, 0); //"здарова братан" //"чо как жизнь твоя?"
		}
		/// <summary>
		/// скрытие главного окна.
		/// </summary>
		/// <param name="isHidden"><see langword="true"/> чтобы скрыть, <br/><see langword="false"/> чтобы показать.</param>
		public static void Hider(bool isHidden)
		{
			hWnd = GetConsoleWindow();
			ShowWindow(hWnd, isHidden ? SW_HIDE : SW_SHOW);
		}
		/// <summary>
		/// метод завершения работы программы, если идёт выполнение работы не в <see cref="Main"/>.
		/// </summary>
		/// <param name="ExitCode">код, с которым завершается работа программы.</param>
		public static void Closer(uint ExitCode = 0)
		{
			ExitProcess(ExitCode);
		}
		#endregion
	}
}