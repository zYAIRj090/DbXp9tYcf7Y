// 代码生成时间: 2025-08-24 14:50:00
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

// 文件夹结构整理器
public class FolderOrganizer
{
    // 目标文件夹路径
    private string targetFolderPath;

    // 文件夹结构整理器构造函数
    public FolderOrganizer(string targetFolderPath)
    {
        if (!Directory.Exists(targetFolderPath))
        {
            throw new ArgumentException("The specified folder does not exist.");
        }

        this.targetFolderPath = targetFolderPath;
    }

    // 整理文件夹结构
    public void Organize()
    {
        try
        {
            // 获取目标文件夹内的所有文件
            var files = Directory.GetFiles(targetFolderPath, "*.*", SearchOption.AllDirectories).ToList();

            // 根据文件扩展名创建文件组织策略
            var fileStrategy = new Dictionary<string, Func<string, string>>();
            fileStrategy.Add(".jpg", name => Path.Combine(targetFolderPath, "Images", Path.GetFileName(name)));
            fileStrategy.Add(".mp4", name => Path.Combine(targetFolderPath, "Videos", Path.GetFileName(name)));
            // 可以根据需要添加更多文件类型的处理

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file).ToLower();
                if (fileStrategy.ContainsKey(extension))
                {
                    var newFilePath = fileStrategy[extension](file);

                    // 确保目标目录存在
                    var directoryName = Path.GetDirectoryName(newFilePath);
                    if (!Directory.Exists(directoryName))
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    // 移动文件
                    File.Move(file, newFilePath);
                }
            }

            Console.WriteLine("Folder organization completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

// 程序入口点
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter the path of the folder to organize: ");
            var folderPath = Console.ReadLine();

            var organizer = new FolderOrganizer(folderPath);
            organizer.Organize();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}