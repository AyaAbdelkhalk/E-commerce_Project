using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.Order
{
    public class OrderDisDto
    {
        public int OrderID { get; set; }
        public int UserID { get; set; } // foreign key
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // status of the order
        public DateTime DateProcessed { get; set; } // date when the order was processed
        public List<OrderDetailDto> OrderDetails { get; set; } // collection navigation property
    }
}
