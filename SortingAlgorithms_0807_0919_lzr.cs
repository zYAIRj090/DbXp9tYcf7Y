// 代码生成时间: 2025-08-07 09:19:48
using System;
using System.Collections.Generic;

// 这个类包含了各种排序算法的实现
public class SortingAlgorithms
{
    // 冒泡排序算法
    public static List<int> BubbleSort(List<int> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "列表不能为空");
        }

        int n = list.Count;
        bool swapped;
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    // 交换元素
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    swapped = true;
                }
            }
            // 如果没有发生交换，则列表已经排序完成
            if (!swapped)
            {
                break;
            }
        }
        return list;
    }

    // 插入排序算法
    public static List<int> InsertionSort(List<int> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "列表不能为空");
        }

        for (int i = 1; i < list.Count; i++)
        {
            int key = list[i];
            int j = i - 1;

            while (j >= 0 && list[j] > key)
            {
                list[j + 1] = list[j];
                j = j - 1;
            }
            list[j + 1] = key;
        }
        return list;
    }

    // 快速排序算法
    public static List<int> QuickSort(List<int> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "列表不能为空");
        }

        return QuickSort(list, 0, list.Count - 1);
    }

    private static List<int> QuickSort(List<int> list, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(list, low, high);

            QuickSort(list, low, pi - 1);
            QuickSort(list, pi + 1, high);
        }
        return list;
    }

    private static int Partition(List<int> list, int low, int high)
    {
        int pivot = list[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (list[j] < pivot)
            {
                i++;
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }

        int temp = list[i + 1];
        list[i + 1] = list[high];
        list[high] = temp;

        return i + 1;
    }

    // 程序的主入口
    public static void Main(string[] args)
    {
        try
        {
            List<int> numbers = new List<int> { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("原始列表: " + string.Join(", ", numbers));

            // 使用冒泡排序
            List<int> sortedNumbers = BubbleSort(new List<int>(numbers));
            Console.WriteLine("冒泡排序后的列表: " + string.Join(", ", sortedNumbers));

            // 使用插入排序
            sortedNumbers = InsertionSort(new List<int>(numbers));
            Console.WriteLine("插入排序后的列表: " + string.Join(", ", sortedNumbers));

            // 使用快速排序
            sortedNumbers = QuickSort(new List<int>(numbers));
            Console.WriteLine("快速排序后的列表: " + string.Join(", ", sortedNumbers));
        }
        catch (Exception ex)
        {
            Console.WriteLine("发生错误: " + ex.Message);
        }
    }
}