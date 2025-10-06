// 代码生成时间: 2025-10-07 02:20:25
 * Description:
 *   This program is a batch file renamer tool. It allows users to
 *   rename multiple files in a directory based on a specified pattern.
 *
 * Author: Your Name
 * Date: Today's Date
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace BulkFileRenamerApp
{
    public class BulkFileRenamer
    {
        private string sourceDirectory;
        private string pattern;
        private string replacement;
        private int startIndex;
        private bool includeExtension;

        // Constructor
        public BulkFileRenamer(string sourceDirectory, string pattern, string replacement, int startIndex, bool includeExtension)
        {
            this.sourceDirectory = sourceDirectory;
            this.pattern = pattern;
            this.replacement = replacement;
            this.startIndex = startIndex;
            this.includeExtension = includeExtension;
        }

        // Method to rename files
        public void RenameFiles()
        {
            try
            {
                // Check if the directory exists
                if (!Directory.Exists(sourceDirectory))
                {
                    throw new DirectoryNotFoundException($"The directory {sourceDirectory} does not exist.");
                }

                // Get all files in the directory
                var files = Directory.GetFiles(sourceDirectory);

                for (int i = 0; i < files.Length; i++)
                {
                    var fileName = Path.GetFileName(files[i]);
                    var fileInfo = new FileInfo(files[i]);
                    var fileNameWithoutExtension = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.'));
                    var fileExtension = fileInfo.Extension;

                    // Check if the file name matches the pattern
                    if (fileNameWithoutExtension.Contains(pattern))
                    {
                        // Generate the new file name
                        var newFileName = fileNameWithoutExtension.Replace(pattern, replacement).Insert(startIndex, i.ToString());
                        if (includeExtension)
                        {
                            newFileName += fileExtension;
                        }

                        // Construct the full path for the new file name
                        var newFilePath = Path.Combine(sourceDirectory, newFileName);

                        // Rename the file
                        File.Move(fileInfo.FullName, newFilePath);
                    }
                }
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
            // Example usage of the BulkFileRenamer class
            string sourceDir = @"C:\example\directory"; // Specify the directory path
            string pattern = @"old"; // Specify the pattern to find
            string replacement = @"new"; // Specify the replacement text
            int startIndex = 5; // Specify the index where the replacement should start
            bool includeExtension = true; // Specify whether to include the file extension in the new name

            var renamer = new BulkFileRenamer(sourceDir, pattern, replacement, startIndex, includeExtension);
            renamer.RenameFiles();
        }
    }
}
