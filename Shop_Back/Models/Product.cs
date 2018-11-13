using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_Back.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string ImageUrl { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdated { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}