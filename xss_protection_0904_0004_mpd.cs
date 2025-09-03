// 代码生成时间: 2025-09-04 00:04:56
using System;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Provides functionality to protect against XSS (Cross-Site Scripting) attacks.
/// </summary>
public static class XssProtection
{
    /// <summary>
    /// Sanitizes input to prevent XSS attacks.
    /// </summary>
    /// <param name="input">The string to be sanitized.</param>
    /// <returns>The sanitized string.</returns>
    public static string SanitizeInput(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            // Return an empty string if the input is null or empty
            return string.Empty;
        }

        // Use HttpUtility.HtmlEncode to encode HTML characters to prevent rendering of script tags
        input = HttpUtility.HtmlEncode(input);

        // Use regular expressions to find and sanitize script tags
        input = Regex.Replace(input, "<script.*?>.*?</script>","", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        // Additional sanitization can be added here if needed

        return input;
    }

    /// <summary>
    /// Main method for demonstration purposes.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args)
    {
        try
        {
            string userInput = "<script>alert('XSS')</script>";
            string sanitizedInput = SanitizeInput(userInput);

            Console.WriteLine("Original Input: " + userInput);
            Console.WriteLine("Sanitized Input: " + sanitizedInput);
        }
        catch (Exception ex)
        {
            // Handle any exceptions that may occur
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}