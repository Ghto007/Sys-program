using System;
using System.Collections.Generic;
using System.Threading;

namespace lab1_3
{
    public class JobWorker
    {
        public int Iterations { get; private set; }
        public Thread ProcessThread { get; private set; }
        private static bool raceFinished = false;

        public JobWorker(string id, ThreadPriority prio)
        {
            Iterations = 0;
            ProcessThread = new Thread(RunCounter) { Name = id, Priority = prio };
        }

        private void RunCounter()
        {
            // Рахуємо, поки хтось перший не дійде до 100 млн
            while (!raceFinished && Iterations < 100000000)
            {
                Iterations++;
            }
            raceFinished = true; // Зупиняємо всіх інших
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Запуск перегонів потоків...\n");

            // Створюємо 5 потоків (унікальний набір для друга)
            var workers = new List<JobWorker>
            {
                new JobWorker("Потік 1 (Highest)", ThreadPriority.Highest),
                new JobWorker("Потік 2 (Above)", ThreadPriority.AboveNormal),
                new JobWorker("Потік 3 (Normal)", ThreadPriority.Normal),
                new JobWorker("Потік 4 (Below)", ThreadPriority.BelowNormal),
                new JobWorker("Потік 5 (Lowest)", ThreadPriority.Lowest)
            };

            foreach (var w in workers) w.ProcessThread.Start();
            foreach (var w in workers) w.ProcessThread.Join();

            long total = 0;
            foreach (var w in workers) total += w.Iterations;

            Console.WriteLine("--- РЕЗУЛЬТАТИ ---");
            foreach (var w in workers)
            {
                double cpuShare = (double)w.Iterations / total * 100;
                Console.WriteLine($"{w.ProcessThread.Name,-20} | Ітерації: {w.Iterations,-10} | Час ЦП: {cpuShare:F2}%");
            }
            Console.ReadLine();
        }
    }
}