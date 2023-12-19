using Microsoft.EntityFrameworkCore;
using MyTelevisionApi.Model;

namespace MyTelevisionApi.Data
{
    public class MyTelevisionDBContext : DbContext
    {
        public MyTelevisionDBContext(DbContextOptions<MyTelevisionDBContext> options) : base(options) { }
        public DbSet<MyTelivision> MyTelivisions { get; set; }

    }
}
