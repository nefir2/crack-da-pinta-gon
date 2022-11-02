//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace crack_da_pinta_gon
//{
//	class TestClass
//	{
//		private static void Main()
//		{
//			Console.CursorVisible = false; ConsoleColor[] colors = new ConsoleColor[16];
//			for (int i = 0; i < 16; i++) { colors[i] = (ConsoleColor)i; }
//			for (int i = 0; true; i++)
//			{
//				ColorFormat.Write($"те%{{1}}кст для пр%0имера &2испол%0ьзования статич&1еских ме&0то%1дов%0&3. %{{16}}&{{17}}output #{i}\n", RandomSwap(colors)); //ColorFormat.DefaultFore, ColorFormat.DefaultBack, 
//				//Thread.Sleep(1);
//			}


//			Console.ReadKey(true);
//		}
//		private static T[] RandomSwap<T>(T[] array)
//		{
//			for (int i = 0; i < array.Length; i++) Swap(array, i, new Random().Next(array.Length));
//			return array;
//		}
//		private static T[] RandomSwap<T>(T[] array, params T[] unchangableObjects)
//		{
//			T[] retArray = new T[array.Length + unchangableObjects.Length];
//			for (int i = 0; i < array.Length; i++) Swap(array, i, new Random().Next(array.Length));
//			return array;
//		}
//		private static T[] AllInOne<T>(params T[][] arrays)
//		{
//			int allLengths = 0;
//			for (int i = 0; i < arrays.Length; i++)
//			{
//				allLengths += arrays[i].Length;
//			}
//			//T[] array = new T[];
//		}
//		/// <summary> меняет местами элементы в указанных позициях указанного массива.  </summary>
//		/// <typeparam name="T">тип массива.</typeparam>
//		/// <param name="array">массив типа <typeparamref name="T"/></param>
//		/// <param name="firstPosition">первый элемент в массиве.</param>
//		/// <param name="secondPosition">второй элемент в массиве.</param>
//		/// <returns>массив с обменёнными элементами в указанных позициях.</returns>
//		/// <exception cref="IndexOutOfRangeException"/>
//		private static T[] Swap<T>(T[] array, int firstPosition, int secondPosition)
//		{
//			if (firstPosition > array.Length || secondPosition > array.Length || firstPosition < 0 || secondPosition < 0) throw new IndexOutOfRangeException("указанные позиции элементов массива вне границ самого массива.");

//			T temp = array[firstPosition];
//			array[firstPosition] = array[secondPosition];
//			array[secondPosition] = temp;
//			return array;
//		}
//	}
//}