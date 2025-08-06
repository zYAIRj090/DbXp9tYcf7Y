// 代码生成时间: 2025-08-06 10:18:05
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FormDataValidation
{
    public class FormDataValidator
    {
        // 验证表单数据
        public bool ValidateForm(object formObject)
        {
            List<string> validationResults = new List<string>();
            var validationContext = new ValidationContext(formObject, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            // 如果验证失败，存储错误信息
            if (!Validator.TryValidateObject(formObject, validationContext, results, true))
            {
                foreach (var validationResult in results)
                {
                    validationResults.Add(validationResult.ErrorMessage);
                }
                return false;
            }

            // 验证通过
            return true;
        }
    }

    // 表单数据模型
    public class FormModel
    {
        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "姓名长度必须在2到100之间")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "电子邮件格式不正确")]
        public string Email { get; set; }

        // 可以根据需要添加更多字段和验证规则
    }
}
