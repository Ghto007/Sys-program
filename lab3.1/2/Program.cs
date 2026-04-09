using System;
using System.Threading.Tasks;

namespace lab3_2
{
    class Program
    {
        const double MagicNumber = 888.8;
        const double Tolerance = 0.2; // Відхилення (окіл)

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Ініціалізація паралельного пошуку...\n");

            double[] array = new double[15_000_000];
            for (int i = 0; i < array.Length; i++) array[i] = i * 0.05;

            // Штучно ховаємо шукане число десь у масиві
            array[9_123_456] = 888.9;

            // Виклик Parallel.For з об'єктом ParallelLoopState
            var loopResult = Parallel.For(0, array.Length, (index, loopState) =>
            {
                // Перевірка входження елемента в окіл
                if (Math.Abs(array[index] - MagicNumber) <= Tolerance)
                {
                    Console.WriteLine($"[ЗНАЙДЕНО] Значення {array[index]} на індексі {index}. Зупиняємо цикл!");
                    loopState.Break(); // Команда перервати виконання
                }
            });

            if (!loopResult.IsCompleted)
            {
                Console.WriteLine($"\nПошук перервано системою на ітерації {loopResult.LowestBreakIteration}.");
            }
            else
            {
                Console.WriteLine("\nЦикл завершився повністю. Елемент не знайдено.");
            }

            Console.ReadLine();
        }
    }
}