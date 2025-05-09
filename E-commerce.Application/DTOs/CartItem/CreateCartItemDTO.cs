using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.CartItem
{
    public class CreateCartItemDTO
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity {  get; set; }

    }
}
