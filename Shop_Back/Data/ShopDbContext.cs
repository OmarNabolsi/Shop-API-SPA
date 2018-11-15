using Microsoft.EntityFrameworkCore;
using Shop_Back.Models;

namespace Shop_Back.Data
{
  public class ShopDbContext : DbContext
  {
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Product>()
       .HasMany(p => p.CartItems)
       .WithOne(ci => ci.Product)
       .OnDelete(DeleteBehavior.Restrict);
    }
  }
}