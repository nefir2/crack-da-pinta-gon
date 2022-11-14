using System;
using System.Text;
namespace CIO
{
	/// <summary> класс для контроля ввода и вывода значений в консоли. </summary>
	public static class ConsIO
	{
		private static readonly string всеКлавишы = "`1234567890-=	qwertyuiop[]asdfghjkl;'\\zxcvbnm,./~!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL:\"|ZXCVBNM<>?  ";
		#region Input
		/// <summary> ввод целочисленного числа с очисткой консоли при завершении. </summary>
		/// <param name="messageForInput">сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <param name="errorMessageEmpty">сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>.</param>
		/// <param name="errorMessageLiterals">сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>.</param>
		/// <returns>консольный ввод целочисленного числа.</returns>
		public static int GetIntClr(string messageForInput, string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						ShowClrLn(errorMessageEmpty);
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						ShowClrLn(errorMessageLiterals);
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа с очисткой консоли при завершении. </summary>
		/// <remarks> сообщения при ошибке отключены. </remarks>
		/// <param name="messageForInput">сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <returns>консольный ввод целочисленного числа.</returns>
		public static int GetIntClr(string messageForInput)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						Clr();
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						Clr();
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа с очисткой консоли при завершении. </summary>
		/// <remarks> не выводит сообщение для ввода .</remarks>
		/// <param name="errorMessageEmpty">сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>.</param>
		/// <param name="errorMessageLiterals">сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>.</param>
		/// <returns>консольный ввод целочисленного числа.</returns>
		public static int GetIntClr(string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						ShowClrLn(errorMessageEmpty);
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						ShowClrLn(errorMessageLiterals);
						Show(str);
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа с очисткой консоли при завершении. </summary>
		/// <remarks> сообщения об ошибках отключены, сообщение о вводе не выводится. </remarks>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetIntClr()
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						Clr();
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						Clr();
						Show(str);
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа с переносом курсора при завершении. </summary>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetIntLn(string messageForInput, string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						ShowLn(errorMessageEmpty);
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						ShowLn(errorMessageLiterals);
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа с переносом курсора при завершении. </summary>
		/// <remarks> сообщения об ошибках отключены. </remarks>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetIntLn(string messageForInput)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						Ln();
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						Ln();
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа с переносом курсора при завершении. </summary>
		/// <remarks> не выводит сообщение о вводе. </remarks>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetIntLn(string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						ShowLn(errorMessageEmpty);
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						ShowLn(errorMessageLiterals);
						Show(str);
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа с переносом курсора при завершении. </summary>
		/// <remarks> не выводит сообщение о вводе, сообщения об ошибках отключены. </remarks>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetIntLn()
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						Ln();
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						Ln();
						Show(str);
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа без переноса курсора или очистки консоли. </summary>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetInt(string messageForInput, string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else
					{
						Show(errorMessageEmpty);
						Show($" {messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						Show(errorMessageLiterals);
						Show($" {messageForInput}{str}");
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа без переноса курсора или очистки консоли. </summary>
		/// <remarks> сообщения об ошибках отключены. </remarks>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetInt(string messageForInput)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else Show($" {messageForInput}{str}");
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else Show($" {messageForInput}{str}");
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа без переноса курсора или очистки консоли. </summary>
		/// <remarks> сообщение о вводе отключено. </remarks>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetInt(string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else
					{
						Show(errorMessageEmpty + " ");
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else
					{
						ShowLn(errorMessageLiterals + " ");
						Show(str);
					}
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод целочисленного числа без переноса курсора или очистки консоли. </summary>
		/// <remarks> сообщения об ошибках отключены, сообщение о вводе не выводится. </remarks>
		/// <returns> консольный ввод целочисленного числа. </returns>
		public static int GetInt()
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else Show(" " + str);
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar))
					{
						Show(odin.KeyChar);
						str.Append(odin.KeyChar);
					}
					else Show(" " + str);
				}
			} while (cycle);
			return Convert.ToInt32(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с очисткой консоли при завершении. </summary>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> число с плавающей точкой .</returns>
		public static double GetDoubleClr(string messageForInput, string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						ShowClrLn(errorMessageEmpty);
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						ShowClrLn(errorMessageLiterals);
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с очисткой консоли при завершении. </summary>
		/// <remarks> сообщения об ошибках отключены. </remarks>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDoubleClr(string messageForInput)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						Clr();
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						Clr();
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с очисткой консоли при завершении. </summary>
		/// <remarks> сообщение о вводе не выводится.</remarks>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDoubleClr(string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						ShowClrLn(errorMessageEmpty);
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						ShowClrLn(errorMessageLiterals);
						Show(str);
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с очисткой консоли при завершении. </summary>
		/// <remarks> сообщения о вводе и ошибках не выводятся.</remarks>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDoubleClr()
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Clr();
					}
					else
					{
						Clr();
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						Clr();
						Show(str);
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с переносом курсора при завершении. </summary>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> число с плавающей точкой .</returns>
		public static double GetDoubleLn(string messageForInput, string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						ShowLn(errorMessageEmpty);
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						ShowLn(errorMessageLiterals);
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с переносом курсора при завершении. </summary>
		/// <remarks> сообщения об ошибках отключены. </remarks>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDoubleLn(string messageForInput)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						Ln();
						Show($"{messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						Ln();
						Show($"{messageForInput}{str}");
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с переносом курсора при завершении. </summary>
		/// <remarks> сообщение о вводе не выводится.</remarks>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDoubleLn(string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						ShowLn(errorMessageEmpty);
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						ShowLn(errorMessageLiterals);
						Show(str);
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой и с переносом курсора при завершении. </summary>
		/// <remarks> сообщения о вводе и ошибках не выводятся.</remarks>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDoubleLn()
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Ln();
					}
					else
					{
						Ln();
						Show(str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						Ln();
						Show(str);
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой. </summary>
		/// <remarks> без переноса курсора или очистки консоли. </remarks>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> число с плавающей точкой .</returns>
		public static double GetDouble(string messageForInput, string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else
					{
						Show(errorMessageEmpty);
						Show($" {messageForInput}{str}");
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						Show(errorMessageLiterals);
						Show($" {messageForInput}{str}");
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой. </summary>
		/// <remarks> без переноса курсора или очистки консоли.<br/>сообщения об ошибках отключены. </remarks>
		/// <param name="messageForInput"> сообщение для ввода числа.<br/><br/>пример: <c>"введите число: "</c>. </param>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDouble(string messageForInput)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			Show(messageForInput);
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else Show($" {messageForInput}{str}");
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else Show($" {messageForInput}{str}");
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой. </summary>
		/// <remarks> без переноса курсора или очистки консоли.<br/>сообщение о вводе не выводится.</remarks>
		/// <param name="errorMessageEmpty"> сообщение об ошибке при отправке пустой строки.<br/><br/>пример: <c>"нельзя вводить ничего."</c>. </param>
		/// <param name="errorMessageLiterals"> сообщение об ошибке при введении букв.<br/><br/>пример: <c>"нельзя вводить буквы."</c>. </param>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDouble(string errorMessageEmpty, string errorMessageLiterals)
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else
					{
						Show(errorMessageEmpty);
						Show(" " + str);
					}
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else
					{
						Show(errorMessageLiterals);
						Show(" " + str);
					}
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> ввод числа с плавающей точкой. </summary>
		/// <remarks> без переноса курсора или очистки консоли.<br/>сообщения о вводе и ошибках не выводятся. </remarks>
		/// <returns> число с плавающей точкой. </returns>
		public static double GetDouble()
		{
			ConsoleKeyInfo odin;
			bool cycle = true;
			bool isHavePoint = false;
			StringBuilder str = new StringBuilder();
			do
			{
				odin = Console.ReadKey(true);
				if (odin.Key == ConsoleKey.Backspace && str.Length > 0)
				{
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					Show(" ");
					if (str[str.Length - 1] == ',') isHavePoint = false;
					str.Remove(str.Length - 1, 1);
					Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
				}
				else if (odin.Key == ConsoleKey.Backspace && str.Length == 0) { }
				else if (odin.Key == ConsoleKey.Enter)
				{
					if (str.Length != 0)
					{
						cycle = false;
						Show(" ");
					}
					else Show(" " + str);
				}
				else
				{
					if (Char.IsNumber(odin.KeyChar) || odin.KeyChar == '.' || odin.KeyChar == ',')
					{
						char shower = odin.KeyChar;
						if (shower == '.' || shower == ',')
						{
							if (!isHavePoint)
							{
								if (shower == '.') shower = ',';
								isHavePoint = true;
								Show(shower);
								str.Append(shower);
							}
						}
						else
						{
							Show(shower);
							str.Append(shower);
						}
					}
					else Show(" " + str);
				}
			} while (cycle);
			if (str.Length == 1 && str[0] == ',') return 0;
			return Convert.ToDouble(str.ToString());
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> стирает консоль при начале выполнения метода, и после завершения. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <param name="messageForInput">сообщение для ввода.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <param name="errorMessage"> сообщение об ошибке, если нажатая клавиша не совпала со списком разрешённых клавиш.<br/><br/>пример, при списке разрешённых клавиш <c>"1234567890"</c>>: <c>"можно ввести только числа."</c>. </param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetCharClr(string permittedKeys, string messageForInput, string errorMessage)
		{
			bool isNoMatch = false;
			char возврат_клавишы;
			ShowClr(messageForInput);
			do
			{
				if (isNoMatch) ShowClr(errorMessage);
				isNoMatch = true;
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Clr();
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> очищает консоль перед выводом сообщения и после завершения метода.<br/>сообщение об ошибке отключено. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <param name="messageForInput">сообщение для ввода.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetCharClr(string permittedKeys, string messageForInput)
		{
			bool isNoMatch = true;
			char возврат_клавишы;
			ShowClr(messageForInput);
			do
			{
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Clr();
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> очищает консоль при начале метода, и после завершения.<br/>сообщения об ошибке и вводе отключены. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetCharClr(string permittedKeys)
		{
			bool isNoMatch = true;
			char возврат_клавишы;
			Clr();
			do
			{
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Clr();
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли. клавиша может быть одним знаком. </summary>
		/// <remarks> при нажатии клавишы, знак не выводится.<br/>очищает консоль при начале метода, и после завершения. </remarks>
		/// <returns> нажатая клавиша. </returns>
		public static char GetCharClr()
		{
			char клавиша = GetCharClr(всеКлавишы);
			return клавиша;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> переносит курсор после завершения метода. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <param name="messageForInput">сообщение для ввода.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <param name="errorMessage"> сообщение об ошибке, если нажатая клавиша не совпала со списком разрешённых клавиш.<br/><br/>пример, при списке разрешённых клавиш <c>"1234567890"</c>: <c>"можно ввести только числа."</c>. </param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetCharLn(string permittedKeys, string messageForInput, string errorMessage)
		{
			bool isNoMatch = false;
			char возврат_клавишы;
			ShowLn(messageForInput);
			do
			{
				if (isNoMatch) ShowLn(errorMessage);
				isNoMatch = true;
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Ln();
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> переносит курсор после завершения метода.<br/>сообщение об ошибке отключено. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <param name="messageForInput">сообщение для ввода.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetCharLn(string permittedKeys, string messageForInput)
		{
			bool isNoMatch = true;
			char возврат_клавишы;
			ShowLn(messageForInput);
			do
			{
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Ln();
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> переносит курсор после завершения метода.<br/>сообщения об ошибке и вводе отключены. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetCharLn(string permittedKeys)
		{
			bool isNoMatch = true;
			char возврат_клавишы;
			do
			{
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Ln();
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли. клавиша может быть одним знаком. </summary>
		/// <remarks> при нажатии клавишы, знак не выводится.<br/>переносит курсор после завершения метода. </remarks>
		/// <returns> нажатая клавиша. </returns>
		public static char GetCharLn()
		{
			char клавиша = GetChar(всеКлавишы);
			Ln();
			return клавиша;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> не переносит курсор на новую строку при завершении. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <param name="messageForInput">сообщение для ввода.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <param name="errorMessage"> сообщение об ошибке, если нажатая клавиша не совпала со списком разрешённых клавиш.<br/><br/>пример, при списке разрешённых клавиш <c>"1234567890"</c>>: <c>"можно ввести только числа."</c>. </param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetChar(string permittedKeys, string messageForInput, string errorMessage)
		{
			bool isNoMatch = false;
			char возврат_клавишы;
			Show(messageForInput);
			do
			{
				if (isNoMatch) Show(errorMessage);
				isNoMatch = true;
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Show(" ");
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> не переносит курсор на новую строку при завершении.<br/>сообщение об ошибке отключено. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <param name="messageForInput">сообщение для ввода.<br/><br/>пример: <c>"введите число: "</c>.</param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetChar(string permittedKeys, string messageForInput)
		{
			bool isNoMatch = true;
			char возврат_клавишы;
			Show(messageForInput);
			do
			{
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Show(" ");
			return возврат_клавишы;
		}
		/// <summary> получение нажатой клавиши в консоли, с учётом списка разрешённых клавиш. </summary>
		/// <remarks> не переносит курсор на новую строку при завершении.<br/>сообщения об ошибке и вводе отключены. </remarks>
		/// <param name="permittedKeys"> список разрешённых клавиш.<br/><br/>параметр типа <see cref="string"/> для сокращения кода.<br/>пример: <c>"1234567890"</c>, или <c>"abcde"</c>. </param>
		/// <returns> нажатая клавиша, совпадающая со списком разрешённых клавиш. </returns>
		public static char GetChar(string permittedKeys)
		{
			bool isNoMatch = true;
			char возврат_клавишы;
			do
			{
				возврат_клавишы = Console.ReadKey(true).KeyChar;
				for (int i = 0; i < permittedKeys.Length; i++) if (возврат_клавишы == permittedKeys[i]) { isNoMatch = false; break; }
			} while (isNoMatch);
			Show(" ");
			return возврат_клавишы;
		}
		/// <summary> получение знака из консоли. </summary>
		/// /// <remarks> при нажатии клавишы, знак не выводится.<br/>не переносит курсор после завершения метода. </remarks>
		/// <returns> знак введённый в консоль. </returns>
		public static char GetChar()
		{
			char клавиша = GetChar(всеКлавишы);
			return клавиша;
		}
		/// <summary> ввод строки с очисткой консоли после ввода. </summary>
		/// <param name="messageForInput"> сообщение для ввода строки.<br/><br/>пример: <c>"введите сообщение: "</c>. </param>
		/// <returns> введённая строка в консоли. </returns>
		public static string GetStringClr(string messageForInput)
		{
			Show(messageForInput);
			string vvod = Console.ReadLine();
			Clr();
			return vvod;
		}
		/// <summary> ввод строки с очисткой консоли после ввода. </summary>
		/// <returns> строка введённая в консоли. </returns>
		public static string GetStringClr()
		{
			string vvod = Console.ReadLine();
			Clr();
			return vvod;
		}
		/// <summary> ввод строки с переносом курсора после ввода. </summary>
		/// <param name="messageForInput"> сообщение для ввода строки.<br/><br/>пример: <c>"введите сообщение: "</c>. </param>
		/// <returns> строка введённая в консоли. </returns>
		public static string GetStringLn(string messageForInput)
		{
			Show(messageForInput);
			string vvod = Console.ReadLine();
			return vvod;
		}
		/// <summary> ввод строки с переносом курсора после ввода. </summary>
		/// <returns> строка введённая в консоли. </returns>
		public static string GetStringLn()
		{
			string vvod = Console.ReadLine();
			return vvod;
		}
		/// <summary> ввод строки. </summary>
		/// <remarks> без переноса курсора после завершения ввода. </remarks>
		/// <param name="messageForInput"> сообщение для ввода строки.<br/><br/>пример: <c>"введите сообщение: "</c>. </param>
		/// <returns> строка введённая в консоли. </returns>
		public static string GetString(string messageForInput)
		{
			Show(messageForInput);
			string vvod = "";
			ConsoleKeyInfo symb;
			do
			{
				symb = Console.ReadKey(true);
				vvod += symb.KeyChar;
			} while (symb.Key != ConsoleKey.Enter);
			return vvod;
		}
		/// <summary> ввод строки. </summary>
		/// <remarks> без переноса курсора после завершения ввода. </remarks>
		/// <returns> строка введённая в консоли. </returns>
		public static string GetString()
		{
			string vvod = "";
			ConsoleKeyInfo symb;
			do
			{
				symb = Console.ReadKey(true);
				vvod += symb.KeyChar;
			} while (symb.Key != ConsoleKey.Enter);
			return vvod;
		}
		/// <summary> ожидает любое нажатие клавишы. </summary>
		/// <remarks> при окончании программы консоль автоматически закрывается,<br/>чтобы это остановить, ожидается ввод чего-либо. </remarks>
		/// <param name="messageForEnd"> вывод сообщения о завершении программы.<br/><br/>пример: <c>"для завершения нажмите любую клавишу . . . "</c> </param>
		public static void Endl(string messageForEnd)
		{
			Show(messageForEnd);
			Console.ReadKey(true);
		}
		/// <summary> ожидает любое нажатие клавишы. </summary>
		/// <remarks> при окончании программы консоль автоматически закрывается,<br/>чтобы это остановить, ожидается ввод чего-либо.<br/>не выводит никаких сообщений и ждёт нажатие клавиш. </remarks>
		public static void Endl() => Console.ReadKey(true);
		#endregion
		#region O
		/// <summary> очищает консоль и выводит сообщение, после чего переносит курсор. </summary>
		/// <param name="message"> сообщение для вывода.<br/><br/>параметр принимает любой тип,<br/>сделано для того чтобы не расписывать<br/>каждую перегрузку одного и того же метода. </param>
		public static void ShowClrLn(object message)
		{
			Clr();
			ShowLn(message);
		}
		/// <summary> очищает консоль и переносит курсор. </summary>
		public static void ShowClrLn()
		{
			Clr();
			Ln();
		}
		/// <summary> очищает консоль и выводит сообщение, курсор не перемещается. </summary>
		/// <param name="message"> сообщение для вывода.<br/><br/>параметр принимает любой тип,<br/>сделано для того чтобы я не расписывал<br/>каждую перегрузку одного и того же метода. </param>
		public static void ShowClr(object message)
		{
			Clr();
			Show(message);
		}
		/// <summary> очищает консоль. </summary>
		/// <remarks> альтернатива для <see cref="Clr()"/> </remarks>
		public static void ShowClr() => Clr();
		/// <summary> выводит сообщение и переносит курсор. </summary>
		/// <param name="message"> сообщение для вывода.<br/><br/>параметр принимает любой тип,<br/>сделано для того чтобы не расписывать<br/>каждую перегрузку одного и того же метода. </param>
		public static void ShowLn(object message) => Console.WriteLine(message);
		/// <summary> единичный перенос курсора. </summary>
		/// <remarks> альтернатива для <see cref="Ln()"/>. </remarks>
		public static void ShowLn() => Ln();
		/// <summary> выводит сообщение без переноса курсора. </summary>
		/// <param name="message"> сообщение для вывода.<br/><br/>параметр принимает любой тип,<br/>сделано для того чтобы не расписывать<br/>каждую перегрузку одного и того же метода. </param>
		public static void Show(object message) => Console.Write(message);
		/// <summary> множественный перенос курсора. </summary>
		/// <param name="lines"> количество строк для переноса курсора. </param>
		public static void Ln(int lines)
		{
			for (int i = 0; i < lines; i++) Ln();
		}
		/// <summary> единичный перенос курсора. </summary>
		public static void Ln() => Console.WriteLine();
		/// <summary> очистка консоли. </summary>
		public static void Clr() => Console.Clear();
		#endregion
	}
}