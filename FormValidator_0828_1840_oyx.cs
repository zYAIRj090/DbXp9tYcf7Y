// 代码生成时间: 2025-08-28 18:40:41
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataValidation
{
    // 表单数据验证器类
    public class FormValidator
    {
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        // 添加错误信息
        private void AddError(string key, string message)
        {
            _errors[key] = message;
        }

        // 清空错误信息
        private void ClearErrors()
        {
            _errors.Clear();
        }

        // 检查对象是否有效
        public bool IsValid(object obj)
        {
            ClearErrors();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj, serviceProvider: null, items: null)
            {
                DisplayName = obj.GetType().Name
            };

            // 使用DataAnnotations验证对象
            bool isValid = Validator.TryValidateObject(obj, context, results, true);

            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    AddError(validationResult.MemberNames[0], validationResult.ErrorMessage);
                }
            }

            return isValid;
        }

        // 获取错误信息
        public Dictionary<string, string> GetErrors()
        {
            return _errors;
        }
    }
}

// 示例Usage类，带有DataAnnotations验证属性
namespace DataValidation
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [StringLength(100, ErrorMessage = "用户名长度不能超过100个字符")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "密码不能为空")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "密码长度必须在6到100个字符之间")]
        public string Password { get; set; }
    }
}

// 示例使用FormValidator的代码
/*
FormValidator validator = new FormValidator();
User user = new User
{
    UserName = "",
    Password = "password123"
};

bool isValid = validator.IsValid(user);
if (!isValid)
{
    foreach (var error in validator.GetErrors())
    {
        Console.WriteLine($"{error.Key}: {error.Value}");
    }
}
else
{
    Console.WriteLine("用户信息验证通过");
}
*/