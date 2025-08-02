// 代码生成时间: 2025-08-03 04:50:28
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UrlValidatorApp
{
    /// <summary>
    /// A utility class to validate the validity of a URL.
    /// </summary>
    public class UrlValidator
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlValidator"/> class.
        /// </summary>
        public UrlValidator()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Asynchronously checks if the provided URL is valid by attempting to send a HEAD request.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>A Task that represents the asynchronous operation.
        /// The result is true if the URL is valid; otherwise, false.</returns>
        public async Task<bool> IsValidUrlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL cannot be null or whitespace.", nameof(url));
            }

            try
            {
                // Send a HEAD request to the URL to validate it without downloading the content.
                var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                // Log the exception details.
                Console.WriteLine($"An error occurred while validating the URL: {e.Message}");
                return false;
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var urlValidator = new UrlValidator();
            string testUrl = "https://www.example.com";

            bool isValid = await urlValidator.IsValidUrlAsync(testUrl);
            Console.WriteLine($"Is '{testUrl}' a valid URL? {isValid}.");
        }
    }
}