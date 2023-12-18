using Microsoft.EntityFrameworkCore;
using MyMobileApi1.Model;

namespace MyMobileApi1.Data
{
    public class MobileDetailsDBContext : DbContext
    {
        public MobileDetailsDBContext(DbContextOptions<MobileDetailsDBContext> options) : base(options) { }
        public DbSet<MobileDetails> MobileDetails { get; set; }
    }
}
