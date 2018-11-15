using System.Collections.Generic;

namespace Shop_Back.Models
{
    public class Cart
    {        
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}