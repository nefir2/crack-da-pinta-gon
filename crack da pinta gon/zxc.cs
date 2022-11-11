using CIO;
using System.Threading;
namespace zxcqwe
{
	class zxc
	{
		public int thousand, ghoul, wait, digit; //глобальные переменные класса
		public zxc(int start, int minus, int waiter) //конструктор
		{//перенос переменных из создания объекта в класс
			thousand = start; //первое число, из которого вычитают
			digit = minus; //второе число, которым вычитают
			ghoul = thousand - digit; //определение, когда выжидать первое число
			wait = waiter; //первое выжидание
		}
		public int seven(int waiter)
		{//метод для пересчёта первого числа
			if (thousand == ghoul) waiter = wait; //если совпал момент когда выжидать, запуск первого ожидания, иначе запуск основного ожидания
			Thread.Sleep(waiter); //ожидание
			return thousand -= digit; //возврат числа - второе число и запоминание нового числа
		}
		public bool qwe()
		{//метод для выхода из цикла
			if (thousand - digit < 0) return false;
			else return true;
		}
		public static void zxcqwe(int start = 1000, int seven = 7, int first_wait = 1000, int main_wait = 40)
		{
			zxc zxc = new zxc(start, seven, first_wait);
			while (zxc.qwe()) ConsIO.ShowLn($"{zxc.thousand,4} - {zxc.digit,1} = {zxc.seven(main_wait),3}");
		}
		public static void inpt(out int start, out int count, out int onewait, out int secwait)
		{
			start = ConsIO.GetIntClr("введите точку отсчёта (для быстрого запуска программы введите 0): "); //1000
			if (start < 1) { start = 1000; count = 7; onewait = 1000; secwait = 25; ConsIO.Clr(); }
			else
			{
				do
				{
					count = ConsIO.GetIntClr("введите сколько вычитать: ");
					if (count < 1) ConsIO.ShowClrLn("zxc.псих делает бесконечный цикл, проверяй");
				} while (count < 1);
				onewait = ConsIO.GetIntClr("введите первое ожидание: "); //1000
				secwait = ConsIO.GetIntClr("введите основное ожидание: "); //40
			}
		}
	}
}