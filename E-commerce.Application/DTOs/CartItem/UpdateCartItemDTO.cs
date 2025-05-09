using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.CartItem
{
    public class UpdateCartItemDTO
    {
        public int CartItemID { get; set; }
        public int Quantity { get; set; }

    }
}
