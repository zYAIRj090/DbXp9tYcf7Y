// 代码生成时间: 2025-10-06 16:46:51
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ReadWriteSeparation
{
    public class ReadWriteSeparationOptions
    {
        public string PrimaryConnectionString { get; set; }
        public string ReplicaConnectionString { get; set; }
    }

    public class ReadWriteSeparationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ReadWriteSeparationMiddleware> _logger;
        private readonly ReadWriteSeparationOptions _options;

        public ReadWriteSeparationMiddleware(RequestDelegate next,
            ILogger<ReadWriteSeparationMiddleware> logger,
            IOptions<ReadWriteSeparationOptions> options)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Determine if the operation is a read or write operation
            bool isReadOperation = IsReadOperation(context.Request.Method);
            string connectionString = isReadOperation ? _options.ReplicaConnectionString : _options.PrimaryConnectionString;

            try
            {
                // Use the appropriate connection string to handle the request
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while handling the request.");
                throw;
            }
        }

        // Helper method to determine if the HTTP method is a read operation
        private bool IsReadOperation(string httpMethod)
        {
            // This is a basic implementation and can be extended based on the specific requirements
            return httpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase) ||
                   httpMethod.Equals("HEAD", StringComparison.OrdinalIgnoreCase);
        }
    }

    public static class ReadWriteSeparationMiddlewareExtensions
    {
        public static IApplicationBuilder UseReadWriteSeparation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ReadWriteSeparationMiddleware>();
        }
    }
}
