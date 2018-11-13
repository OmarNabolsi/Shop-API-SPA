using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop_Back.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}