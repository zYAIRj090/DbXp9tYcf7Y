// 代码生成时间: 2025-09-16 13:10:52
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiResponder
{
    /// <summary>
    /// Provides functionality to format API responses.
    /// </summary>
    public class ApiResponseFormatter
    {
        private readonly JsonSerializerOptions _options;

        /// <summary>
        /// Initializes a new instance of ApiResponseFormatter with default serialization settings.
        /// </summary>
        public ApiResponseFormatter()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };
        }

        /// <summary>
        /// Formats the given data into a JSON string with a success status.
        /// </summary>
        /// <param name="data">The data to be formatted.</param>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <returns>A formatted JSON string representing the API response.</returns>
        public string FormatSuccessResponse<T>(T data)
        {
            return FormatResponse(data, true);
        }

        /// <summary>
        /// Formats the given data into a JSON string with an error status.
        /// </summary>
        /// <param name="data">The data to be formatted.</param>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <returns>A formatted JSON string representing the API response.</returns>
        public string FormatErrorResponse<T>(T data)
        {
            return FormatResponse(data, false);
        }

        private string FormatResponse<T>(T data, bool isSuccess)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            string json = JsonSerializer.Serialize(new
            {
                IsSuccess = isSuccess,
                Data = data
            }, _options);

            return json;
        }
    }
}
