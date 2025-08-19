// 代码生成时间: 2025-08-20 06:20:40
using System;
using System.Net;
using System.Threading.Tasks;

namespace UrlValidator
{
    /// <summary>
    /// A class to validate the validity of a URL.
    /// </summary>
    public class UrlValidator
    {
        /// <summary>
        /// Checks if the provided URL is valid and reachable.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>A boolean indicating whether the URL is valid and reachable.</returns>
        public async Task<bool> IsUrlValidAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("URL cannot be null or empty.", nameof(url));
            }

            try
            {
                Uri uriResult;
                if (!Uri.TryCreate(url, UriKind.Absolute, out uriResult))
                    return false;

                // Ensure the scheme is HTTP or HTTPS
                if (!(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                    return false;

                using (var client = new WebClient())
                {
                    await client.OpenReadAsync(uriResult);
                    return true;
                }
            }
            catch (WebException)
            {
                // Handle web exceptions (e.g., 404, 500, DNS failure)
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception and return false if an unexpected error occurs
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return false;
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var validator = new UrlValidator();
            string testUrl = "https://www.example.com";
            bool isValid = await validator.IsUrlValidAsync(testUrl);
            Console.WriteLine($"Is '{testUrl}' valid? {isValid}");
        }
    }
}