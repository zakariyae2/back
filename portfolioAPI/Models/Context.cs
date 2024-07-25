using Microsoft.EntityFrameworkCore;

namespace portfolioAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Detail> detail { get; set; }
        public DbSet<name> name { get; set; }
    }
}
