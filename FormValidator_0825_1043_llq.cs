// 代码生成时间: 2025-08-25 10:43:55
// FormValidator.cs
// This class is responsible for validating form data.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationSample
{
    // Form data model
    public class FormData
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
    }

    // Form data validator
    public class FormValidator
    {
        public List<string> ValidateFormData(FormData formData)
        {
            List<string> errorMessages = new List<string>();
            Validator.ValidateObject(formData, new ValidationContext(formData), true);

            // Check for any validation errors
            if (Validator.TryValidateObject(formData, new ValidationContext(formData), new List<ValidationResult>(), out IList<ValidationResult> results))
            {
                // If there are no errors, return an empty list.
                return errorMessages;
            }
            else
            {
                // If errors exist, add error messages to the list.
                foreach (var validationResult in results)
                {
                    errorMessages.Add(validationResult.ErrorMessage);
                }
                return errorMessages;
            }
        }
    }
}
