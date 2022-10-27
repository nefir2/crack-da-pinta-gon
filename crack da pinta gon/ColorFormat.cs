using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crack_da_pinta_gon
{
	static class ColorFormat
	{
		/// <summary>
		/// стандартное значение цвета знаков.
		/// </summary>
		private static ConsoleColor defaultFore;
		/// <summary>
		/// стандартное значение цвета фона знаков.
		/// </summary>
		private static ConsoleColor defaultBack;

		public static ConsoleColor DefaultFore { get => defaultFore; }
		public static ConsoleColor DefaultBack { get => defaultBack; }

		/// <summary>
		/// статический конструктор для выдачи значений полям.
		/// </summary>
		static ColorFormat()
		{
			defaultFore = Console.ForegroundColor;
			defaultBack = Console.BackgroundColor;
		}

		/// <summary>
		/// выводит строку с указанными цветами с помощью знаков процент (%) и амперсанд.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="setWithEndDefaultColor"></param>
		/// <param name="colors"></param>
		public static void Write(string value, bool setWithEndDefaultColor, params ConsoleColor[] colors)
		{
			if (setWithEndDefaultColor)
			{
				var DefaultFore = Console.ForegroundColor; //получение цвета в консоли перед началом работы метода.
				var DefaultBack = Console.BackgroundColor;
				Write(value, colors);
				Console.ForegroundColor = DefaultFore; //возвращение цвета на изначальный после окончания работы метода.
				Console.BackgroundColor = DefaultBack;
			}
			else Write(value, colors);
		}
		/// <summary>
		/// выводит строку с указанными цветами с помощью знаков процент (%) и амперсанд. <br/>
		/// пример: <example>"%0"</example>
		/// </summary>
		/// <remarks>
		/// для того чтобы изменить цвет на для знаков используйте процент, 
		/// для изменения фонового цвета используйте амперсанд.
		/// </remarks>
		/// <param name="value">строка, в которой используются цвета</param>
		/// <param name="colors"></param>
		public static void Write(string value, params ConsoleColor[] colors)
		{
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] == '%' || value[i] == '&')
				{
					if (i + 1 != value.Length && int.TryParse(value[i + 1].ToString(), out int arg))
					{
						if (arg > colors.Length) throw new ArgumentException("указанный параметр не был найден.");
						ChangeColor(value[i] == '%', colors[arg]);
						i++;
						continue;
					}
					else if (value[i + 1] == '{' && !(i + 3 >= value.Length))
					{
						//i+=2;
						for (int j = i + 2; j < value.Length; j++)
						{
							if (value[j] == '}')
							{
								if (int.TryParse(Cut(value, i, j), out arg))
								{
									ChangeColor(value[i - 2] == '%', colors[arg]);
									i = j;
									continue;
								}
								else throw new ArgumentException("указанный номер параметра не является числом.");
							}
							else if (j == value.Length - 1) throw new ArgumentException("закрывающая скобка \"}\" не была найдена."); //если цикл дошёл до конца, но закрывающая скобка была не найдена - выбрасывается исключение.
						}
					}
					else Console.Write(value[i]);
				}
				else Console.Write(value[i]);
			}
		}
		/// <summary> изменяет цвет последующих знаков на указанный в параметрах. </summary>
		/// <param name="isPercent">
		/// если <see cref="true"/> используется <see cref="Console.ForegroundColor"/>, <br/>
		/// иначе используется <see cref="Console.BackgroundColor"/>. 
		/// </param>
		/// <param name="color">цвет, на который меняется текст или фон текста.</param>
		public static void ChangeColor(bool isPercent, ConsoleColor color)
		{
			if (isPercent) Console.ForegroundColor = color;
			else Console.BackgroundColor = color;
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
		public static string Cut(string value, int start, int end)
		{
			if (start > end) throw new ArgumentException("начальная позиция для вырезания подстроки не может быть больше конечной позиции.");
			if (start < 0 || end < 0) throw new IndexOutOfRangeException("начало или конец вырезания не может быть меньше нуля.");
			
			string cutted = "";
			for (int i = start; i < end; i++) cutted += value[i];
			return cutted;
		}
	}
}