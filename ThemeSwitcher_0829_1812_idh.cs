// 代码生成时间: 2025-08-29 18:12:24
using System;
using System.Collections.Generic;

// 主题切换功能的实现
namespace ThemeSwitcherApp
{
    // 主题类，用于存储主题相关属性
    public class Theme
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }
    }

    // 主题切换器类，实现主题切换功能
    public class ThemeSwitcher
    {
        private List<Theme> availableThemes;
        private Theme currentTheme;

        // 构造函数，初始化可用主题
        public ThemeSwitcher()
        {
            availableThemes = new List<Theme>
            {
                new Theme { Name = "Light", BackgroundColor = "#FFFFFF", TextColor = "#000000" },
                new Theme { Name = "Dark", BackgroundColor = "#000000", TextColor = "#FFFFFF" }
            };
        }

        // 设置当前主题
        public void SetTheme(string themeName)
        {
            // 检查主题是否存在
            if (!IsThemeAvailable(themeName))
            {
                throw new ArgumentException("Theme not found.");
            }

            // 找到并设置当前主题
            currentTheme = availableThemes.Find(theme => theme.Name == themeName);
            Console.WriteLine($"Theme switched to: {currentTheme.Name} with background color: {currentTheme.BackgroundColor} and text color: {currentTheme.TextColor}");
        }

        // 检查主题是否可用
        private bool IsThemeAvailable(string themeName)
        {
            return availableThemes.Exists(theme => theme.Name == themeName);
        }

        // 获取当前主题名称
        public string GetCurrentThemeName()
        {
            return currentTheme.Name;
        }
    }

    // 程序主入口
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ThemeSwitcher themeSwitcher = new ThemeSwitcher();
                themeSwitcher.SetTheme("Light");
                themeSwitcher.SetTheme("Dark");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}