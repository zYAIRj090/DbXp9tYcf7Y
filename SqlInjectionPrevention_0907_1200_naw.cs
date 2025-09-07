// 代码生成时间: 2025-09-07 12:00:13
using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlInjectionPrevention
{
    public class DatabaseAccess
    {
        private string connectionString = "Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True";

        // 使用参数化查询防止SQL注入
        public int InsertUser(string username, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email);";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Email", email);

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                return -1;
            }
        }

        // 使用参数化查询读取数据
        public DataTable GetUserByEmail(string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "SELECT * FROM Users WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            return table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred: " + ex.Message);
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();

            // 插入用户示例
            int result = dbAccess.InsertUser("john_doe", "john@example.com");
            if (result > 0)
                Console.WriteLine("User inserted successfully!");
            else
                Console.WriteLine("User insertion failed.");

            // 通过电子邮件获取用户示例
            DataTable user = dbAccess.GetUserByEmail("john@example.com");
            if (user != null)
            {
                foreach (DataRow row in user.Rows)
                {
                    Console.WriteLine($"Username: {row[0]}, Email: {row[1]}");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}
