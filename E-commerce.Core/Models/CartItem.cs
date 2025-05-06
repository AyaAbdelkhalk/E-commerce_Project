using System.ComponentModel.DataAnnotations;

namespace E_commerce.Core.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; } 
        public int UserID { get; set; } // Foreign Key referencing User
        public int ProductID { get; set; } // Foreign Key referencing Product
        // Navigation property
        public virtual User User { get; set; } // Relation to User
        public virtual Product? Product { get; set; } // Relation to Product
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive integer")]
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
