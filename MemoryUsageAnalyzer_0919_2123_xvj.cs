// 代码生成时间: 2025-09-19 21:23:07
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MemoryUsageAnalysis
{
    /// <summary>
    /// Provides functionality to analyze the memory usage of the current process.
    /// </summary>
    public class MemoryUsageAnalyzer
    {
        /// <summary>
        /// Retrieves the current memory usage of the process.
        /// </summary>
        /// <returns>The current memory usage in bytes.</returns>
        public long GetCurrentMemoryUsage()
        {
            Process currentProcess = Process.GetCurrentProcess();
            return currentProcess.WorkingSet64;
        }

        /// <summary>
        /// Retrieves the peak memory usage of the process.
        /// </summary>
        /// <returns>The peak memory usage in bytes.</returns>
        public long GetPeakMemoryUsage()
        {
            Process currentProcess = Process.GetCurrentProcess();
            return currentProcess.PeakWorkingSet64;
        }

        /// <summary>
        /// Retrieves the current memory usage of the process and prints it to the console.
        /// </summary>
        public void DisplayCurrentMemoryUsage()
        {
            try
            {
                long memoryUsage = GetCurrentMemoryUsage();
                Console.WriteLine($"Current Memory Usage: {memoryUsage} bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves the peak memory usage of the process and prints it to the console.
        /// </summary>
        public void DisplayPeakMemoryUsage()
        {
            try
            {
                long peakMemoryUsage = GetPeakMemoryUsage();
                Console.WriteLine($"Peak Memory Usage: {peakMemoryUsage} bytes");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MemoryUsageAnalyzer analyzer = new MemoryUsageAnalyzer();
            analyzer.DisplayCurrentMemoryUsage();
            analyzer.DisplayPeakMemoryUsage();
        }
    }
}