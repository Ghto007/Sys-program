using System;
using System.IO;

namespace Lab6_Task2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введіть назву файлу або шаблон (наприклад, report.txt або *.pdf): ");
            string fileName = Console.ReadLine();

            Console.WriteLine("\nПошук розпочато (це може зайняти певний час)...");

            // Отримуємо всі доступні диски (C:\, D:\ тощо)
            string[] drives = Directory.GetLogicalDrives();
            int totalFound = 0;

            foreach (string drive in drives)
            {
                Console.WriteLine($"\n[ Сканування диска {drive} ]");
                DirectoryInfo rootDir = new DirectoryInfo(drive);
                totalFound += SearchFile(rootDir, fileName);
            }

            Console.WriteLine($"\n✅ Пошук завершено. Знайдено файлів: {totalFound}");
            Console.ReadLine();
        }

        static int SearchFile(DirectoryInfo dir, string pattern)
        {
            int count = 0;
            try
            {
                // Пошук файлів у поточній директорії
                foreach (FileInfo file in dir.GetFiles(pattern))
                {
                    Console.WriteLine($"\n 📄 Знайдено: {file.Name}");
                    Console.WriteLine($"    Шлях:     {file.FullName}");
                    Console.WriteLine($"    Розмір:   {(file.Length / 1024.0):F2} KB");
                    Console.WriteLine($"    Створено: {file.CreationTime:dd.MM.yyyy HH:mm}");
                    count++;
                }

                // Рекурсивний обхід підкаталогів
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    count += SearchFile(subDir, pattern);
                }
            }
            catch (UnauthorizedAccessException) { /* Ігноруємо системні папки */ }
            catch (Exception) { /* Ігноруємо інші помилки доступу */ }

            return count;
        }
    }
}