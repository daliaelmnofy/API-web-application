using Day1.Services;
using System.ComponentModel.DataAnnotations;

namespace Day1.Custom_Validation
{
    public class StudentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var studentService = (IStudentRepo)validationContext.GetService(typeof(IStudentRepo));

            var existingStudent = studentService.GetByName(value.ToString());

            if (existingStudent != null)
            {
                return new ValidationResult("Student name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
