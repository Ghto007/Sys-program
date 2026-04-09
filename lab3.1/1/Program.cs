using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab3_1
{
    class Program
    {
        const int BaseSize = 12_000_000;
        const int MaxSize = 45_000_000;

        static void Main()
        {
            // Вмикаємо підтримку української мови
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- ТЕСТУВАННЯ: ПОСЛІДОВНО vs ПАРАЛЕЛЬНО ---\n");

            TestIntArray(BaseSize);
            TestIntArray(MaxSize);
            TestDoubleArray(BaseSize);
            TestDoubleArray(MaxSize);

            Console.WriteLine("\nУсі тести завершено. Натисніть будь-яку клавішу.");
            Console.ReadKey();
        }

        static void TestDoubleArray(int size)
        {
            double[] arr = new double[size];
            for (int i = 0; i < size; i++) arr[i] = (i % 5) + 2; // Заповнення

            // 1. Просте множення
            RunMeasurement("double", size, "y = y * 0.5",
                () => { for (int i = 0; i < size; i++) arr[i] = arr[i] * 0.5; },
                () => { Parallel.For(0, size, i => arr[i] = arr[i] * 0.5); });

            // 2. Складніша операція (Тригонометрія)
            RunMeasurement("double", size, "y = Sin(y) * Cos(y)",
                () => { for (int i = 0; i < size; i++) arr[i] = Math.Sin(arr[i]) * Math.Cos(arr[i]); },
                () => { Parallel.For(0, size, i => arr[i] = Math.Sin(arr[i]) * Math.Cos(arr[i])); });

            // 3. Дуже складна операція (Логарифми та Степені)
            RunMeasurement("double", size, "y = Log(y) / Pow(y, 2)",
                () => { for (int i = 0; i < size; i++) arr[i] = Math.Log(arr[i]) / Math.Pow(arr[i], 2); },
                () => { Parallel.For(0, size, i => arr[i] = Math.Log(arr[i]) / Math.Pow(arr[i], 2)); });
        }

        static void TestIntArray(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++) arr[i] = (i % 5) + 2;

            RunMeasurement("int", size, "y = y / 2",
                () => { for (int i = 0; i < size; i++) arr[i] = arr[i] / 2; },
                () => { Parallel.For(0, size, i => arr[i] = arr[i] / 2); });
        }

        static void RunMeasurement(string type, int size, string op, Action seq, Action par)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            seq();
            timer.Stop();
            long seqTime = timer.ElapsedMilliseconds;

            timer.Reset();

            timer.Start();
            par();
            timer.Stop();
            long parTime = timer.ElapsedMilliseconds;

            string win = parTime < seqTime ? "Паралельно" : "Послідовно";

            // ПРОСТИЙ ВИВІД БЕЗ ВИРІВНЮВАННЯ КОЛОНОК
            Console.WriteLine($"Тип: {type} | Розмір: {size} | Операція: {op} | Послідовно: {seqTime} мс | Паралельно: {parTime} мс | Переможець: {win}");
        }
    }
}