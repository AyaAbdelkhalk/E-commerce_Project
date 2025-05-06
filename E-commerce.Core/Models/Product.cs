namespace E_commerce.Core.Models
{
    public class Product
    {
        public int ProductID { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string? ImagePath { get; set; } //optional nullable
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } // reference navigation property

        public virtual ICollection<CartItem>? CartItems { get; set; } // reference navigation property
    }
}
