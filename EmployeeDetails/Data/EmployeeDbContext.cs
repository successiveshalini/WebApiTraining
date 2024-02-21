using EmployeeDetails.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDetails.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department>departments { get; set; } 
        public DbSet<ProductModel>products { get; set; }    


    }
}
