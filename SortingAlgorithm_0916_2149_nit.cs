// 代码生成时间: 2025-09-16 21:49:03
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 排序算法实现类
/// </summary>
public class SortingAlgorithm
{
    
    /// <summary>
    /// 冒泡排序算法
    /// </summary>
    /// <param name="array">需要排序的数组</param>
    public static void BubbleSort(int[] array)
    {
        // 检查数组是否为空
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("数组不能为空");
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    // 交换两个元素的位置
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    /// <summary>
    /// 选择排序算法
    /// </summary>
    /// <param name="array">需要排序的数组</param>
    public static void SelectionSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("数组不能为空");
        }

        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }
        }
    }

    /// <summary>
    /// 插入排序算法
    /// </summary>
    /// <param name="array">需要排序的数组</param>
    public static void InsertionSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("数组不能为空");
        }

        for (int i = 1; i < array.Length; i++)
        {
            int current = array[i];
            int j = i - 1;
            while (j >= 0 && array[j] > current)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = current;
        }
    }

    /// <summary>
    /// 归并排序算法
    /// </summary>
    /// <param name="array">需要排序的数组</param>
    public static void MergeSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("数组不能为空");
        }

        MergeSortHelper(array, 0, array.Length - 1);
    }

    private static void MergeSortHelper(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            MergeSortHelper(array, left, middle);
            MergeSortHelper(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    private static void Merge(int[] array, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            leftArray[i] = array[left + i];
        }
        for (int j = 0; j < n2; j++)
        {
            rightArray[j] = array[middle + 1 + j];
        }

        int i = 0, j = 0;
        int k = left;
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k] = leftArray[i];
                i++;
            }
            else
            {
                array[k] = rightArray[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = leftArray[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = rightArray[j];
            j++;
            k++;
        }
    }

    /// <summary>
    /// 快速排序算法
    /// </summary>
    /// <param name="array">需要排序的数组</param>
    public static void QuickSort(int[] array)
    {
        if (array == null || array.Length == 0)
        {
            throw new ArgumentException("数组不能为空");
        }

        QuickSortHelper(array, 0, array.Length - 1);
    }

    private static void QuickSortHelper(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(array, left, right);
            QuickSortHelper(array, left, pivotIndex - 1);
            QuickSortHelper(array, pivotIndex + 1, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        int temp = array[i + 1];
        array[i + 1] = array[right];
        array[right] = temp;
        return i + 1;
    }
}

/// <summary>
/// 程序入口类
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        int[] array = { 9, 2, 7, 5, 6, 3, 1, 8, 4 };

        Console.WriteLine("原始数组: " + string.Join(", ", array));

        SortingAlgorithm.BubbleSort(array);
        Console.WriteLine("冒泡排序后: " + string.Join(", ", array));

        array = new int[] { 9, 2, 7, 5, 6, 3, 1, 8, 4 };
        SortingAlgorithm.SelectionSort(array);
        Console.WriteLine("选择排序后: " + string.Join(", ", array));

        array = new int[] { 9, 2, 7, 5, 6, 3, 1, 8, 4 };
        SortingAlgorithm.InsertionSort(array);
        Console.WriteLine("插入排序后: " + string.Join(", ", array));

        array = new int[] { 9, 2, 7, 5, 6, 3, 1, 8, 4 };
        SortingAlgorithm.MergeSort(array);
        Console.WriteLine("归并排序后: " + string.Join(", ", array));

        array = new int[] { 9, 2, 7, 5, 6, 3, 1, 8, 4 };
        SortingAlgorithm.QuickSort(array);
        Console.WriteLine("快速排序后: " + string.Join(", ", array));
    }
}