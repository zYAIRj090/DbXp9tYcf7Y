// 代码生成时间: 2025-08-28 00:55:43
using System;

namespace MathToolbox
{
    public static class MathToolbox
# 添加错误处理
    {
        // 加法运算
# 增强安全性
        public static double Add(double a, double b)
        {
            return a + b;
        }

        // 减法运算
        public static double Subtract(double a, double b)
# FIXME: 处理边界情况
        {
            return a - b;
        }

        // 乘法运算
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        // 除法运算
        public static double Divide(double a, double b)
        {
            // 错误处理：除数不能为零
            if (b == 0)
            {
# 扩展功能模块
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }
# 优化算法效率

        // 平方运算
        public static double Square(double number)
# 增强安全性
        {
            return number * number;
        }

        // 平方根运算
        public static double SquareRoot(double number)
        {
            // 错误处理：负数没有实数平方根
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "Cannot calculate square root of negative number.");
            }
            return Math.Sqrt(number);
        }

        // 立方运算
        public static double Cube(double number)
        {
            return number * number * number;
# NOTE: 重要实现细节
        }

        // 计算最大公约数
# NOTE: 重要实现细节
        public static int Gcd(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            while (b != 0)
            {
# 增强安全性
                int temp = b;
                b = a % b;
                a = temp;
            }
# 扩展功能模块
            return a;
        }
    }
}
