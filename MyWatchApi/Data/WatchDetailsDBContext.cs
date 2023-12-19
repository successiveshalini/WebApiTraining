using Microsoft.EntityFrameworkCore;
using MyWatchApi.Model;

namespace MyWatchApi.Data
{
    public class WatchDetailsDBContext : DbContext
    {
        public WatchDetailsDBContext(DbContextOptions<WatchDetailsDBContext> options) : base(options) { }
        public DbSet<WatchDetails> watchDetails{ get; set; }
    }
}
