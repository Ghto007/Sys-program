using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab3_3
{
    class ElementData
    {
        public int ElementId { get; set; }
        public double NumericValue { get; set; }
    }

    class Program
    {
        // Іменований метод, що виконується для кожного елемента
        static void UpdateElement(ElementData item)
        {
            item.NumericValue = item.NumericValue / Math.PI;
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Генерація списку об'єктів (8 000 000 шт.)...");

            var dataList = new List<ElementData>();
            for (int i = 0; i < 8_000_000; i++)
            {
                dataList.Add(new ElementData { ElementId = i, NumericValue = i });
            }

            Console.WriteLine("Початок обробки через Parallel.ForEach (з іменованим методом)...\n");

            Stopwatch timer = Stopwatch.StartNew();

            // Передаємо колекцію та посилання на метод обробки
            Parallel.ForEach(dataList, UpdateElement);

            timer.Stop();

            Console.WriteLine($"Обробку завершено за {timer.ElapsedMilliseconds} мс.");
            Console.WriteLine($"Перший елемент тепер дорівнює: {dataList[0].NumericValue}");
            Console.WriteLine($"Останній елемент тепер дорівнює: {dataList[dataList.Count - 1].NumericValue}");

            Console.ReadLine();
        }
    }
}