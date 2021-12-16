using Microsoft.EntityFrameworkCore;

namespace Pad3.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Fly> Flies { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
