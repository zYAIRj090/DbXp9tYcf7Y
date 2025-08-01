// 代码生成时间: 2025-08-02 03:18:33
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalysisApp
{
    /// <summary>
    /// A class that provides functionality to analyze data.
    /// </summary>
    public class DataAnalyzer
    {
        /// <summary>
        /// Analyzes a list of integers and returns the mean, median, and mode of the data set.
        /// </summary>
        /// <param name="data">A list of integers representing the data set.</param>
        /// <returns>A string containing the mean, median, and mode of the data set.</returns>
        public string AnalyzeData(List<int> data)
        {
            if (data == null || data.Count == 0)
            {
                throw new ArgumentException("Data list is empty or null.");
            }

            double mean = CalculateMean(data);
            double median = CalculateMedian(data);
            int mode = GetMode(data);

            return $"Mean: {mean}, Median: {median}, Mode: {mode}";
        }

        /// <summary>
        /// Calculates the mean of a list of integers.
        /// </summary>
        /// <param name="data">A list of integers.</param>
        /// <returns>The mean of the data set.</returns>
        private double CalculateMean(List<int> data)
        {
            double sum = data.Sum();
            return sum / data.Count;
        }

        /// <summary>
        /// Calculates the median of a list of integers.
        /// </summary>
        /// <param name="data">A list of integers.</param>
        /// <returns>The median of the data set.</returns>
        private double CalculateMedian(List<int> data)
        {
            int middle = data.Count / 2;
            if (data.Count % 2 == 0)
            {
                return (data[middle - 1] + data[middle]) / 2.0;
            }
            else
            {
                return data[middle];
            }
        }

        /// <summary>
        /// Finds the mode of a list of integers.
        /// </summary>
        /// <param name="data">A list of integers.</param>
        /// <returns>The mode of the data set.</returns>
        private int GetMode(List<int> data)
        {
            var frequency = data.GroupBy(x => x)
                                .ToDictionary(grp => grp.Key, grp => grp.Count());
            var max = frequency.MaxBy(d => d.Value);
            return max.Key;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataAnalyzer analyzer = new DataAnalyzer();
            try
            {
                List<int> data = new List<int> { 1, 2, 3, 4, 4, 4, 5 };
                string result = analyzer.AnalyzeData(data);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}