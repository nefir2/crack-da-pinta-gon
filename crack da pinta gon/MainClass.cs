using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crack_da_pinta_gon
{
	class MainClass
	{
		internal static void Main()
		{
			Process[] processes = Process.GetProcesses();
			int changed = processes.Length;
			while (true)
			{
				processes = Process.GetProcesses();
				if (processes.Length != changed)
				{
					Console.WriteLine($"length = {processes.Length}\nchanged = {changed}");
					Console.Beep();
					checkWho(processes);
				}
				changed = processes.Length;
			}
			//for (int i = 0; i < processes.Length; i++)
			//{
			//}

			//ConsoleColor[] colors = new ConsoleColor[16];
			//for (int i = 0; i < 16; i++) { colors[i] = (ConsoleColor)i; }
			//do
			//{
			//	ColorFormat.Write($"%9&{{15}}ошибка: %7&{{10}}произошла ошибка%{{\n", true, colors);
			//} while (Retry());

			Console.ReadKey();
		}
		private static void checkWho(Process[] processes)
		{
			Process[] now = Process.GetProcesses();
			int count = processes.Length > now.Length ? now.Length : processes.Length;
			for (int i = 0; i < count; i++)
			{
				Console.WriteLine($"Process number = {i}");
				if (processes[i].ProcessName != now[i].ProcessName) ShowProcess(now, i);
				break;
			}
		}
		private static void ShowProcess(Process[] processes, int i)
		{
			ColorFormat.Write($"%{i % 2}proc name = %2{processes[i].ProcessName}\n", true, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White);
			ColorFormat.Write($"%{i % 2}proc title = %2{processes[i].MainWindowTitle}\n", true, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White);
			ColorFormat.Write($"%{i % 2}tostring = %2{processes[i]}\n", true, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White);
			try { ColorFormat.Write($"%{i % 2}start time = %2{processes[i].StartTime}\n", true, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.White); }
			catch (Exception ex) { ColorFormat.Write($"%{i % 2}start time = %2{ex.Message}\n", true, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red); }
		}
		private static bool Retry()
		{
			ConsoleColor Default = Console.ForegroundColor;
			ColorFormat.Write("продолжить выполнение программы? %0y%1/%2n", ConsoleColor.Green, Default, ConsoleColor.DarkRed);
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