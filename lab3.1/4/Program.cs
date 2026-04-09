using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab3_4
{
    class ElementData
    {
        public int ElementId { get; set; }
        public double NumericValue { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Генерація списку об'єктів (8 000 000 шт.)...");

            var dataList = new List<ElementData>();
            for (int i = 0; i < 8_000_000; i++)
            {
                dataList.Add(new ElementData { ElementId = i, NumericValue = i });
            }

            Console.WriteLine("Початок обробки через Parallel.ForEach (з лямбда-виразом)...\n");

            Stopwatch timer = Stopwatch.StartNew();

            // Використання лямбда-виразу (анонімної функції) замість окремого методу
            Parallel.ForEach(dataList, item =>
            {
                item.NumericValue = item.NumericValue / Math.PI;
            });

            timer.Stop();

            Console.WriteLine($"Обробку завершено за {timer.ElapsedMilliseconds} мс.");
            Console.WriteLine($"Перший елемент тепер дорівнює: {dataList[0].NumericValue}");
            Console.WriteLine($"Останній елемент тепер дорівнює: {dataList[dataList.Count - 1].NumericValue}");

            Console.ReadLine();
        }
    }
}