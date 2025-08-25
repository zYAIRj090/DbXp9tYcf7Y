// 代码生成时间: 2025-08-25 16:26:27
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BatchFileRenamerApp
{
    class BatchFileRenamer
    {
        private readonly string _sourceDirectory;
        private readonly string _targetDirectory;
        private readonly bool _overwriteExistingFiles;

        // 构造函数
        public BatchFileRenamer(string sourceDirectory, string targetDirectory, bool overwriteExistingFiles)
        {
            _sourceDirectory = sourceDirectory;
            _targetDirectory = targetDirectory;
            _overwriteExistingFiles = overwriteExistingFiles;
        }

        // 执行批量重命名操作
        public void RenameFiles()
        {
            try
            {
                // 获取源目录下的所有文件
                var files = Directory.GetFiles(_sourceDirectory);

                // 遍历所有文件
                foreach (var file in files)
                {
                    // 获取文件名
                    var fileInfo = new FileInfo(file);
                    var fileName = fileInfo.Name;

                    // 生成新文件名
                    var newFileName = GenerateNewFileName(fileName);

                    // 构建目标文件路径
                    var targetFilePath = Path.Combine(_targetDirectory, newFileName);

                    // 检查目标文件是否已存在
                    if (!File.Exists(targetFilePath) || _overwriteExistingFiles)
                    {
                        // 重命名文件
                        File.Move(file, targetFilePath);
                        Console.WriteLine($"文件 {fileName} 已重命名为 {newFileName} 并移动到 {_targetDirectory}");
                    }
                    else
                    {
                        Console.WriteLine($"文件 {newFileName} 已存在，跳过重命名...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误: {ex.Message}");
            }
        }

        // 生成新的文件名（示例实现）
        private string GenerateNewFileName(string originalFileName)
        {
            // 简单的重命名规则：添加前缀“new_”
            return $"new_{originalFileName}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 源目录、目标目录和是否覆盖已存在文件的参数
            var sourceDirectory = @"C:\source_folder";
            var targetDirectory = @"C:	arget_folder";
            var overwriteExistingFiles = true;

            // 创建重命名工具实例
            var renamer = new BatchFileRenamer(sourceDirectory, targetDirectory, overwriteExistingFiles);

            // 执行重命名操作
            renamer.RenameFiles();
        }
    }
}
