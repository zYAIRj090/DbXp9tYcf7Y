// 代码生成时间: 2025-08-04 03:25:20
using System;
using System.IO;
using System.IO.Compression;

namespace FileDecompressionTool
{
    public class FileDecompressor
    {
        // Decompress a file from a specified path to a target directory.
        public void DecompressFile(string sourceFilePath, string destinationDirectory)
        {
            // Check if the source file exists
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("The source file does not exist.", sourceFilePath);
            }

            // Ensure the destination directory exists
            Directory.CreateDirectory(destinationDirectory);

            try
            {
                // Use FileStream to read from the compressed file
                using (FileStream zipToUnpack = File.OpenRead(sourceFilePath))
                {
                    // Use ZipArchive to handle the decompression
                    ZipArchive archive = new ZipArchive(zipToUnpack, ZipArchiveMode.Read);

                    // Loop through all the files in the archive and extract them
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (!entry.FullName.EndsWith("/")) // Skip directories
                        {
                            // Create directory structure
                            string directoryPath = Path.GetDirectoryName(Path.Combine(destinationDirectory, entry.FullName));
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            // Extract the file
                            using (FileStream fileStream = File.Create(Path.Combine(destinationDirectory, entry.FullName)))
                            {
                                entry.Open().CopyTo(fileStream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while decompressing the file: {ex.Message}");
                throw;
            }
        }
    }

    // Main class to run the decompression tool
    public class Program
    {
        public static void Main(string[] args)
        {
            // Check if command line arguments are provided
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: FileDecompressionTool <source file path> <destination directory>");
                return;
            }

            string sourceFilePath = args[0];
            string destinationDirectory = args[1];

            // Initialize the decompressor and decompress the file
            FileDecompressor decompressor = new FileDecompressor();
            try
            {
                decompressor.DecompressFile(sourceFilePath, destinationDirectory);
                Console.WriteLine("Decompression completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Decompression failed: {ex.Message}");
            }
        }
    }
}