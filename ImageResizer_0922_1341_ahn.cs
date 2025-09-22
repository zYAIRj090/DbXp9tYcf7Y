// 代码生成时间: 2025-09-22 13:41:07
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    /*
     * ImageResizer class: a utility class for resizing images.
     */
    public class ImageResizer
    {
        private string sourceFolder;
        private string destinationFolder;
        private int newWidth;
        private int newHeight;

        /*
         * Constructor: Initializes the ImageResizer with source and destination folders,
         * and new width and height for the images.
         */
        public ImageResizer(string srcFolder, string destFolder, int width, int height)
        {
            sourceFolder = srcFolder;
            destinationFolder = destFolder;
            newWidth = width;
            newHeight = height;
        }

        /*
         * Resizes all images in the source folder and saves them to the destination folder.
         * @param resizeAllImages If true, resizes all images, otherwise resizes based on provided width and height parameters.
         */
        public void ResizeImages(bool resizeAllImages = false)
        {
            // Check if source and destination folders exist
            if (!Directory.Exists(sourceFolder))
            {
                throw new DirectoryNotFoundException("You have specified an invalid source folder.");
            }
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder); // Create destination folder if it doesn't exist
            }

            // Get all image files in the source folder
            var files = Directory.GetFiles(sourceFolder, "*");
            foreach (var file in files)
            {
                if (IsImageFile(file))
                {
                    ResizeImage(file);
                }
            }
        }

        /*
         * Resizes a single image and saves it to the destination folder.
         * @param filePath Path to the image file to be resized.
         */
        private void ResizeImage(string filePath)
        {
            try
            {
                using (var image = Image.FromFile(filePath))
                {
                    // Calculate aspect ratio to maintain the image proportions
                    float ratio = (float)newWidth / (float)image.Width;
                    int height = (int)(image.Height * ratio);

                    // We use the smaller dimension to resize the image, either newWidth or newHeight
                    int width = newWidth;
                    int finalHeight = height;

                    if (finalHeight > newHeight)
                    {
                        ratio = (float)newHeight / (float)image.Height;
                        width = (int)(image.Width * ratio);
                        finalHeight = newHeight;
                    }

                    // Create a new bitmap to hold the resized image
                    using (var resizedImage = new Bitmap(newWidth, finalHeight))
                    {
                        using (var graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.DrawImage(image, 0, 0, width, finalHeight);
                        }

                        // Save the resized image to the destination folder
                        string fileName = Path.GetFileName(filePath);
                        string destinationPath = Path.Combine(destinationFolder, fileName);
                        resizedImage.Save(destinationPath, image.RawFormat);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while resizing {filePath}: {ex.Message}");
            }
        }

        /*
         * Checks if a file is an image based on its extension.
         * @param filePath Path to the file to check.
         * @return True if the file is an image, otherwise false.
         */
        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }
    }

    /*
     * Program class: contains the entry point for the application.
     */
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourceFolder = @"C:\Images\Source";
                string destinationFolder = @"C:\Images\Destination";
                int newWidth = 800;
                int newHeight = 600;

                ImageResizer imageResizer = new ImageResizer(sourceFolder, destinationFolder, newWidth, newHeight);
                imageResizer.ResizeImages();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
