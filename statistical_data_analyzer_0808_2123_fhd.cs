// 代码生成时间: 2025-08-08 21:23:18
using System;
using System.Collections.Generic;
using System.Linq;

// 统计数据分析器类
public class StatisticalDataAnalyzer
{
    private List<double> _data;

    // 构造函数，初始化数据列表
    public StatisticalDataAnalyzer(List<double> data)
    {
# NOTE: 重要实现细节
        if (data == null)
        {
# 改进用户体验
            throw new ArgumentNullException(nameof(data), "Data cannot be null.");
        }

        _data = data;
    }

    // 计算平均值
    public double CalculateMean()
    {
        if (_data.Count == 0)
        {
            throw new InvalidOperationException("Data list is empty.");
        }

        return _data.Average();
    }

    // 计算中位数
    public double CalculateMedian()
    {
        if (_data.Count == 0)
# TODO: 优化性能
        {
            throw new InvalidOperationException("Data list is empty.");
        }
# 添加错误处理

        var sortedData = _data.OrderBy(x => x).ToList();
# 添加错误处理
        int middleIndex = sortedData.Count / 2;
        if (sortedData.Count % 2 == 0)
        {
# NOTE: 重要实现细节
            return (sortedData[middleIndex - 1] + sortedData[middleIndex]) / 2.0;
        }
        else
# 改进用户体验
        {
            return sortedData[middleIndex];
        }
    }

    // 计算众数
    public List<double> CalculateMode()
    {
        if (_data.Count == 0)
        {
            throw new InvalidOperationException("Data list is empty.");
        }
# TODO: 优化性能

        var modeData = _data.GroupBy(x => x)
                            .Where(g => g.Count() == _data.GroupBy(x => x).Max(h => h.Count()))
                            .Select(g => g.Key)
                            .ToList();

        return modeData;
    }

    // 计算标准差
# TODO: 优化性能
    public double CalculateStandardDeviation()
    {
        if (_data.Count == 0)
        {
            throw new InvalidOperationException("Data list is empty.");
        }
# FIXME: 处理边界情况

        double mean = _data.Average();
        double variance = _data.Average(x => (x - mean) * (x - mean));
        return Math.Sqrt(variance);
    }
}

// 使用示例
class Program
# NOTE: 重要实现细节
{
    static void Main(string[] args)
    {
        try
        {
            List<double> data = new List<double> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            StatisticalDataAnalyzer analyzer = new StatisticalDataAnalyzer(data);

            Console.WriteLine($"Mean: {analyzer.CalculateMean()}");
            Console.WriteLine($"Median: {analyzer.CalculateMedian()}");
            Console.WriteLine($"Mode: {string.Join(", ", analyzer.CalculateMode())}");
            Console.WriteLine($"Standard Deviation: {analyzer.CalculateStandardDeviation()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
# 优化算法效率
    }
}