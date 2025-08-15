// 代码生成时间: 2025-08-15 17:49:21
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace ProcessManagement
{
    public class ProcessManager
    {
        // List all running processes on the system
        public List<Process> ListProcesses()
        {
            try
            {
                // Get all running processes
                return Process.GetProcesses().ToList();
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.WriteLine($"Error listing processes: {ex.Message}");
                return new List<Process>();
            }
        }

        // Start a new process with the given command line arguments
        public bool StartProcess(string fileName, string arguments)
        {
            try
            {
                // Create a new process start info
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments
                };

                // Start the process
                Process process = Process.Start(startInfo);
                return process != null;
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.WriteLine($"Error starting process: {ex.Message}");
                return false;
            }
        }

        // Terminate a process by its process ID
        public bool TerminateProcess(int processId)
        {
            try
            {
                // Get the process by its ID
                Process process = Process.GetProcessById(processId);

                // Terminate the process
                process.Kill();
                return true;
            }
            catch (Exception ex)
            {
                // Log and handle exceptions
                Console.WriteLine($"Error terminating process: {ex.Message}");
                return false;
            }
        }
    }
}
