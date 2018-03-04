using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace Vue2SpaSignalR.Models
{
    [Table("WorkItems")]
    public class WorkItem
    {
        public int Id { get; set; }

        [Display(Name = "Assigned Employee")]
        public int EmployeeId { get; set; }

        [Required, Palindrome] // [Remote(action: "ValidateTaskName", controller: "WorkItems")]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Required]
        public string Description { get; set; }

        public Employee Employee { get; set; }
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
            taskName = rgx.Replace(taskName, "");

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
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                return ErrorMessage;
            }

            // Custom message
            return $"{validationContext.DisplayName} must be a palindrome";
        }
    }
}
