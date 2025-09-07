// 代码生成时间: 2025-09-08 03:29:12
 * maintainability, and expandability.
 */

using System;
using System.Diagnostics;
using System.IO;

namespace SystemPerformanceMonitor
{
    public class SystemPerformanceMonitor
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter memoryCounter;
        private PerformanceCounter diskCounter;

        // Constructor to initialize performance counters
        public SystemPerformanceMonitor()
        {
            // Initialize CPU counter
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            
            // Initialize Memory counter
            memoryCounter = new PerformanceCounter("Memory", "Available MBytes");
            
            // Initialize Disk counter (C: drive usage)
            diskCounter = new PerformanceCounter("LogicalDisk", "% Free Space", "C:");
        }

        // Method to retrieve and display system performance statistics
        public void DisplayPerformanceStatistics()
        {
            try
            {
                double cpuUsage = cpuCounter.NextValue(); // Get CPU usage
                double memoryAvailable = memoryCounter.NextValue() / 1024.0; // Convert to GB
                double diskSpaceFree = diskCounter.NextValue(); // Get disk free space percentage

                Console.WriteLine("System Performance Statistics: 
");
                Console.WriteLine($"CPU Usage: {cpuUsage}%
");
                Console.WriteLine($"Memory Available: {memoryAvailable} GB
");
                Console.WriteLine($"Disk Space Free (C: drive): {diskSpaceFree}%
");
            }
            catch (Exception ex)
            {
                // Handle exceptions and display error message
                Console.WriteLine($"An error occurred while retrieving performance data: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the SystemPerformanceMonitor
            SystemPerformanceMonitor monitor = new SystemPerformanceMonitor();

            // Continuously display system performance statistics
            Console.WriteLine("Press 'q' to quit...");
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "q")
                {
                    break;
                }
                monitor.DisplayPerformanceStatistics();
            }
        }
    }
}