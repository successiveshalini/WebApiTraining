using Microsoft.EntityFrameworkCore;
using NewCrudOperationApi.Model;

namespace NewCrudOperationApi.Data
{
    public class EmployeeDbContext:DbContext
    {
       public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<EmployeeModel> employeeModels { get; set; }    

    }
}
