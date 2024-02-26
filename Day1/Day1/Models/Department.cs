using Day1.Custom_Validation;
using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [Department(ErrorMessage = "Department name must be unique.")]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }

    }
}
