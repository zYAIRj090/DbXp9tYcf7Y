// 代码生成时间: 2025-08-09 11:28:47
using System;
using System.Net;

namespace UrlValidatorApp
{
    /// <summary>
    /// Class responsible for validating the format and reachability of URLs.
    /// </summary>
    public class UrlValidator
    {
        /// <summary>
        /// Validates the URL format using regular expressions.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>True if the URL is in a correct format, otherwise false.</returns>
        private bool IsValidFormat(string url)
        {
            // Regular expression pattern for validating a URL
            string pattern = @"^(http|https):\/\/[^\s]+?\.[^\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(url, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Checks if the URL is reachable by trying to connect to it.
        /// </summary>
        /// <param name="url">The URL to check.</param>
        /// <returns>True if the URL is reachable, otherwise false.</returns>
        private bool IsReachable(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    // Set a timeout for the request to not hang indefinitely
                    client.Headers.Add("User-Agent", "UrlValidatorApp/1.0");
                    client.Timeout = 5000; // 5 seconds timeout
                    client.DownloadString(url);
                    return true;
                }
            }
            catch (WebException)
            {
                // If there's a WebException, it means the URL is not reachable
                return false;
            }
            catch (Exception ex)
            {
                // Log any other exceptions that may occur
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Public method to validate a URL. It checks both the format and reachability.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>True if the URL is valid, otherwise false.</returns>
        public bool ValidateUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                // If the URL is null or empty, it's not valid
                return false;
            }

            // Check if the URL has a valid format
            if (!IsValidFormat(url))
            {
                return false;
            }

            // Check if the URL is reachable
            return IsReachable(url);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UrlValidator validator = new UrlValidator();
            string testUrl = "https://www.example.com";
            bool isValid = validator.ValidateUrl(testUrl);
            Console.WriteLine($"Is the URL {testUrl} valid? {isValid}.");
        }
    }
}