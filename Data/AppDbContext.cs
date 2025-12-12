using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
       public DbSet<User> user { get; set; }
       public DbSet<Product> product { get; set; }
    }
}
