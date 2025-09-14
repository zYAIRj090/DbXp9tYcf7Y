// 代码生成时间: 2025-09-14 14:50:29
 * It's designed to be clear, maintainable, and extensible.
 *
 * Requirements:
 * - Clear code structure
 * - Error handling
 * - Comments and documentation
 * - Adherence to C# best practices
 * - Maintainability and extensibility
 */
using System;
using System.Collections.Generic;

namespace SearchAlgorithmOptimization
{
    /// <summary>
    /// This class provides a generic search algorithm optimization feature.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list to search.</typeparam>
    public class SearchAlgorithmOptimizer<T> where T : IComparable<T>
    {
        /// <summary>
        /// Searches for the first occurrence of a given item in a list using a binary search algorithm.
        /// </summary>
        /// <param name="list">The sorted list of items to search within.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>The index of the item if found, otherwise -1.</returns>
        public int BinarySearch(IList<T> list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            int left = 0;
            int right = list.Count - 1;
            int result = -1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;
                int comparison = list[middle].CompareTo(item);

                if (comparison == 0)
                {
                    result = middle;
                    break;
                }
                else if (comparison < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Searches for the first occurrence of a given item in a list using a linear search algorithm.
        /// </summary>
        /// <param name="list">The list of items to search within.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>The index of the item if found, otherwise -1.</returns>
        public int LinearSearch(IList<T> list, T item)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        // Additional search algorithms can be added here following the same pattern.
    }

    // Example usage of the SearchAlgorithmOptimizer class.
    class Program
    {
        static void Main(string[] args)
        {
            var optimizer = new SearchAlgorithmOptimizer<int>();
            List<int> testList = new List<int> { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
            int searchItem = 13;

            // Perform a binary search.
            int binarySearchResult = optimizer.BinarySearch(testList, searchItem);
            Console.WriteLine($"Binary Search result for item {searchItem}: {binarySearchResult} (should be 6)");

            // Perform a linear search.
            int linearSearchResult = optimizer.LinearSearch(testList, searchItem);
            Console.WriteLine($"Linear Search result for item {searchItem}: {linearSearchResult} (should be 6)");
        }
    }
}
