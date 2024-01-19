using Microsoft.EntityFrameworkCore;
using SimpleWebApiProject.Model;

namespace SimpleWebApiProject.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<StudentDetails> StudentDetails { get; set; }

    }
}
