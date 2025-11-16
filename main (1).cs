using System;
using System.Collections.Generic;

class PulseLogger
{
    class LogEntry
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }
    }

    static List<LogEntry> logs = new List<LogEntry>();

    static void Main(string[] args)
    {
        Console.WriteLine("=== PULSELOGGER ===");
        Console.WriteLine("Track your daily pulses (actions)\n");

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Log");
            Console.WriteLine("2. View Logs");
            Console.WriteLine("3. Search Logs");
            Console.WriteLine("4. Clear All Logs");
            Console.WriteLine("5. Exit");

            Console.Write("\nEnter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddLog();
                    break;

                case "2":
                    ViewLogs();
                    break;

                case "3":
                    SearchLogs();
                    break;

                case "4":
                    ClearLogs();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Exiting PulseLogger...");
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }
        }
    }

    static void AddLog()
    {
        Console.Write("\nEnter activity: ");
        string message = Console.ReadLine();

        logs.Add(new LogEntry
        {
            Message = message,
            Time = DateTime.Now
        });

        Console.WriteLine("Log saved!");
    }

    static void ViewLogs()
    {
        Console.WriteLine("\n=== Activity Logs ===");

        if (logs.Count == 0)
        {
            Console.WriteLine("No logs yet.");
            return;
        }

        for (int i = 0; i < logs.Count; i++)
        {
            Console.WriteLine($"{i + 1}. [{logs[i].Time}] - {logs[i].Message}");
        }
    }

    static void SearchLogs()
    {
        Console.Write("\nEnter keyword to search: ");
        string keyword = Console.ReadLine();

        Console.WriteLine($"\nResults for '{keyword}':");

        bool found = false;

        for (int i = 0; i < logs.Count; i++)
        {
            if (logs[i].Message.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"{i + 1}. [{logs[i].Time}] - {logs[i].Message}");
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No matching logs found.");
    }

    static void ClearLogs()
    {
        logs.Clear();
        Console.WriteLine("All logs cleared!");
    }
}