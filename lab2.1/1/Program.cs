using System;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_1
{
    class Program
    {
        static void OutputNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"-> Число: {i}");
                Thread.Sleep(200);
            }
        }

        static void OutputChars()
        {
            for (char ch = 'A'; ch <= 'J'; ch++)
            {
                Console.WriteLine($"-> Буква: {ch}");
                Thread.Sleep(200);
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Створення задач через TPL
            Task t1 = new Task(OutputNumbers);
            Task t2 = new Task(OutputChars);

            t1.Start();
            t2.Start();

            // Синхронізація: чекаємо завершення обох
            Task.WaitAll(t1, t2);
            Console.WriteLine("\nУсі паралельні задачі виконано.");
            Console.ReadLine();
        }
    }
}