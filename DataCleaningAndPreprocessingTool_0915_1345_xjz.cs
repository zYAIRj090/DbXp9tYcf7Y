// 代码生成时间: 2025-09-15 13:45:59
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataPreprocessing
{
    /// <summary>
    /// 数据清洗和预处理工具
    /// </summary>
    public static class DataCleaningAndPreprocessingTool
    {
        /// <summary>
        /// 清洗文本数据
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <returns>清洗后的数据</returns>
        public static string CleanTextData(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            // 去除多余空格
            data = data.Trim();

            // 替换掉不可见字符
            data = Regex.Replace(data, "[^\w\s\.,!?-]", "");

            // 将所有大写字母转换为小写
            data = data.ToLowerInvariant();

            return data;
        }

        /// <summary>
        /// 读取数据文件并进行预处理
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>预处理后的数据集合</returns>
        public static List<string> PreprocessDataFromFile(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException("文件未找到", filePath);

            var preprocessedData = new List<string>();
            var allLines = File.ReadAllLines(filePath);
            foreach (var line in allLines)
            {
                var cleanedLine = CleanTextData(line);
                preprocessedData.Add(cleanedLine);
            }

            return preprocessedData;
        }

        /// <summary>
        /// 主程序入口
        /// </summary>
        /// <param name="args">命令行参数</param>
        public static void Main(string[] args)
        {
            try
            {
                // 假设我们有一个名为"data.txt"的文件需要预处理
                var filePath = "data.txt";

                var preprocessedData = PreprocessDataFromFile(filePath);
                foreach (var data in preprocessedData)
                {
                    Console.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
    }
}