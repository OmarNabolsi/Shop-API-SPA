using Microsoft.EntityFrameworkCore;
using Shop_Back.Models;

namespace Shop_Back.Data
{
  public class ShopDbContext : DbContext
  {
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
            .HasKey(p => p.Id);
        builder.Entity<Product>()
            .Property(p => p.CreatedOn)
            .ValueGeneratedOnAdd();
        builder.Entity<Product>()
            .Property(p => p.LastUpdated)
            .ValueGeneratedOnUpdate();
        // builder.Entity<Product>().Ignore(p => p.Id);
    }
    
  }
}