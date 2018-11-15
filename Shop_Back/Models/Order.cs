using System.Collections.Generic;

namespace Shop_Back.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}