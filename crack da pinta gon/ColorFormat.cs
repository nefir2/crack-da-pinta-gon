using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crack_da_pinta_gon
{
	class ColorFormat
	{
		/// <summary>
		/// выводит строку в консоль через <see cref="Console.Write(string)"/>, с указанными цветами в указанных местах.
		/// </summary>
		/// <remarks>
		/// при завершении работы метода, возвращает цвет который был на моменте запуска. <br/>
		/// сами знаки "<c>%</c>" удаляются из строки.
		/// </remarks>
		/// <param name="value">
		/// строка куда подставляются цвета. <br/><br/>
		/// для подстановки цвета используйте "<c>%</c>" <br/>
		/// для подстановки "<c>%</c>" используйте "<c>%%</c>".
		/// </param>
		/// <param name="colors">цвета, подставляемые в строку</param>
		/// <exception cref="ArgumentException"/>
		public static void Write(string value, params ConsoleColor[] colors)
		{
			var Default = Console.ForegroundColor; //получение цвета в консоли перед началом работы метода.

			string[] strings = Parser(value, colors.Length);
			if (strings.Length - 1 != colors.Length) throw new ArgumentException("");
			for (int i = 0; i < colors.Length; i++)
			{
				if (i == 0) Console.Write(strings[i]);
				else if (i < colors.Length) //not working
				{
					Console.Write(strings[i]);
					Console.ForegroundColor = colors[i];
				}
				else Console.Write(strings[i + 1]);
			}

			Console.ForegroundColor = Default; //возвращение цвета на изначальный после окончания работы метода.
		}
		/// <summary> разделение строки на подстроки до указанных позиций знака "<c>%</c>". </summary>
		/// <remarks> знаки "<c>%</c>" не сохраняются. </remarks>
		/// <param name="value">строка в которой имеются знаки "<c>%</c>"</param>
		/// <returns>возвращает подстроки перед знаками "<c>%</c>".</returns>
		private static string[] Parser(string value, int percents)
		{
			int added = 0;
			int lastI = 0;
			string[] substrings = new string[percents + 1];
			for (int i = 0; i < value.Length; i++)
			{
				if (i + 1 != value.Length && value[i] == '%' && value[i + 1] == '%')  //если два процента подряд - удаление одного из них, и пропуск вставки цвета.
				{
					StringBuilder sbvalue = new StringBuilder(value);
					sbvalue.Remove(i, 1);
					value = sbvalue.ToString();
					i++;
					continue;
				}
				else if (value[i] == '%' || i + 1 == value.Length)
				{
					substrings[added] = Cut(value, lastI, i);
					added++;
					lastI = i + 1;
				}
			}
			//if (added != percents) throw new ArgumentException("количество подстрок не соответствует количеству процентов.");
			return substrings;
		}
		/// <summary>
		/// метод вырезающий подстроку по указанным позициям.
		/// </summary>
		/// <param name="value">строка, из которой вырезается подстрока.</param>
		/// <param name="start">точка начала выреза.</param>
		/// <param name="end">точка окончания выреза.</param>
		/// <returns>вырезанная подстрока.</returns>
		/// <exception cref="ArgumentException"/>
		/// <exception cref="IndexOutOfRangeException"/>
		private static string Cut(string value, int start, int end)
		{
			if (start > end) throw new ArgumentException("начальная позиция для вырезания подстроки не может быть больше конечной позиции.");
			if (start < 0 || end < 0) throw new IndexOutOfRangeException("начало или конец вырезания не может быть меньше нуля.");
			
			string cutted = "";
			for (int i = start; i < end; i++) cutted += value[i];
			return cutted;
		}
	}
}