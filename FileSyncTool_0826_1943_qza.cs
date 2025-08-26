// 代码生成时间: 2025-08-26 19:43:28
 * Features:
 * - Backup specified files/directories to a backup location.
 * - Synchronize files between source and destination.
 * - Error handling to deal with file operations gracefully.
 * - Logging for actions performed.
 *
 * Instructions:
 * - Customize the sourcePath, destinationPath, and backupPath variables.
 * - Ensure the backupPath directory exists or create it before running the program.
 */

using System;
using System.IO;

class FileSyncTool
{
    private static readonly string sourcePath = @"C:\source_directory";
    private static readonly string destinationPath = @"C:\destination_directory";
    private static readonly string backupPath = @"C:\backup_directory";
    private static readonly string logFilePath = @"C:\log.txt";

    // Main entry point of the application
    static void Main(string[] args)
    {
        try
        {
            // Perform file backup
            BackupFiles();

            // Synchronize files between source and destination
            SynchronizeFiles();

            // Log the completion of operations
            LogAction("File synchronization and backup completed successfully.");
        }
        catch (Exception ex)
        {
            LogAction($"An error occurred: {ex.Message}");
        }
    }

    // Method to backup files
    private static void BackupFiles()
    {
        if (!Directory.Exists(backupPath))
        {
            LogAction($"Backup directory not found, creating at {backupPath}.");
            Directory.CreateDirectory(backupPath);
        }

        foreach (var file in Directory.GetFiles(sourcePath))
        {
            string backupFile = Path.Combine(backupPath, Path.GetFileName(file));
            File.Copy(file, backupFile, true);
            LogAction($"Backed up file {Path.GetFileName(file)} to {backupFile}.");
        }
    }

    // Method to synchronize files between source and destination
    private static void SynchronizeFiles()
    {
        // Get all files in source directory
        var sourceFiles = Directory.GetFiles(sourcePath);
        // Get all files in destination directory
        var destinationFiles = Directory.GetFiles(destinationPath);

        foreach (var sourceFile in sourceFiles)
        {
            var destinationFile = Path.Combine(destinationPath, Path.GetFileName(sourceFile));
            // Check if file exists in destination
            if (!File.Exists(destinationFile))
            {
                File.Copy(sourceFile, destinationFile, true);
                LogAction($"Copied {Path.GetFileName(sourceFile)} to {destinationPath}.");
            }
            else if (File.GetLastWriteTimeUtc(sourceFile) > File.GetLastWriteTimeUtc(destinationFile))
            {
                File.Copy(sourceFile, destinationFile, true);
                LogAction($"Updated {Path.GetFileName(destinationFile)} in {destinationPath}.");
            }
        }
    }

    // Method to log actions
    private static void LogAction(string message)
    {
        File.AppendAllText(logFilePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message + Environment.NewLine);
    }
}
