using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroToEF_E.Models
{
    public class AllowedDepartment: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string department = value.ToString().ToLower();
                if(department != "cse" && department != "bba" && department!= "eee")
                {
                    return new ValidationResult(ErrorMessage ?? "Department must be in CSE/EEE/BBA");
                }
            }
            return ValidationResult.Success;
        }
    }

    [Table("students")]
    public class Student
    {
        public int? id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [AllowedDepartment(ErrorMessage ="Please provide a valid department.")]
        public string department { get; set; }

        [Required(ErrorMessage = "Program is required")]
        public string program { get; set; }

        [Required(ErrorMessage = "Credit completed is required")]
        public int? credit_completed { get; set; }

    }
}
