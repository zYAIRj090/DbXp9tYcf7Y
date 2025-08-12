// 代码生成时间: 2025-08-13 05:36:56
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace ImageProcessing
{
    /// <summary>
    /// 图片尺寸批量调整器
    /// </summary>
    public class ImageResizer
    {
        private readonly string _sourceDirectory;
        private readonly string _targetDirectory;
        private readonly int _newWidth;
        private readonly int _newHeight;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sourceDirectory">源文件夹路径</param>
        /// <param name="targetDirectory">目标文件夹路径</param>
        /// <param name="newWidth">新的宽度</param>
        /// <param name="newHeight">新的高度</param>
        public ImageResizer(string sourceDirectory, string targetDirectory, int newWidth, int newHeight)
        {
            _sourceDirectory = sourceDirectory;
            _targetDirectory = targetDirectory;
            _newWidth = newWidth;
            _newHeight = newHeight;
        }

        /// <summary>
        /// 调整图片尺寸
        /// </summary>
        public void ResizeImages()
        {
            if (!Directory.Exists(_sourceDirectory))
            {
                throw new DirectoryNotFoundException($"源文件夹 {_sourceDirectory} 不存在。");
            }

            if (!Directory.Exists(_targetDirectory))
            {
                Directory.CreateDirectory(_targetDirectory);
            }

            var files = Directory.GetFiles(_sourceDirectory, "*.*").Where(f => IsImageFile(f));
            foreach (var file in files)
            {
                try
                {
                    ResizeImage(file, Path.Combine(_targetDirectory, Path.GetFileName(file)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"处理文件 {file} 时发生错误：{ex.Message}");
                }
            }
        }

        /// <summary>
        /// 检查文件是否为图片
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        private bool IsImageFile(string filePath)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
            return imageExtensions.Any(extension => filePath.EndsWith(extension, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// 调整单个图片尺寸
        /// </summary>
        /// <param name="sourcePath">源图片路径</param>
        /// <param name="targetPath">目标图片路径</param>
        private void ResizeImage(string sourcePath, string targetPath)
        {
            using (var originalImage = Image.FromFile(sourcePath))
            {
                // 计算新的尺寸
                float ratio = (float)Math.Min((double)_newWidth / originalImage.Width, _newHeight / (double)originalImage.Height);
                int newWidth = (int)(originalImage.Width * ratio);
                int newHeight = (int)(originalImage.Height * ratio);

                using (var resizedImage = new Bitmap(newWidth, newHeight))
                {
                    using (var graphics = Graphics.FromImage(resizedImage))
                    {
                        graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                        graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
                    }
                    resizedImage.Save(targetPath, originalImage.RawFormat);
                }
            }
        }
    }
}
