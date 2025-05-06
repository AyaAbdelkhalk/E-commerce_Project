namespace E_commerce.Core.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; } 
        public int OrderID { get; set; } 
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
        public virtual Order Order { get; set; } // reference navigation property
        public virtual Product Product { get; set; } // reference navigation property
        


    }
}
