using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_Back.Models;

namespace Shop_Back.Repository
{
    public interface IShopRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void UpdateCartItem(CartItem cartItem);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);

        Task<CartItem> GetCartItem(int cartItemId);
        Task<Cart> GetCartByUserId(int userId);

        Task<Order> AddOrder(Order order);
        Task<bool> SaveAllAsync();
    }
}