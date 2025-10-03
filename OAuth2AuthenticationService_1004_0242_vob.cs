// 代码生成时间: 2025-10-04 02:42:22
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace YourNamespace
{
    // OAuth2认证服务
    public class OAuth2AuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<OAuth2AuthenticationService> _logger;

        public OAuth2AuthenticationService(IConfiguration configuration, ILogger<OAuth2AuthenticationService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        // 生成访问令牌
        public async Task<string> GenerateAccessTokenAsync(string username, string password)
        {
            // 验证用户名和密码
            if (!await ValidateUserAsync(username, password))
            {
                _logger.LogError("Invalid username or password.");
                throw new Exception("Invalid username or password.");
            }

            // 创建令牌生成器
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                })
                , Expires = DateTime.UtcNow.AddHours(1)
                , SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // 生成令牌
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        // 验证用户名和密码
        private async Task<bool> ValidateUserAsync(string username, string password)
        {
            // 实现用户名和密码验证逻辑，例如查询数据库
            // 这里仅作示例，返回true表示验证通过
            return true;
        }
    }

    // 扩展类，添加OAuth2服务
    public static class OAuth2ServiceExtensions
    {
        public static IServiceCollection AddOAuth2Services(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddLogging();
            services.AddTransient<OAuth2AuthenticationService>();

            return services;
        }
    }
}
