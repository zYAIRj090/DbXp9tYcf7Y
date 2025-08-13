// 代码生成时间: 2025-08-14 00:18:48
using System;
using System.IO;
using System.IO.Compression;

namespace FileDecompressionTool
{
    public class FileDecompressionTool
    {
        /// <summary>
        /// Decompresses the specified archive file to the destination directory.
        /// </summary>
        /// <param name="archivePath">The path to the archive file.</param>
        /// <param name="destinationPath">The path to the destination directory.</param>
        public void DecompressFile(string archivePath, string destinationPath)
        {
            try
            {
                // Check if the archive file exists
                if (!File.Exists(archivePath))
                {
                    throw new FileNotFoundException("The archive file does not exist.", archivePath);
                }

                // Check if the destination directory exists, if not create it
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                // Determine the compression method based on the file extension
                switch (Path.GetExtension(archivePath).ToLower())
                {
                    case ".zip":
                        ZipFile.ExtractToDirectory(archivePath, destinationPath);
                        break;
                    case ".rar":
                        // RAR decompression would require a third-party library as .NET does not support it natively
                        throw new NotSupportedException("RAR decompression is not supported.");
                    default:
                        throw new NotSupportedException("The compression format is not supported.");
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it as needed
                Console.WriteLine("An error occurred during decompression: " + ex.Message);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the FileDecompressionTool class
            var decompressionTool = new FileDecompressionTool();
            string archivePath = @"path	o\your\archive.zip"; // Replace with your archive file path
            string destinationPath = @"path	o\destination\directory"; // Replace with your destination directory path

            try
            {
                decompressionTool.DecompressFile(archivePath, destinationPath);
                Console.WriteLine("File decompressed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to decompress file: " + ex.Message);
            }
        }
    }
}
