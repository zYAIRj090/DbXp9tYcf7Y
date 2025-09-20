// 代码生成时间: 2025-09-20 13:31:11
 * The code structure is clear, easy to understand, and ensures maintainability and extensibility.
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlInjectionPrevention
{
    public class DatabaseAccess
    {
        private readonly string _connectionString;

        public DatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves data from the database using a parameterized query to prevent SQL injection.
        /// </summary>
        /// <param name="query">The SQL query to be executed.</param>
        /// <param name="parameters">The parameters for the query.</param>
        /// <returns>DataTable containing the query results.</returns>
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable result = new DataTable();
                    adapter.Fill(result);
                    return result;
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine($"An error occurred with the database: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Example method to demonstrate how to use the ExecuteQuery method with parameterized queries.
        /// </summary>
        public void DemonstrateParameterizedQuery()
        {
            string query = "SELECT * FROM Users WHERE Username = @Username";
            SqlParameter usernameParameter = new SqlParameter("@Username", SqlDbType.VarChar, 50);
            usernameParameter.Value = "exampleUser";

            SqlParameter[] parameters = new SqlParameter[] { usernameParameter };

            DataTable result = ExecuteQuery(query, parameters);

            // Process the result
            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine($"Username: {row[0]}
Email: {row[1]}
");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "your_connection_string_here";
            DatabaseAccess dbAccess = new DatabaseAccess(connectionString);
            dbAccess.DemonstrateParameterizedQuery();
        }
    }
}