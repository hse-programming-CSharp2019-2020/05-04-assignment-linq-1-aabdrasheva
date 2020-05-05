using System;
using System.Collections.Generic;
using System.Linq;
/*
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * На основе полученных чисел получить новое по формуле: 5 + a[0] - a[1] + a[2] - a[3] + ...
 * Это необходимо сделать двумя способами:
 * 1) с помощью встроенного LINQ метода Aggregate
 * 2) с помощью своего метода MyAggregate, сигнатура которого дана в классе MyClass
 * Вывести полученные результаты на экран (естесственно, они должны быть одинаковыми)
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 8
 * 8
 * 
 * Пояснение:
 * 5 + 1 - 2 + 3 - 4 + 5 = 8
 * 
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 */

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk04();
        }

        public static void RunTesk04()
        {
            string[] str = Console.ReadLine().Split(' ');
            string[] str1 = str.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            int[] arr = new int[str1.Length];
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = str1.Select<string, int>(s => int.Parse(s)).ToArray<int>();
            
           
                // использовать синтаксис методов! SQL-подобные запросы не писать!
               int arrAggregate = 5 + arr.Aggregate((x,y) => Convert.ToInt32(x) + Convert.ToInt32(y * Math.Pow(-1, Array.FindIndex(arr, a => (a == y)))));
                
                int arrMyAggregate = MyClass.MyAggregate(arr);
            
                if (arrAggregate > Int32.MaxValue || arrAggregate < Int32.MinValue || arrMyAggregate > Int32.MaxValue || arrMyAggregate < Int32.MinValue)
                throw new OverflowException();
                else 
                {
                Console.WriteLine(arrAggregate);
                Console.WriteLine(arrMyAggregate);
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
           
        }
    }

    static class MyClass
    {
        public static int MyAggregate(int[] arr)
        {
            int n = 5;
            for (int i = 0; i < arr.Length; i++)
			{
                n += Convert.ToInt32(arr[i] * Math.Pow(-1, i));
			}
            return n;
        }
    }
}
