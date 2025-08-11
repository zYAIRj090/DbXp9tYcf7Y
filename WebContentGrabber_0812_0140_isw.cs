// 代码生成时间: 2025-08-12 01:40:16
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

// WebContentGrabber class responsible for fetching web content.
public class WebContentGrabber
{
    private readonly HttpClient _httpClient;

    // Constructor initializing the HttpClient.
    public WebContentGrabber()
    {
        _httpClient = new HttpClient();
    }

    // Asynchronously fetches the content of the webpage.
    public async Task<string> FetchWebpageContentAsync(string url)
    {
        try
        {
            // Send a GET request to the specified URL.
            HttpResponseMessage response = await _httpClient.GetAsync(url);

            // Ensure the response is successful.
            response.EnsureSuccessStatusCode();

            // Read the response content as a string.
            string content = await response.Content.ReadAsStringAsync();

            // Return the content of the webpage.
            return content;
        }
        catch (HttpRequestException e)
        {
            // Handle any exceptions that occur during the request.
            Console.WriteLine($"Error fetching webpage: {e.Message}");
            throw;
        }
    }

    // Method to extract text content from HTML using regular expressions.
    public string ExtractTextContent(string htmlContent)
    {
        // Regular expression to remove HTML tags.
        string pattern = "<[^>]*>|
|\r";
        Regex regex = new Regex(pattern);

        // Replace the HTML tags with empty string.
        string textContent = regex.Replace(htmlContent, "");

        // Return the text content.
        return textContent;
    }
}
