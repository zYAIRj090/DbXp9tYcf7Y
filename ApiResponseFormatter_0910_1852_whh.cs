// 代码生成时间: 2025-09-10 18:52:16
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiResponseFormatter
{
    /// <summary>
# 改进用户体验
    /// This class provides functionality to format API responses.
# 优化算法效率
    /// It includes error handling and is designed to be easily maintainable and extensible.
    /// </summary>
    public class ApiResponseFormatter
    {
        private readonly HttpClient _httpClient;

        public ApiResponseFormatter(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Formats the API response into a more readable JSON format.
        /// </summary>
        /// <param name="response">The HttpResponseMessage to be formatted.</param>
        /// <returns>A string representing the formatted JSON response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the response is null.</exception>
        public async Task<string> FormatResponseAsync(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            if (!response.IsSuccessStatusCode)
            {
                return "Error: " + response.StatusCode;
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();
# 改进用户体验
            JToken token = JObject.Parse(jsonResponse);

            return JsonConvert.SerializeObject(token, Formatting.Indented);
# 添加错误处理
        }
    }
}
