using System;
using System.Collections.Generic;
using System.Threading;

namespace lab1_4
{
    public class DynamicThread
    {
        public int Id { get; }
        public long Counter { get; private set; }
        public Thread ActiveThread { get; }
        public bool IsDone { get; private set; }
        public bool IsWinner { get; private set; }
        public ThreadPriority Priority { get; }

        private readonly long limit;
        // Змінна, спільна для всіх потоків
        public static volatile bool GlobalStop = false;

        public DynamicThread(int id, ThreadPriority prio, long target)
        {
            Id = id;
            Priority = prio;
            limit = target;
            ActiveThread = new Thread(Work) { Priority = prio };
        }

        private void Work()
        {
            // Рахуємо, поки не досягли мети і ніхто інший не зупинив гонку
            while (Counter < limit && !GlobalStop)
            {
                Counter++;
            }

            // Якщо саме цей потік дійшов до ліміту першим
            if (Counter >= limit && !GlobalStop)
            {
                GlobalStop = true; // Зупиняємо інші потоки
                IsWinner = true;
            }
            IsDone = true;
        }
    }

    class Program
    {
        static void Main()
        {
            // Вмикаємо українську мову в консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- НАЛАШТУВАННЯ ПОТОКІВ ---");
            Console.Write("Введіть ціль для лічильника (напр. 100000000): ");
            long target = long.Parse(Console.ReadLine());

            Console.Write("Введіть кількість потоків: ");
            int count = int.Parse(Console.ReadLine());

            var threads = new List<DynamicThread>();
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"\nВиберіть пріоритет для Потоку {i}:");
                Console.WriteLine("1 - Lowest\n2 - BelowNormal\n3 - Normal\n4 - AboveNormal\n5 - Highest");
                Console.Write("Ваш вибір (1-5): ");
                int p = int.Parse(Console.ReadLine());
                ThreadPriority tp = (ThreadPriority)(p - 1);
                threads.Add(new DynamicThread(i, tp, target));
            }

            Console.Clear();
            Console.WriteLine("Початок виконання...\n");

            // ОСЬ ТУТ БУЛО ВИПРАВЛЕНО ПОМИЛКУ:
            DynamicThread.GlobalStop = false;

            int topRow = Console.CursorTop;

            foreach (var t in threads) t.ActiveThread.Start();

            bool finished = false;
            while (!finished)
            {
                finished = true;
                Console.SetCursorPosition(0, topRow);
                foreach (var t in threads)
                {
                    double progress = (double)t.Counter / target * 100;

                    // Красиве форматування статусів, щоб колонки були рівними
                    string state = t.IsWinner ? "[ПЕРЕМОЖЕЦЬ]" : (t.IsDone ? "[ЗУПИНЕНО]  " : "[ПРАЦЮЄ]    ");

                    Console.WriteLine($"Потік {t.Id} ({t.Priority,-11}) | Статус: {state} | Лічильник: {t.Counter,-12} | Прогрес: {progress,6:F2}%");

                    if (!t.IsDone) finished = false;
                }
                Thread.Sleep(50);
            }

            foreach (var t in threads) t.ActiveThread.Join();

            // Фінальна таблиця результатів
            Console.WriteLine("\n--- РЕЗУЛЬТАТИ ГОНКИ ТА РОЗПОДІЛ ЧАСУ ЦП ---");
            long totalCount = 0;
            foreach (var t in threads) totalCount += t.Counter;

            foreach (var t in threads)
            {
                double cpuShare = (double)t.Counter / totalCount * 100;
                string place = t.IsWinner ? "[1 МІСЦЕ]" : "[ЗУПИНЕНО]";
                Console.WriteLine($"{place,-10} Потік {t.Id} ({t.Priority,-11}) отримав ~{cpuShare:F2}% часу ЦП.");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу.");
            Console.ReadKey();
        }
    }
}