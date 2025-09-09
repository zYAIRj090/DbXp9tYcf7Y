// 代码生成时间: 2025-09-09 20:13:49
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// 表单数据验证器类
public class FormValidator
{
    private readonly List<ValidationResult> validationResults;

    // 构造函数，初始化验证结果列表
    public FormValidator()
    {
        validationResults = new List<ValidationResult>();
    }

    // 添加验证逻辑的方法
    public void AddValidationRule<T>(T value, ValidationData data, params ValidationAttribute[] validators) where T : class
    {
        Validator.ValidateObject(value, options: ValidationOptions.ContinueAfterFirstFailure);
        foreach (var validator in validators)
        {
            var context = new ValidationContext(value, serviceProvider: null, items: null)
            {
                MemberName = data.MemberName
            };
            if (!validator.IsValid(data.Value))
            {
                validationResults.Add(new ValidationResult(validator.FormatErrorMessage(data.DisplayName), new[] { data.MemberName }));
            }
        }
    }

    // 检查是否有验证错误的方法
    public bool HasErrors()
    {
        return validationResults.Count > 0;
    }

    // 获取验证错误信息的方法
    public List<string> GetErrors()
    {
        return validationResults.ConvertAll(result => result.ErrorMessage);
    }
}

// 验证数据类，用于传递验证所需的额外信息
public class ValidationData
{
    [Required]
    public string DisplayName { get; set; }

    [Required]
    public string MemberName { get; set; }

    public object Value { get; set; }
}

// 示例使用
public class Program
{
    public static void Main()
    {
        var validator = new FormValidator();
        var data = new ValidationData
        {
            DisplayName = "Username",
            MemberName = "Username",
            Value = ""
        };

        validator.AddValidationRule(data, data, new RequiredAttribute("Username is required."), new StringLengthAttribute(5) { MinimumLength = 3, MaximumLength = 20 });

        if (validator.HasErrors())
        {
            foreach (var error in validator.GetErrors())
            {
                Console.WriteLine(error);
            }
        }
        else
        {
            Console.WriteLine("No errors found.");
        }
    }
}