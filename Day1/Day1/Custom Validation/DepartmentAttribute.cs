using Day1.Services;
using System.ComponentModel.DataAnnotations;

namespace Day1.Custom_Validation
{
    public class DepartmentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var departmentService = (IDepartmentRepo)validationContext.GetService(typeof(IDepartmentRepo));

            var existingDepartment = departmentService.GetByName(value.ToString());

            if (existingDepartment != null)
            {
                return new ValidationResult("Department name must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}
