using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs
{
    public class CartItemDTO
    {
        public int CartItemID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }

        public decimal TotalPrice => Price * Quantity;

    }
}
