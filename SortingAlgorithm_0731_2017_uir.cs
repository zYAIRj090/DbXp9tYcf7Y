// 代码生成时间: 2025-07-31 20:17:01
// This file contains a simple SortingAlgorithm class which implements
// a basic sorting algorithm in C#. This can be easily extended to other
// algorithms and usage contexts.

using System;
using System.Collections.Generic;

namespace SortingAlgorithm
{
    public class SortingAlgorithm
    {
        /// <summary>
        /// Sorts an array of integers using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="arr">The array of integers to be sorted.</param>
        public void BubbleSort(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array of integers using the Quick Sort algorithm.
        /// </summary>
        /// <param name="arr">The array of integers to be sorted.</param>
        public void QuickSort(int[] arr)
        {
            if (arr == null)
                throw new ArgumentNullException(nameof(arr));

            if (arr.Length <= 1)
                return;

            QuickSort(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// The recursive part of the Quick Sort algorithm.
        /// </summary>
        /// <param name="arr">The array of integers to be sorted.</param>
        /// <param name="low">The lower index of the array partition.</param>
        /// <param name="high">The higher index of the array partition.</param>
        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        /// <summary>
        /// The partitioning function for the Quick Sort algorithm.
        /// </summary>
        /// <param name="arr">The array of integers to be sorted.</param>
        /// <param name="low">The lower index of the array partition.</param>
        /// <param name="high">The higher index of the array partition.</param>
        /// <returns>The pivot index after partitioning.</returns>
        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return (i + 1);
        }

        /// <summary>
        /// Helper function to swap two elements in an array.
        /// </summary>
        /// <param name="arr">The array containing the elements to swap.</param>
        /// <param name="i">The index of the first element to swap.</param>
        /// <param name="j">The index of the second element to swap.</param>
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SortingAlgorithm sorter = new SortingAlgorithm();
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };
            sorter.BubbleSort(array);
            Console.WriteLine("Sorted array using Bubble Sort: ");
            PrintArray(array);

            sorter.QuickSort(array);
            Console.WriteLine("Sorted array using Quick Sort: ");
            PrintArray(array);
        }

        /// <summary>
        /// Helper function to print elements of an array.
        /// </summary>
        /// <param name="arr">The array to print.</param>
        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
