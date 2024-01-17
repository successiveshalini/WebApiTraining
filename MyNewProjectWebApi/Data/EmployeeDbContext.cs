using Microsoft.EntityFrameworkCore;
using MyNewProjectApi.Controllers;
using MyNewProjectApi.Model;

namespace MyNewProjectApi.Data
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        
    }
}
