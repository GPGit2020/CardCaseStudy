using Microsoft.EntityFrameworkCore;

namespace CreditCardAPI.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<UserDetail> UserDetail { get; set; }

        public DbSet<CardEligibilityDetail> CardEligibilityDetail { get; set; }
    }
}
