using E_commerce.Core.Enum;

namespace E_commerce.Core.Models
{
    public class Order
    {
        public int OrderID { get; set; } 
        public int UserID { get; set; } // foreign key
        public virtual User? User { get; set; } // navigation property
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } // collection navigation property
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; } // status of the order
        public DateTime DateProcessed { get; set; } // date when the order was processed



    }
}
