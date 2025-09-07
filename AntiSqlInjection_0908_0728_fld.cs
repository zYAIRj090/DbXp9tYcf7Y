// 代码生成时间: 2025-09-08 07:28:36
using System;
using System.Data;
using System.Data.SqlClient;

namespace AntiInjectionDemo
{
    public class AntiSqlInjection
    {
        // Connection string to the database
        private readonly string _connectionString;

        public AntiSqlInjection(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to prevent SQL injection by using parameterized queries
        public void InsertUser(string username, string email)
        {
            try
            {
                // Use parameterized query to prevent SQL injection
                string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email);";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Main method for demonstration
        public static void Main(string[] args)
        {
            string connectionString = "Data Source=your_server;Initial Catalog=your_db;Integrated Security=True";
            AntiSqlInjection antiInjection = new AntiSqlInjection(connectionString);

            try
            {
                antiInjection.InsertUser("user1", "user1@example.com");
                Console.WriteLine("User inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}