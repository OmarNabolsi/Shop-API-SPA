using System.Collections.Generic;
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
    public void Add<T>(T enttiy) where T : class
    {
        throw new System.NotImplementedException();
    }

    public void Delete<T>(T enttiy) where T : class
    {
        throw new System.NotImplementedException();
    }

    public async Task<Product> GetProductById(int id)
    {
        return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
  }
}