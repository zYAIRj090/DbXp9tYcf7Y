// 代码生成时间: 2025-08-24 00:41:56
using System;
using System.Security.Claims;
using System.Threading.Tasks;

// 代表用户身份认证的服务
public class UserAuthenticationService
{
    // 用于存储用户信息的简单数据结构
    private readonly (string username, string password)[] users = new[] {
        ("admin", "admin123"),
        ("user", "password")
    };

    // 用户登录方法
    public async Task<bool> LoginAsync(string username, string password)
    {
        try
        {
            // 检查用户名和密码是否匹配
            var user = users.FirstOrDefault(u => u.username == username && u.password == password);
            if (user.username == null)
            {
                // 未找到用户或密码错误
                Console.WriteLine("Invalid username or password.");
                return false;
            }

            // 用户验证成功，创建ClaimsPrincipal表示用户身份
            var claims = new[] {
                new Claim(ClaimTypes.Name, username),
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/role", "User")
            };
            var claimsIdentity = new ClaimsIdentity(claims, "UserAuthentication