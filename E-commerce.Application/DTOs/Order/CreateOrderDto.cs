using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.Order
{
    public class CreateOrderDto
    {
        public int UserID { get; set; }
        public List<CreateOrderDetailDto> Items { get; set; }
    }
}
