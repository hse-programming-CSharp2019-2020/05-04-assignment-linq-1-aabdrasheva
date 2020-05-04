using System;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            string[] str = Console.ReadLine().Split(' ');
            string[] str1 = str.Where(n => !string.IsNullOrEmpty(n)).ToArray();
            int[] arr = new int[str1.Length];
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = str1.Select<string, int>(s => checked(int.Parse(s))).ToArray<int>();
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
            
            var filteredCollection = arr.TakeWhile(n => string.Compare("0", n.ToString(), true) != 0);
            
            try
            {
                var filteredCollection2 = filteredCollection.Select(n => checked(n*n));
                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = filteredCollection2.Average();
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = filteredCollection2.Average();
                Console.WriteLine(checked(averageUsingInstanceForm.ToString("f3").Replace('.', ',')));
                Console.WriteLine(checked(averageUsingStaticForm.ToString("f3").Replace('.', ',')));
                // вывести элементы коллекции в одну строку
                Console.WriteLine(String.Join(" " ,filteredCollection));
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
}
