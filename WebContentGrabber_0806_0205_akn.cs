// 代码生成时间: 2025-08-06 02:05:44
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebContentGrabberApp
{
    /// <summary>
    /// A class for grabbing web content.
    /// </summary>
    public class WebContentGrabber
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebContentGrabber"/> class.
        /// </summary>
        public WebContentGrabber()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Asynchronously grabs the content of a webpage.
        /// </summary>
        /// <param name="url">The URL of the webpage to fetch.</param>
        /// <returns>The content of the webpage as a string.</returns>
        public async Task<string> FetchWebContentAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL cannot be null or whitespace.", nameof(url));
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (HttpRequestException e)
            {
                // Handle HttpRequestException, e.g., log the error or notify the user.
                Console.WriteLine("Error fetching content from the web: " + e.Message);
                return null;
            }
            catch (Exception e)
            {
                // Handle any other exceptions.
                Console.WriteLine("An unexpected error occurred: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Asynchronously grabs the content of a webpage and extracts the title tag.
        /// </summary>
        /// <param name="url">The URL of the webpage to fetch.</param>
        /// <returns>The title of the webpage or null if not found.</returns>
        public async Task<string> FetchWebPageTitleAsync(string url)
        {
            string content = await FetchWebContentAsync(url);
            if (content == null) return null;

            // Use regular expression to find the title tag.
            Regex regex = new Regex("<title>(.*?)</title>", RegexOptions.IgnoreCase);
            Match match = regex.Match(content);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return null;
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            WebContentGrabber grabber = new WebContentGrabber();
            string url = "http://example.com";
            string title = await grabber.FetchWebPageTitleAsync(url);

            if (title != null)
            {
                Console.WriteLine("Title of the webpage: " + title);
            }
            else
            {
                Console.WriteLine("Failed to fetch the title of the webpage.");
            }
        }
    }
}