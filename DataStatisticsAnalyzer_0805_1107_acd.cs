// 代码生成时间: 2025-08-05 11:07:58
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalysisApp
{
    /// <summary>
    /// A class used to analyze and provide statistics of a given data set.
    /// </summary>
    public class DataStatisticsAnalyzer
    {
        private List<double> _dataSet;

        /// <summary>
        /// Initializes a new instance of the DataStatisticsAnalyzer class.
        /// </summary>
        /// <param name="dataSet">The data set to be analyzed.</param>
        public DataStatisticsAnalyzer(List<double> dataSet)
        {
            if (dataSet == null)
                throw new ArgumentNullException(nameof(dataSet));

            _dataSet = dataSet;
        }

        /// <summary>
        /// Calculates the mean of the data set.
        /// </summary>
        /// <returns>The mean of the data set.</returns>
        public double CalculateMean()
        {
            if (!_dataSet.Any())
                throw new InvalidOperationException("The data set is empty.");

            return _dataSet.Average();
        }

        /// <summary>
        /// Calculates the median of the data set.
        /// </summary>
        /// <returns>The median of the data set.</returns>
        public double CalculateMedian()
        {
            if (!_dataSet.Any())
                throw new InvalidOperationException("The data set is empty.");

            var orderedSet = _dataSet.OrderBy(d => d).ToList();
            int middle = orderedSet.Count / 2;
            return (orderedSet.Count % 2 == 0) ? 
                (orderedSet[middle - 1] + orderedSet[middle]) / 2 : 
                orderedSet[middle];
        }

        /// <summary>
        /// Calculates the standard deviation of the data set.
        /// </summary>
        /// <returns>The standard deviation of the data set.</returns>
        public double CalculateStandardDeviation()
        {
            if (!_dataSet.Any())
                throw new InvalidOperationException("The data set is empty.");

            double mean = CalculateMean();
            double variance = _dataSet.Average(d => Math.Pow(d - mean, 2));
            return Math.Sqrt(variance);
        }

        /// <summary>
        /// Calculates the variance of the data set.
        /// </summary>
        /// <returns>The variance of the data set.</returns>
        public double CalculateVariance()
        {
            if (!_dataSet.Any())
                throw new InvalidOperationException("The data set is empty.");

            double mean = CalculateMean();
            return _dataSet.Average(d => Math.Pow(d - mean, 2));
        }

        /// <summary>
        /// Calculates the minimum value of the data set.
        /// </summary>
        /// <returns>The minimum value of the data set.</returns>
        public double CalculateMinimum()
        {
            return _dataSet.Min();
        }

        /// <summary>
        /// Calculates the maximum value of the data set.
        /// </summary>
        /// <returns>The maximum value of the data set.</returns>
        public double CalculateMaximum()
        {
            return _dataSet.Max();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<double> dataSet = new List<double> { 1.5, 2.3, 3.7, 4.1, 5.9 };
                DataStatisticsAnalyzer analyzer = new DataStatisticsAnalyzer(dataSet);

                Console.WriteLine("Mean: " + analyzer.CalculateMean());
                Console.WriteLine("Median: " + analyzer.CalculateMedian());
                Console.WriteLine("Standard Deviation: " + analyzer.CalculateStandardDeviation());
                Console.WriteLine("Variance: " + analyzer.CalculateVariance());
                Console.WriteLine("Minimum: " + analyzer.CalculateMinimum());
                Console.WriteLine("Maximum: " + analyzer.CalculateMaximum());
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
