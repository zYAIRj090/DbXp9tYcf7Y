// 代码生成时间: 2025-08-11 13:09:48
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace DatabaseConnectionPoolManager
{
    /// <summary>
    /// DatabaseConnectionPoolManager class is responsible for managing a pool of database connections.
    /// </summary>
    public class DatabaseConnectionPoolManager
    {
        private readonly ConcurrentBag<DbConnection> _connectionPool;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the DatabaseConnectionPoolManager class.
        /// </summary>
        /// <param name="configuration">The configuration object to retrieve connection string.</param>
        public DatabaseConnectionPoolManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
            _connectionPool = new ConcurrentBag<DbConnection>();
        }

        /// <summary>
        /// Opens a new connection from the pool or creates a new one if none are available.
        /// </summary>
        /// <returns>A DbConnection object representing the connection to the database.</returns>
        public DbConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string is not set.");
            }

            if (!_connectionPool.TryTake(out var connection))
            {
                // Create a new connection
                connection = CreateConnection();
            }
            else
            {
                try
                {
                    // Check if the connection is still alive and open
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception and discard the broken connection
                    Console.WriteLine($"Error checking connection: {ex.Message}");
                    connection.Dispose();
                    connection = CreateConnection();
                }
            }

            return connection;
        }

        /// <summary>
        /// Returns a connection to the pool and marks it as available.
        /// </summary>
        /// <param name="connection">The connection to return to the pool.</param>
        public void ReturnConnection(DbConnection connection)
        {
            if (connection != null)
            {
                // Close the connection before putting it back in the pool
                connection.Close();
                _connectionPool.Add(connection);
            }
        }

        /// <summary>
        /// Creates a new database connection.
        /// </summary>
        /// <returns>A new DbConnection object.</returns>
        private DbConnection CreateConnection()
        {
            // Assuming the use of SQL Server, but this can be expanded to support other databases
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var connection = factory.CreateConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();
            return connection;
        }
    }
}
