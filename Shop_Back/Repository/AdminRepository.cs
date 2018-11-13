using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop_Back.Data;
using Shop_Back.Models;

namespace Shop_Back.Repository
{
  public class AdminRepository : IAdminRepository
  {
    private readonly ShopDbContext _context;
    public AdminRepository(ShopDbContext context)
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

    
    public async Task<Product> GetProduct(int id)
    {
      return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProducts(int userId)
    {
      return await _context.Products.Where(p => p.UserId == userId).ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public User GetUserByName(string name)
    {
      return _context.Users.Where(u => u.Name == name).FirstOrDefault();
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
      return await _context.Users.Include(u => u.Products).ToListAsync();
    }

    public async Task<bool> SaveAll()
    {
      return await _context.SaveChangesAsync() > 0;
    }


    public void UpdateProduct(Product product)
    {
      _context.Products.Update(product);
    }
    
  }
}