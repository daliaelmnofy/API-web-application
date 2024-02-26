using Day1.Models;
using Microsoft.EntityFrameworkCore;

namespace Day1.Database
{
    public class APIsContext : DbContext
    {
        public APIsContext()
        {


        }
        public APIsContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}
