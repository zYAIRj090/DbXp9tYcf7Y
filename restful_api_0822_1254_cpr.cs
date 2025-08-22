// 代码生成时间: 2025-08-22 12:54:40
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;

// 定义API路由和控制器
namespace RestfulApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // 添加MVC服务，并设置路由符合RESTful风格
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 启用跨域资源共享
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                // 定义API端点
                endpoints.MapControllers();
            });
        }
    }

    [ApiController]
    [Route("[controller]/[action]")]
    public class SampleController : ControllerBase
    {
        // GET请求示例
        [HttpGet]
        public IActionResult GetExample()
        {
            try
            {
                // 模拟业务逻辑
                var data = "This is a sample data";
                return Ok(data);
            }
            catch (Exception ex)
            {
                // 错误处理
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST请求示例
        [HttpPost]
        public async Task<IActionResult> PostExample([FromBody] string data)
        {
            try
            {
                // 模拟业务逻辑
                var result = await Task.FromResult($"My data is: {data}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                // 错误处理
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
