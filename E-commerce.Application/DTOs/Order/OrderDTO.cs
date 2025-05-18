using System;
using System.Collections.Generic;
using E_commerce.Application.DTOs.CartItem;

namespace E_commerce.Application.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<CartItemDTO> Items { get; set; } = new List<CartItemDTO>();
    }
}