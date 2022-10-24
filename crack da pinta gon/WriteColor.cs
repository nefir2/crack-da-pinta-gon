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
		public void Write(string value, params ConsoleColor[] colors)
		{
			var Default = Console.ForegroundColor; //получение цвета в консоли перед началом работы метода.

			for (int i = 0; i < colors.Length; i++)
			{
				for (int j = 0; j < value.Length; j++)
				{

				}
			}

			Console.ForegroundColor = Default; //возвращение цвета на изначальный после окончания работы метода.
		}
		private string[] Parsed(string value) { return null; }
	}
}
