using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace Day1.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Student name is required.")]
        public string Name { get; set; }

        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int Age { get; set; }

        [StringLength(100, ErrorMessage = "Address length must be between {2} and {1} characters.", MinimumLength = 5)]
        public string Address { get; set; }

        [Url(ErrorMessage = "Invalid image URL format.")]
        public string Image { get; set; }

    }
}
