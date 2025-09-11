// 代码生成时间: 2025-09-11 22:43:22
using System;

namespace MathUtilities
{
    // The MathUtility class encapsulates mathematical operations.
    public static class MathUtility
    {
        // Adds two numbers.
        public static double Add(double a, double b)
        {
            return a + b;
        }

        // Subtracts the second number from the first.
        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        // Multiplies two numbers.
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        // Divides the first number by the second one, handling division by zero.
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }

        // Calculates the square of a number.
        public static double Square(double number)
        {
            return number * number;
        }

        // Calculates the square root of a number.
        public static double SquareRoot(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Cannot calculate the square root of a negative number.");
            }
            return Math.Sqrt(number);
        }
    }
}
