// 代码生成时间: 2025-10-09 01:54:24
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Http2ProtocolHandler
{
    // Define a class to handle HTTP/2 requests
    public class Http2ProtocolHandler
    {
        private readonly string _host;
        private readonly int _port;

        public Http2ProtocolHandler(string host, int port)
        {
            _host = host;
            _port = port;
        }

        // Start the HTTP/2 server
        public async Task StartServerAsync()
        {
            try
            {
                // Configure Kestrel to use the HTTP/2 protocol
                var server = new KestrelServerOptions
                {
                    AddServerHeader = false,
                    ApplicationServices = new ServiceCollection().BuildServiceProvider(),
                    Limits = new KestrelServerLimits { MaxRequestBodySize = null }
                };

                server.Listen(_host, _port, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http2; // Set the protocol to HTTP/2
                });

                // Start the Kestrel server
                await server.StartAsync();

                Console.WriteLine($"HTTP/2 server started at http://{_host}:{_port}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while starting the HTTP/2 server: {ex.Message}");
            }
        }

        // Stop the HTTP/2 server
        public async Task StopServerAsync()
        {
            try
            {
                // Stop the Kestrel server
                await server.StopAsync();
                Console.WriteLine($"HTTP/2 server stopped at http://{_host}:{_port}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while stopping the HTTP/2 server: {ex.Message}");
            }
        }
    }

    // Example usage
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = "localhost";
            var port = 5000;
            var http2Handler = new Http2ProtocolHandler(host, port);

            try
            {
                await http2Handler.StartServerAsync();
                Console.WriteLine("Press Enter to stop the server...");
                Console.ReadLine();
                await http2Handler.StopServerAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
