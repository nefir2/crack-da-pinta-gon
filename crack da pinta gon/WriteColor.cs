using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crack_da_pinta_gon
{
	class WriteColor
	{
		/// <summary>
		/// выводит строку в консоль через <see cref="Console.Write(string)"/>, с указанными цветами в указанных местах.
		/// </summary>
		/// <remarks>
		/// при завершении работы метода, возвращает цвет который был на моменте запуска.
		/// </remarks>
		/// <param name="value">
		/// строка куда подставляются цвета. <br/>
		/// для подстановки цвета используйте "<c>%</c>"
		/// </param>
		/// <param name="colors">цвета, подставляемые в строку</param>
		public static void Write(string value, params ConsoleColor[] colors)
		{
			var Default = Console.ForegroundColor; //получение цвета в консоли перед началом работы метода.

			for (int i = 0; i < colors.Length; i++)
			{

			}

			Console.ForegroundColor = Default; //возвращение цвета на изначальный после окончания работы метода.
		}
		/// <summary>
		/// разделение строки на подстроки до указанных позиций знака "<c>%</c>".
		/// </summary>
		/// <param name="value">строка в которой имеются знаки "<c>%</c>"</param>
		/// <returns>возвращает подстроки перед знаками "<c>%</c>".</returns>
		private static string[] Parsed(string value, int percents)
		{
			StringBuilder strb = new StringBuilder(value);
			int added = 0;
			int lastI = 0;
			string[] substrings = new string[percents];
			for (int i = 0; i < strb.Length; i++)
			{
				if (value[i] == '%') substrings[added] = Cut(value, lastI, i);
			}
			return substrings;
		}

		private static string Cut(string value, int start, int end)
		{
			string cutted = "";
			for (int i = start; i < end; i++) cutted.Append(value[i]);
			return cutted;
		}
	}
}
