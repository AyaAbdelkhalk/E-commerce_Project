using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.Order
{
    public class UpdateOrderStatusDto
    {
        public int OrderID { get; set; }
        public string NewStatus { get; set; }
         public DateTime DateProcessed { get; set; } // date when the order was processed
    }
}
