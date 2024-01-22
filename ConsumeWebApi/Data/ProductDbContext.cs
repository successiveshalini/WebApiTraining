using ConsumeWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsumeWebApi.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<ProductList> ProductLists { get; set; }
    }
}
