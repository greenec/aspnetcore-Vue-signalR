using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Vue2SpaSignalR.Models
{
    public class WorkItem
    {
        public int ID { get; set; }

        [Display(Name = "Assigned Employee")]
        public int UserID { get; set; }

        [Display(Name = "Task Name"), Required, Palindrome] // Remote(action: "ValidateTaskName", controller: "WorkItems")]
        public string TaskName { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class Palindrome : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as WorkItem;

            if (model == null)
            {
                throw new ArgumentException($"Attribute not applied on a {validationContext.DisplayName}");
            }

            var taskName = model.TaskName.ToLower();

            Regex rgx = new Regex("[^a-z0-9]");
            taskName = rgx.Replace(taskName, string.Empty);

            string reversed = new string(taskName.ToCharArray().Reverse().ToArray());

            if (taskName != reversed)
            {
                return new ValidationResult(GetErrorMessage(validationContext));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(ValidationContext validationContext)
        {
            // Message that was supplied
            if (!string.IsNullOrEmpty(this.ErrorMessage))
            {
                return this.ErrorMessage;
            }

            // Custom message
            return $"{validationContext.DisplayName} must be a palindrome";
        }
    }
}
