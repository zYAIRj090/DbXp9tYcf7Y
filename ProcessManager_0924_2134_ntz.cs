// 代码生成时间: 2025-09-24 21:34:33
using System;
using System.Diagnostics;
using System.Collections.Generic;

/// <summary>
/// Provides functionality to manage and interact with system processes.
/// </summary>
public class ProcessManager
{
    /// <summary>
    /// List all running processes on the system.
    /// </summary>
    /// <returns>A list of Process objects.</returns>
    public List<Process> ListProcesses()
    {
        try
        {
            // Get all running processes
            return new List<Process>(Process.GetProcesses());
        }
        catch (Exception ex)
        {
            // Log the exception or handle it accordingly
            Console.WriteLine($"An error occurred while listing processes: {ex.Message}");
            return new List<Process>();
        }
    }

    /// <summary>
    /// Start a new process with the specified file path and arguments.
    /// </summary>
    /// <param name="filePath">The path to the executable file.</param>
    /// <param name="arguments">The arguments to pass to the executable.</param>
    /// <returns>The started process if successful, null otherwise.</returns>
    public Process StartProcess(string filePath, string arguments = "")
    {
        try
        {
            // Create a new process start info
            ProcessStartInfo startInfo = new ProcessStartInfo(filePath, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the process
            Process process = Process.Start(startInfo);
            return process;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it accordingly
            Console.WriteLine($"An error occurred while starting process: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Kill a process by its ID.
    /// </summary>
    /// <param name="processId">The ID of the process to kill.</param>
    public void KillProcessById(int processId)
    {
        try
        {
            // Get the process by its ID
            Process process = Process.GetProcessById(processId);
            // Kill the process
            process.Kill();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it accordingly
            Console.WriteLine($"An error occurred while killing process: {ex.Message}");
        }
    }

    /// <summary>
    /// Kill a process by its name.
    /// </summary>
    /// <param name="processName">The name of the process to kill.</param>
    public void KillProcessByName(string processName)
    {
        try
        {
            // Get all processes by name
            foreach (Process process in Process.GetProcessesByName(processName))
            {
                // Kill each process
                process.Kill();
            }
        }
        catch (Exception ex)
        {
            // Log the exception or handle it accordingly
            Console.WriteLine($"An error occurred while killing process by name: {ex.Message}");
        }
    }
}
