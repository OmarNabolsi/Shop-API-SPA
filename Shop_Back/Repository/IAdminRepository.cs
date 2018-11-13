using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_Back.Models;

namespace Shop_Back.Repository
{
    public interface IAdminRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void UpdateProduct(Product product);
        Task<bool> SaveAll();
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        User GetUserByName(string name);
        Task<IEnumerable<Product>> GetProducts(int userId);
        Task<Product> GetProduct(int id);
    }
}