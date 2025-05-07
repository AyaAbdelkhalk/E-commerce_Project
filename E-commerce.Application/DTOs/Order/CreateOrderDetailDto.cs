using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.Order
{
    public class CreateOrderDetailDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }

    }
}
