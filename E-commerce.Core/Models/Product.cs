using System.ComponentModel.DataAnnotations;

namespace E_commerce.Core.Models
{
    public class Product
    {
        public int ProductID { get; set; } 

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(100, ErrorMessage = "Product name can not be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "UnitsInStock cannot be negative")]
        public int UnitsInStock { get; set; } 

        public int CategoryID { get; set; }

        [Required]
        public virtual Category Category { get; set; }
        public string? ImagePath { get; set; } //optional nullable
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } // reference navigation property

        public virtual ICollection<CartItem>? CartItems { get; set; } // reference navigation property
    }
}
