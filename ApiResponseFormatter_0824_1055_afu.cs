// 代码生成时间: 2025-08-24 10:55:28
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

// ApiResponseFormatter is a utility class that formats API responses.
public class ApiResponseFormatter<T>
{
    // The status code of the response.
    public int StatusCode { get; set; }
    // The data payload of the response.
    public T Data { get; set; }
    // Any error messages associated with the response.
    public string ErrorMessage { get; set; }
    // Additional metadata that can be included with the response.
    public Dictionary<string, object> Meta { get; set; }

    // Constructor for ApiResponseFormatter.
    public ApiResponseFormatter(int statusCode, T data = default, string errorMessage = null, Dictionary<string, object> meta = null)
    {
        StatusCode = statusCode;
        Data = data;
        ErrorMessage = errorMessage;
        Meta = meta;
    }

    // Serializes the ApiResponseFormatter object to a JSON string.
    public string SerializeToJson()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, options);
        }
        catch (JsonException ex)
        {
            // Handle serialization errors and return a formatted error message.
            return $@"{{ "status": 500, "error": "Internal Server Error: {ex.Message}" }}";
        }
    }
}

// Example usage of ApiResponseFormatter.
public class Program
{
    public static void Main()
    {
        try
        {
            // Create a sample response with data.
            var response = new ApiResponseFormatter<Dictionary<string, string>>(200, new Dictionary<string, string> { { "key", "value" } });
            // Serialize the response to JSON and print it.
            Console.WriteLine(response.SerializeToJson());
        }
        catch (Exception ex)
        {
            // Handle any unhandled exceptions and print an error message.
            Console.WriteLine($@"{{ "status": 500, "error": "Internal Server Error: {ex.Message}" }}");
        }
    }
}