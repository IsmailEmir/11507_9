using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VariantThree;

class Program
{
    static void Main(string[] args)
    {
        string logPath = "app.log";
        string reportPath = "error_report.txt";

        try
        {
            if (!File.Exists(logPath))
            {
                File.WriteAllText(reportPath, "Лог-файл не найден.");
                Console.WriteLine("Лог-файл не найден.");
                return;
            }
            string[] lines = File.ReadAllLines(logPath);
            if (lines.Length == 0)
            {
                File.WriteAllText(reportPath, "Лог-файл пуст.");
                Console.WriteLine("Лог-файл пуст.");
                return;
            }
            var errorLines = lines
                .Where(line => line.Contains(" ERROR "))
                .ToList();
            int errorCount = errorLines.Count;
            var lastUniqueErrors = errorLines
                .Select(line => line.Substring(line.IndexOf("ERROR") + 6))
                .Distinct()
                .Reverse()
                .Take(5)
                .ToList();
            List<string> reportContent = new List<string>();
            reportContent.Add($"Общее количество ошибок: {errorCount}");
            reportContent.Add("");
            reportContent.Add("Последние 5 уникальных сообщений об ошибках:");
            foreach (var error in lastUniqueErrors)
            {
                reportContent.Add($"- {error}");
            }
            File.WriteAllLines(reportPath, reportContent);
            foreach (var line in reportContent) Console.WriteLine(line);
        }
        catch (Exception ex)
        {
            File.WriteAllText(reportPath, $"Ошибка при обработке файла: {ex.Message}");
            Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
        }
    }
}