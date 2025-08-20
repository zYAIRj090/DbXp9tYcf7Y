// 代码生成时间: 2025-08-20 15:26:08
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ErrorLogCollector
{
    /// <summary>
    /// A simple error log collector that writes errors to a file.
    /// </summary>
    public class ErrorLogCollector
    {
        private const string LogFileName = "error_log.txt";
        private readonly string _logFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLogCollector"/> class.
        /// </summary>
        /// <param name="logDirectory">Directory where the error log file will be stored.</param>
        public ErrorLogCollector(string logDirectory)
        {
            if (string.IsNullOrWhiteSpace(logDirectory))
                throw new ArgumentException("Log directory cannot be null or empty.", nameof(logDirectory));

            _logFilePath = Path.Combine(logDirectory, LogFileName);
        }

        /// <summary>
        /// Logs an error with the specified message.
        /// </summary>
        /// <param name="errorMessage">The error message to log.</param>
        public void LogError(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("Error message cannot be null or empty.", nameof(errorMessage));

            lock (_logFilePath)
            {
                try
                {
                    File.AppendAllText(_logFilePath, $