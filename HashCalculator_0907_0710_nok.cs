// 代码生成时间: 2025-09-07 07:10:42
 * HashCalculator.cs - A utility for calculating hash values of strings.
 * 
# TODO: 优化性能
 * Copyright (c) 2023 YourCompanyName
 * 
 * This tool calculates hash values such as MD5, SHA1, and SHA256.
 * It's designed to be easy to use, with clear structure and error handling.
 */

using System;
using System.Security.Cryptography;
using System.Text;

namespace HashingTools
{
    /// <summary>
    /// A utility class for calculating hash values.
    /// </summary>
    public class HashCalculator
    {
        /// <summary>
# NOTE: 重要实现细节
        /// Calculates the hash value of a given string using a specified hash algorithm.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <param name="algorithm">The name of the hash algorithm to use.</param>
        /// <returns>The hash value of the input string.</returns>
        public string CalculateHash(string input, string algorithm)
        {
            // Validate input parameters
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }
# FIXME: 处理边界情况

            // Map the algorithm name to the corresponding HashAlgorithm implementation
            switch (algorithm.ToUpperInvariant())
            {
                case "MD5":
                    using (var hashAlg = MD5.Create())
                    {
                        return ComputeHash(hashAlg, input);
                    }
                case "SHA1":
# TODO: 优化性能
                    using (var hashAlg = SHA1.Create())
                    {
# 添加错误处理
                        return ComputeHash(hashAlg, input);
# 添加错误处理
                    }
                case "SHA256":
                    using (var hashAlg = SHA256.Create())
                    {
                        return ComputeHash(hashAlg, input);
                    }
                default:
                    throw new NotSupportedException($"Hash algorithm '{algorithm}' is not supported.");
            }
# NOTE: 重要实现细节
        }

        /// <summary>
        /// Computes the hash value using the specified HashAlgorithm and input string.
        /// </summary>
        /// <param name="hashAlg">The HashAlgorithm to use.</param>
        /// <param name="input">The string to hash.</param>
        /// <returns>The hash value as a hexadecimal string.</returns>
        private string ComputeHash(HashAlgorithm hashAlg, string input)
        {
            // Convert the input string to a byte array
# 扩展功能模块
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Compute the hash value
            byte[] hashBytes = hashAlg.ComputeHash(inputBytes);

            // Convert the hash bytes to a hexadecimal string
# TODO: 优化性能
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
# TODO: 优化性能
}
# NOTE: 重要实现细节
