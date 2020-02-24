using Microsoft.EntityFrameworkCore;

namespace RestAPI.Models
{
    public class EShopContext : DbContext
    {
        public EShopContext(DbContextOptions<EShopContext> options) : base(options)
        {

        }

        public DbSet<Page> Pages { get; set; }

    }
}
