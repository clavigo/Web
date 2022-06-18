using Microsoft.EntityFrameworkCore;
using static WebApplication3.ClientsBase;

namespace WebApplication3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<BookBase> bookBases { get; set; }
        public DbSet<Client> clients { get; set; }
    }

}
