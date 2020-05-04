using System;
using System.Collections.Generic;
using System.Linq;

/*Все действия по обработке данных выполнять с использованием LINQ
 * 
 * Объявите перечисление Manufacturer, состоящее из элементов
 * Dell (код производителя - 0), Asus (1), Apple (2), Microsoft (3).
 * 
 * Обратите внимание на класс ComputerInfo, он содержит поле типа Manufacturer
 * 
 * На вход подается число N.
 * На следующих N строках через пробел записана информация о компьютере: 
 * фамилия владельца, код производителя (от 0 до 3) и год выпуска (в диапазоне 1970-2020).
 * Затем с помощью средств LINQ двумя разными способами (как запрос или через методы)
 * отсортируйте коллекцию следующим образом:
 * 1. Первоочередно объекты ComputerInfo сортируются по фамилии владельца в убывающем порядке
 * 2. Для объектов, у которых фамилии владельцев сопадают, 
 * сортировка идет по названию компании производителя (НЕ по коду) в возрастающем порядке.
 * 3. Если совпадают и фамилия, и имя производителя, то сортировать по году выпуска в порядке убывания.
 * 
 * Выведите элементы каждой коллекции на экран в формате:
 * <Фамилия_владельца>: <Имя_производителя> [<Год_производства>]
 * 
 * Пример ввода:
 * 3
 * Ivanov 1970 0
 * Ivanov 1971 0
 * Ivanov 1970 1
 * 
 * Пример вывода:
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * Ivanov: Asus [1970]
 * Ivanov: Dell [1971]
 * Ivanov: Dell [1970]
 * 
 * 
 *  * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * При некорректных входных данных (не связанных с созданием объекта) выбрасывайте FormatException
 * При невозможности создать объект класса ComputerInfo выбрасывайте ArgumentException!
 */
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            List<ComputerInfo> computerInfoList = new List<ComputerInfo>();
            try
            {
                string str = Console.ReadLine();
                if(!Int32.TryParse(str, out N)) 
                {  
                    throw new FormatException();
                } 
                int.TryParse(str, out N);
                if (N < 1) throw new FormatException();
                string[] names;
                int year;
                int manu;
                for (int i = 0; i < N; i++)
                {
                    names = Console.ReadLine().Split(' ');
                    if (names.Length != 3 || !Int32.TryParse(names[1], out year) || year < 1970 || 
                        year > 2020 || !Int32.TryParse(names[2], out manu) || manu < 0 || manu > 3)
                        throw new FormatException();
                    int.TryParse(names[1], out year);
                    int.TryParse(names[2], out manu);
                    computerInfoList.Add(new ComputerInfo(names[0], year, manu));
                } 
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch(ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }

            // выполните сортировку одним выражением
            var computerInfoQuery = from n in computerInfoList
                                    orderby n.Owner descending, String.Concat(n.ComputerManufacturer), n.Year descending
                                    select n;

            PrintCollectionInOneLine(computerInfoQuery);

            Console.WriteLine();

            // выполните сортировку одним выражением
            var computerInfoMethods = computerInfoList.OrderByDescending(n => n.Owner).ThenBy(n => String.Concat(n.ComputerManufacturer)).ThenByDescending(n => n.Year);

            PrintCollectionInOneLine(computerInfoMethods);
            
        }

        // выведите элементы коллекции на экран с помощью кода, состоящего из одной линии (должна быть одна точка с запятой)
        public static void PrintCollectionInOneLine(IEnumerable<ComputerInfo> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Owner}: {item.ComputerManufacturer} [{item.Year}]");
            }

        }
    }


    public class ComputerInfo
    {              
        public string Owner { get; set; }
        public int Year {get; set;}
        public Manufacturer ComputerManufacturer { get; set; }
        public enum Manufacturer
        {
            Dell, Asus, Apple, Microsoft
        }
        public ComputerInfo(string name, int year, int manu)
        {
            Owner = name;
            ComputerManufacturer = (Manufacturer)manu;
            Year = year;
        }
    }
}
