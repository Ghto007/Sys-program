using System;
using System.Threading.Tasks;

namespace lab2_3
{
    class Program
    {
        static int ComputeSum(int limit)
        {
            int total = 0;
            for (int i = 1; i <= limit; i++)
            {
                total += i;
            }
            return total;
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть межу для обчислення суми (N): ");
            int num = int.Parse(Console.ReadLine());

            // 1. Головна задача (повертає int)
            Task<int> mainTask = new Task<int>(() => ComputeSum(num));

            // 2. Задача-продовження (запускається автоматично після першої)
            Task followUpTask = mainTask.ContinueWith((previousTask) =>
            {
                Console.WriteLine($"[Продовження] Сума чисел від 1 до {num} дорівнює: {previousTask.Result}");
            });

            // Запускаємо тільки першу задачу!
            mainTask.Start();

            // Програма чекає лише на завершення фінальної задачі-продовження
            followUpTask.Wait();

            Console.ReadLine();
        }
    }
}