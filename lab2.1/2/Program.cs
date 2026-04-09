using System;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_2
{
    class Program
    {
        static void RunCounter()
        {
            for (int i = 1; i <= 5; i++)
            {
                // Виводимо системний номер задачі, яка зараз виконує цей рядок
                Console.WriteLine($"[Задача ID: {Task.CurrentId}] - виконує крок {i}");
                Thread.Sleep(150);
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Task job1 = new Task(RunCounter);
            Task job2 = new Task(RunCounter);
            Task job3 = new Task(RunCounter);

            job1.Start();
            job2.Start();
            job3.Start();

            Console.WriteLine($"Призначені ідентифікатори об'єктів: J1={job1.Id}, J2={job2.Id}, J3={job3.Id}\n");

            Task.WaitAll(job1, job2, job3);

            Console.WriteLine("\nРоботу завершено.");
            Console.ReadLine();
        }
    }
}