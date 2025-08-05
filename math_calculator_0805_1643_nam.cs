// 代码生成时间: 2025-08-05 16:43:48
 * comments, and best practices for maintainability and extensibility.
 */

using System;

namespace MathTools
{
    // Math calculator class
    public class MathCalculator
    {
        // Adds two numbers
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Subtracts the second number from the first
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        // Multiplies two numbers
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        // Divides the first number by the second number
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("You cannot divide by zero.");
            }
            return a / b;
        }

        // Calculates the power of a number
        public double Power(double a, double b)
        {
            return Math.Pow(a, b);
        }

        // Calculates the square root of a number
        public double Sqrt(double a)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), "Cannot take the square root of a negative number.");
            }
            return Math.Sqrt(a);
        }
    }

    // Program class to demonstrate usage of the MathCalculator
    class Program
    {
        static void Main(string[] args)
        {
            MathCalculator calculator = new MathCalculator();

            try
            {
                double result = calculator.Add(10, 5);
                Console.WriteLine($"10 + 5 = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                double result = calculator.Divide(10, 0);
                Console.WriteLine($"10 / 0 = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}