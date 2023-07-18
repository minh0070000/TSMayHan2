using Microsoft.EntityFrameworkCore;
using TSMayHan2.Models;

namespace TSMayHan2.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<standard> standards { get; set; }
        public DbSet<parameter> parameters { get; set; }
        public DbSet<device_manage> device_manages { get; set; }
        public DbSet<users> users { get; set; }

    }
}
