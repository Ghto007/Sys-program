using System;
using System.IO;

namespace Lab6_Task1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введіть шлях до директорії (наприклад, C:\\ або D:\\Test): ");
            string path = Console.ReadLine();

            DirectoryInfo rootDir = new DirectoryInfo(path);

            if (rootDir.Exists)
            {
                Console.WriteLine($"\nСтруктура каталогу: {rootDir.FullName}");
                PrintTree(rootDir, "");
            }
            else
            {
                Console.WriteLine("Помилка: Директорію не знайдено.");
            }

            Console.WriteLine("\nНатисніть Enter для виходу...");
            Console.ReadLine();
        }

        // Рекурсивний метод для виведення структури
        static void PrintTree(DirectoryInfo dir, string indent)
        {
            try
            {
                // Спочатку виводимо всі файли в поточній папці
                foreach (FileInfo file in dir.GetFiles())
                {
                    Console.WriteLine($"{indent}📄 {file.Name}");
                }

                // Потім виводимо підкаталоги і рекурсивно заходимо в них
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    Console.WriteLine($"{indent}📁 {subDir.Name}");
                    PrintTree(subDir, indent + "   "); // Збільшуємо відступ для ієрархії
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Обробка помилки доступу до системних папок
                Console.WriteLine($"{indent} [Відмовлено в доступі]");
            }
        }
    }
}