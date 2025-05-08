using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.Product
{
    public class ProductDetailsDto : ProductListDto
    {
        public string Description { get; set; } = string.Empty;
        public int UnitsInStock { get; set; }
        public string? ImagePath { get; set; }

    }
}
