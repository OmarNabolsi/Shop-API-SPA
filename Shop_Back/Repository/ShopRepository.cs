using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_Back.Data;
using Shop_Back.Models;

namespace Shop_Back.Repository
{
  public class ShopRepository : IShopRepository
  {
    private readonly ShopDbContext _context;
    public ShopRepository(ShopDbContext context)
    {
        _context = context;
    }
    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public async Task<Cart> GetCartByUserId(int userId)
    {
      return await _context.Carts.Include(c => c.CartItems).Where(c => c.UserId == userId).SingleOrDefaultAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<CartItem> GetCartItem(int cartItemId)
    {
        return await _context.CartItems.Include(ci => ci.Product).SingleOrDefaultAsync(ci => ci.Id == cartItemId);
    }
    public void UpdateCartItem(CartItem cartItem)
    {
      _context.CartItems.Update(cartItem);
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }

  }
}