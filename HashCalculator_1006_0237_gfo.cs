// 代码生成时间: 2025-10-06 02:37:24
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashCalculator
{
# 优化算法效率
    /// <summary>
    /// A utility class for calculating hash values.
    /// </summary>
    public class HashCalculator
    {
# FIXME: 处理边界情况
        /// <summary>
        /// Calculates the SHA256 hash of a given string.
        /// </summary>
# 添加错误处理
        /// <param name="input">The string to be hashed.</param>
        /// <returns>The SHA256 hash of the input string as a hexadecimal string.</returns>
# FIXME: 处理边界情况
        public string CalculateSha256Hash(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or whitespace.", nameof(input));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                // ComputeHash - returns byte array
# 扩展功能模块
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string (Base64String)
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
# TODO: 优化性能
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
# 扩展功能模块
    }

    /// <summary>
    /// Program entry point.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
# TODO: 优化性能
        {
# 改进用户体验
            Console.WriteLine("Hash Calculator Tool");
            Console.WriteLine("Enter a string to calculate its SHA256 hash: ");
            string input = Console.ReadLine();

            try
            {
                HashCalculator hashCalculator = new HashCalculator();
                string hash = hashCalculator.CalculateSha256Hash(input);
                Console.WriteLine($"The SHA256 hash of '{input}' is: {hash}");
            }
            catch (Exception ex)
# 增强安全性
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
