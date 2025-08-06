// 代码生成时间: 2025-08-06 19:25:37
using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Threading;

/// <summary>
/// A simple database connection pool manager implemented in C#.
/// </summary>
public class DatabaseConnectionPoolManager
{
    private readonly ConcurrentBag<DbConnection> pool;
    private readonly int maxConnections;
    private readonly int minConnections;
    private readonly string connectionString;
    private readonly int connectionTimeout;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseConnectionPoolManager"/> class.
    /// </summary>
    /// <param name="connectionString">The database connection string.</param>
    /// <param name="maxConnections">The maximum number of connections to maintain in the pool.</param>
    /// <param name="minConnections">The minimum number of connections to maintain in the pool.</param>
    /// <param name="connectionTimeout">The timeout for creating a new connection.</param>
    public DatabaseConnectionPoolManager(string connectionString, int maxConnections, int minConnections, int connectionTimeout)
    {
        this.connectionString = connectionString;
        this.maxConnections = maxConnections;
        this.minConnections = minConnections;
        this.connectionTimeout = connectionTimeout;
        this.pool = new ConcurrentBag<DbConnection>();
        // Initialize the pool with minimum connections.
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < minConnections; i++)
        {
            try
            {
                var connection = CreateConnection();
                pool.Add(connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing connection pool: {ex.Message}");
            }
        }
    }

    private DbConnection CreateConnection()
    {
        var factory = DbProviderFactories.GetFactory();
        var connection = factory.CreateConnection();
        connection.ConnectionString = connectionString;
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }
        return connection;
    }

    /// <summary>
    /// Retrieves a connection from the pool or creates a new one if necessary.
    /// </summary>
    /// <returns>A database connection.</returns>
    public DbConnection GetConnection()
    {
        DbConnection connection;
        if (pool.TryTake(out connection))
        {
            // Connection was retrieved from the pool.
            return connection;
        }
        else
        {
            // Pool is empty, create a new connection.
            return CreateConnection();
        }
    }

    /// <summary>
    /// Returns a connection to the pool.
    /// </summary>
    /// <param name="connection">The connection to return to the pool.</param>
    public void ReturnConnection(DbConnection connection)
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            pool.Add(connection);
        }
        else if (connection != null)
        {
            // The connection is closed or disposed, so we create a new one.
            var newConnection = CreateConnection();
            pool.Add(newConnection);
        }
    }

    /// <summary>
    /// Closes all connections in the pool and empties the pool.
    /// </summary>
    public void ClosePool()
    {
        foreach (var connection in pool)
        {
            connection.Close();
        }
        pool.Clear();
    }
}
