// 代码生成时间: 2025-09-06 07:56:22
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
# TODO: 优化性能

namespace DataValidation
{
    /// <summary>
    /// Represents a validator for form data.
    /// </summary>
    public class FormValidator
# FIXME: 处理边界情况
    {
        /// <summary>
        /// Validates a form object using Data Annotations.
        /// </summary>
        /// <typeparam name="T">The type of the form object.</typeparam>
        /// <param name="form">The form object to validate.</param>
        /// <returns>A list of validation errors.</returns>
        public List<string> ValidateForm<T>(T form) where T : class
        {
            // Create a validation context
            var validationContext = new ValidationContext(form);
            var validationResults = new List<ValidationResult>();
# FIXME: 处理边界情况

            // Check if validation is successful
            bool isValid = Validator.TryValidateObject(form, validationContext, validationResults, true);

            // If not valid, retrieve the error messages
            if (!isValid)
            {
                return validationResults.Select(result => result.ErrorMessage).ToList();
            }

            // If valid, return an empty list indicating no errors
            return new List<string>();
        }
    }

    // Example form class with validation attributes
    public class UserRegistrationForm
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 100 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }
    }
}
