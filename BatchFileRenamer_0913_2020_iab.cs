// 代码生成时间: 2025-09-13 20:20:38
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace BatchFileRenamer
{
    /// <summary>
    /// Class responsible for renaming files in a directory.
    /// </summary>
    public class BatchFileRenamer
    {
        /// <summary>
        /// The path to the directory containing the files to rename.
        /// </summary>
        private readonly string _directoryPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchFileRenamer"/> class.
        /// </summary>
        /// <param name="directoryPath">The path of the directory.</param>
        public BatchFileRenamer(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        /// <summary>
        /// Renames files in the directory according to a given pattern.
        /// </summary>
        /// <param name="searchPattern">The pattern to search for in file names.</param>
        /// <param name="replacement">The replacement string for the found pattern.</param>
        public void RenameFiles(string searchPattern, string replacement)
        {
            // Check if the directory exists to prevent exceptions.
            if (!Directory.Exists(_directoryPath))
            {
                Console.WriteLine("The specified directory does not exist.");
                return;
            }

            // Get all files in the directory.
            var files = Directory.GetFiles(_directoryPath);
            foreach (var file in files)
            {
                try
                {
                    // Get the file name without extension.
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    var extension = Path.GetExtension(file);

                    // Replace the search pattern in the file name.
                    var newFileName = Regex.Replace(fileName, searchPattern, replacement);

                    // Create the full path for the new file name.
                    var newFilePath = Path.Combine(_directoryPath, newFileName + extension);

                    // Rename the file.
                    File.Move(file, newFilePath);

                    // Output the result to the console.
                    Console.WriteLine($"Renamed '{file}' to '{newFilePath}'");
                }
                catch (Exception ex)
                {
                    // Handle exceptions that may occur during file renaming.
                    Console.WriteLine($"Error renaming file '{file}': {ex.Message}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the BatchFileRenamer class.
            // This should be replaced by actual user input or command line arguments in a real application.
            var directoryPath = @"C:\path	o\files";
            var searchPattern = @"old";
            var replacement = @"new";

            using (var renamer = new BatchFileRenamer(directoryPath))
            {
                renamer.RenameFiles(searchPattern, replacement);
            }
        }
    }
}