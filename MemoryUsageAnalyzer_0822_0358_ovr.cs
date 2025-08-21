// 代码生成时间: 2025-08-22 03:58:14
// <copyright file="MemoryUsageAnalyzer.cs" company="YourCompany">
//     Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace YourCompany.Diagnostics
{
    /// <summary>
    /// Provides functionality to analyze memory usage of the current process.
    /// </summary>
    public class MemoryUsageAnalyzer
    {
        /// <summary>
        /// Gets the current memory usage of the process in bytes.
        /// </summary>
        /// <returns>The memory usage in bytes.</returns>
        public static long GetCurrentMemoryUsage()
        {
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                return currentProcess.WorkingSet64; // Returns the amount of memory allocated for the process in bytes.
            }
            catch (Exception ex)
            {
                // Handle potential exceptions that may occur during the process information retrieval.
                Console.WriteLine($"Error retrieving memory usage: {ex.Message}");
                return -1; // Indicate an error occurred.
            }
        }

        /// <summary>
        /// Gets the peak memory usage of the process in bytes.
        /// </summary>
        /// <returns>The peak memory usage in bytes.</returns>
        public static long GetPeakMemoryUsage()
        {
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                return currentProcess.PeakWorkingSet64; // Returns the peak amount of memory allocated for the process in bytes.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving peak memory usage: {ex.Message}");
                return -1; // Indicate an error occurred.
            }
        }

        /// <summary>
        /// Gets the memory usage information of the current process.
        /// </summary>
        /// <returns>A string containing memory usage information.</returns>
        public static string GetMemoryUsageInfo()
        {
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                long currentUsage = currentProcess.WorkingSet64;
                long peakUsage = currentProcess.PeakWorkingSet64;
                long privateBytes = currentProcess.PrivateMemorySize64;
                
                return $"Current Memory Usage: {currentUsage} bytes
Peak Memory Usage: {peakUsage} bytes
Private Memory Bytes: {privateBytes} bytes";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving memory usage information: {ex.Message}");
                return "Error: Unable to retrieve memory usage information.";
            }
        }
    }
}
