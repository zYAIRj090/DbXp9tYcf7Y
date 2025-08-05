// 代码生成时间: 2025-08-05 21:38:16
using System;

namespace ThemeSwitcherApp
{
    public class ThemeSwitcher
    {
        private string currentTheme;

        // Constructor to set the initial theme
        public ThemeSwitcher(string initialTheme)
        {
            currentTheme = initialTheme;
        }

        // Method to switch the theme
        public void SwitchTheme(string newTheme)
        {
            // Check if the new theme is valid
            if (string.IsNullOrEmpty(newTheme))
            {
                throw new ArgumentException("Theme cannot be null or empty.");
            }

            // Perform the theme switch
            currentTheme = newTheme;
            Console.WriteLine($"Theme switched to: {currentTheme}");
        }

        // Method to get the current theme
        public string GetCurrentTheme()
        {
            return currentTheme;
        }

        // Main method to demonstrate theme switching
        public static void Main(string[] args)
        {
            try
            {
                // Initialize the theme switcher with a default theme
                ThemeSwitcher switcher = new ThemeSwitcher("Light");

                // Display the current theme
                Console.WriteLine($"Current theme: {switcher.GetCurrentTheme()}");

                // Switch to a new theme
                switcher.SwitchTheme("Dark");

                // Attempt to switch to an invalid theme to demonstrate error handling
                switcher.SwitchTheme("");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}