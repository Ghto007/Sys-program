using System;
using System.Threading;
using System.Threading.Tasks;

namespace lab2_4
{
    class Program
    {
        static void CalcFact(int num)
        {
            long res = 1;
            for (int i = 1; i <= num; i++) res *= i;
            Console.WriteLine($"> Факторіал числа {num} дорівнює {res}");
        }

        static void CalcSum(int num)
        {
            int res = 0;
            for (int i = 1; i <= num; i++) res += i;
            Console.WriteLine($"> Сума від 1 до {num} дорівнює {res}");
        }

        static void ShowAlerts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("   [Сповіщення] з методу 3...");
                Thread.Sleep(250);
            }
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введіть число для факторіалу: ");
            int n1 = int.Parse(Console.ReadLine());

            Console.Write("Введіть число для суми: ");
            int n2 = int.Parse(Console.ReadLine());

            Console.Write("Введіть кількість сповіщень: ");
            int n3 = int.Parse(Console.ReadLine());

            Console.WriteLine("\n--- Запуск через Parallel.Invoke ---");

            // Виконуємо всі 3 методи паралельно, використовуючи лямбда-вирази для передачі аргументів
            Parallel.Invoke(
                () => CalcFact(n1),
                () => CalcSum(n2),
                () => ShowAlerts(n3)
            );

            Console.WriteLine("\nВсі операції успішно завершено.");
            Console.ReadLine();
        }
    }
}