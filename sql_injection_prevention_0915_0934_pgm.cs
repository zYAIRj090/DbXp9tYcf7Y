// 代码生成时间: 2025-09-15 09:34:32
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SqlInjectionPrevention
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 使用参数化查询防止SQL注入
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                // 创建数据库连接
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // 创建SqlCommand对象
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return dataTable;
        }

        // 添加参数化查询的示例
        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            int rowsAffected = 0;
            try
            {
                // 创建数据库连接
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // 创建SqlCommand对象
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return rowsAffected;
        }
    }

    public class Program
    {
        public static void Main()
        {
            string connectionString = "YourConnectionStringHere";
            DatabaseHelper dbHelper = new DatabaseHelper(connectionString);

            // 示例：使用参数化查询防止SQL注入
            string query = "SELECT * FROM Users WHERE Username = @Username";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", "exampleUser")
            };

            var dataTable = dbHelper.ExecuteQuery(query, parameters);

            // 处理查询结果
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"Username: {row["Username"]}, Email: {row["Email"]}");
            }

            // 示例：使用参数化更新防止SQL注入
            string updateQuery = "UPDATE Users SET Email = @Email WHERE Username = @Username";
            SqlParameter[] updateParameters = new SqlParameter[]
            {
                new SqlParameter("@Email", "newEmail@example.com"),
                new SqlParameter("@Username", "exampleUser")
            };

            int rowsAffected = dbHelper.ExecuteNonQuery(updateQuery, updateParameters);
            Console.WriteLine($"Rows affected: {rowsAffected}");
        }
    }
}
