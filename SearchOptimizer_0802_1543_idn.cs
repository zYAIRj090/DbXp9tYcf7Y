// 代码生成时间: 2025-08-02 15:43:07
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithmOptimization
{
    /// <summary>
    /// 搜索算法优化
    /// </summary>
    public class SearchOptimizer
    {
        /// <summary>
        /// 线性搜索优化
        /// </summary>
        /// <param name="array">待搜索数组</param>
        /// <param name="target">目标值</param>
        /// <returns>目标值的索引，如果未找到则返回-1</returns>
        public static int LinearSearchOptimized(int[] array, int target)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "数组不能为空");
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 二分搜索优化
        /// </summary>
        /// <param name="array">待搜索数组，必须已排序</param>
        /// <param name="target">目标值</param>
        /// <returns>目标值的索引，如果未找到则返回-1</returns>
        public static int BinarySearchOptimized(int[] array, int target)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "数组不能为空");
            }

            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }

        // Main 方法用于测试搜索算法优化
        public static void Main(string[] args)
        {
            try
            {
                int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
                int target = 13;

                int linearIndex = LinearSearchOptimized(array, target);
                Console.WriteLine($"线性搜索找到目标 {target}，索引：{linearIndex}");

                int binaryIndex = BinarySearchOptimized(array, target);
                Console.WriteLine($"二分搜索找到目标 {target}，索引：{binaryIndex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
    }
}