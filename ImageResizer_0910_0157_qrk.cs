// 代码生成时间: 2025-09-10 01:57:19
// ImageResizer.cs
// This class provides functionality to batch resize images.
# NOTE: 重要实现细节
using System;
using System.IO;
# 扩展功能模块
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageProcessing
{
    public class ImageResizer
    {
        // Resizes a single image to the specified size.
        private Bitmap ResizeImage(string imagePath, int width, int height)
        {
            try
            {
                // Load the image from the specified path.
                using (Image originalImage = Image.FromFile(imagePath))
                {
                    // Create a new bitmap to hold the resized image.
# NOTE: 重要实现细节
                    Bitmap resizedImage = new Bitmap(width, height);

                    using (Graphics graphics = Graphics.FromImage(resizedImage))
                    {
                        // Set the quality of the resized image.
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        // Draw the original image on the resized image.
                        graphics.DrawImage(originalImage, 0, 0, width, height);
# 添加错误处理
                    }
# 改进用户体验

                    // Save the resized image back to the disk.
                    string resizedImagePath = Path.Combine(Path.GetDirectoryName(imagePath), "resized_" + Path.GetFileName(imagePath));
                    resizedImage.Save(resizedImagePath, ImageFormat.Png);

                    // Return the resized image.
                    return resizedImage;
                }
            }
# 改进用户体验
            catch (Exception ex)
            {
                // Handle exceptions related to image loading and saving.
                Console.WriteLine("Error resizing image: " + ex.Message);
                return null;
            }
        }

        // Resizes all images in a specified directory to the specified size.
        public void ResizeImagesInDirectory(string directoryPath, int width, int height)
        {
            try
            {
# FIXME: 处理边界情况
                // Check if the directory exists.
                if (!Directory.Exists(directoryPath))
                {
                    throw new DirectoryNotFoundException("The specified directory does not exist.");
                }

                // Get all image files in the directory.
                string[] imagePaths = Directory.GetFiles(directoryPath, "*.*", SearchOption.TopDirectoryOnly);

                foreach (string imagePath in imagePaths)
                {
                    // Check if the file is an image.
                    if (IsImageFile(imagePath))
                    {
                        // Resize the image.
                        ResizeImage(imagePath, width, height);
                    }
                }
            }
            catch (Exception ex)
# 优化算法效率
            {
                // Handle exceptions related to directory access.
                Console.WriteLine("Error resizing images: " + ex.Message);
            }
        }

        // Checks if the file is an image based on its extension.
        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
# 扩展功能模块
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".bmp" || extension == ".gif";
        }
    }
}
