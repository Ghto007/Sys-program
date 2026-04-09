using System;
using System.Threading;

namespace lab1_2
{
    public static class TaskManager
    {
        // Логіка для звичайних (Foreground) потоків
        public static void ForegroundAction()
        {
            for (int k = 1; k <= 5; k++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} працює (ітерація {k})");
                Thread.Sleep(600);
            }
            Console.WriteLine($"=== {Thread.CurrentThread.Name} ЗУПИНЕНО ===");
        }

        // Логіка для фонового (Background) потоку
        public static void BackgroundAction()
        {
            int tick = 1;

            // Нескінченний цикл
            while (true)
            {
                Console.WriteLine($"   [ФОН] Фоновий процес активний... (тік {tick++})");
                Thread.Sleep(400);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Старт програми...\n");

            // Створення звичайних потоків, які утримують програму від закриття
            Thread fgThread1 = new Thread(TaskManager.ForegroundAction) { Name = "Основний потік А" };
            Thread fgThread2 = new Thread(TaskManager.ForegroundAction) { Name = "Основний потік Б" };

            // Створення фонового потоку (IsBackground = true)
            Thread bgThread = new Thread(TaskManager.BackgroundAction)
            {
                Name = "Прихований потік",
                IsBackground = true
            };

            bgThread.Start();
            fgThread1.Start();
            fgThread2.Start();

            // Очікуємо завершення лише основних потоків
            fgThread1.Join();
            fgThread2.Join();

            // Після проходження цього рядка, програма закриється і ОС "вб'є" фоновий потік
            Console.WriteLine("\nОсновні задачі виконано. Програма закривається.");
        }
    }
}