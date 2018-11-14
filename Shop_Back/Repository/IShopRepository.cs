using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_Back.Models;

namespace Shop_Back.Repository
{
    public interface IShopRepository
    {
         void Add<T>(T enttiy) where T : class;
         void Delete<T>(T enttiy) where T : class;

         Task<IEnumerable<Product>> GetProducts();
         Task<Product> GetProductById(int id);
    }
}