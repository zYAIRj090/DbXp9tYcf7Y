// 代码生成时间: 2025-08-09 03:30:47
using System;
using System.Security.Cryptography;
using System.Text;

// 这是一个简单的用户身份认证程序。
namespace UserAuthentication
{
    // 用户类，包含用户名和密码。
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // 用户身份认证服务。
    public class AuthenticationService
    {
        public bool Authenticate(User user, string storedUsername, string storedPasswordHash)
        {
            // 检查用户名是否匹配。
            if (user.Username != storedUsername)
            {
                return false;
            }

            // 将用户密码进行哈希处理。
            string hashedPassword = HashPassword(user.Password);
            // 比较存储的哈希密码和计算出的哈希密码是否相同。
            if (hashedPassword == storedPasswordHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 使用SHA256算法对密码进行哈希处理。
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // 计算密码的哈希值。
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                // 将哈希值转换为十六进制字符串。
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    // 程序入口点。
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User { Username = "john", Password = "password123" };
            string storedUsername = "john";
            string storedPasswordHash = "9e107d9d372bb6826bd81d3542a419d6"; // 存储的哈希密码。

            AuthenticationService authService = new AuthenticationService();
            bool isAuthenticated = authService.Authenticate(user, storedUsername, storedPasswordHash);

            if (isAuthenticated)
            {
                Console.WriteLine("Authentication successful.");
            }
            else
            {
                Console.WriteLine("Authentication failed.");
            }
        }
    }
}