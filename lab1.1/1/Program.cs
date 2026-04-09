using System;
using System.Threading;

namespace lab1_1
{
    public static class ThreadJobs
    {
        // Метод для виведення чисел
        public static void ShowNumbers()
        {
            for (int num = 1; num <= 40; num++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] - Значення: {num}");

                // Призупиняємо потік на 250 мілісекунд, щоб передати процесорний час іншому потоку
                Thread.Sleep(250);
            }
            Console.WriteLine($"\n---> {Thread.CurrentThread.Name} завершив роботу.");
        }

        // Метод для виведення літер англійської абетки
        public static void ShowLetters()
        {
            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                Console.WriteLine($"[{Thread.CurrentThread.Name}] - Символ: {letter}");
                Thread.Sleep(350);
            }
            Console.WriteLine($"\n---> {Thread.CurrentThread.Name} завершив роботу.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Головний потік ініційовано...\n");

            // Ініціалізація потоків із вказанням методів, які вони будуть виконувати
            Thread numThread = new Thread(ThreadJobs.ShowNumbers) { Name = "Потік Цифр" };
            Thread charThread = new Thread(ThreadJobs.ShowLetters) { Name = "Потік Літер" };

            // Запуск потоків
            numThread.Start();
            charThread.Start();

            // Блокуємо головний потік, поки дочірні не завершать свою роботу
            numThread.Join();
            charThread.Join();

            Console.WriteLine("\nВсі дочірні потоки виконані. Головний потік завершується.");
            Console.ReadKey();
        }
    }
}