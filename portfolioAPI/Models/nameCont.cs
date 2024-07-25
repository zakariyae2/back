using Microsoft.EntityFrameworkCore;

namespace portfolioAPI.Models
{
    public class nameCont : DbContext
    {
        public nameCont(DbContextOptions options) : base(options)
        {
        }

        public DbSet<name> name { get; set; }
    }
}
