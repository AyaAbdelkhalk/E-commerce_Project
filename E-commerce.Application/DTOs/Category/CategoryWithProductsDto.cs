using E_commerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.Category
{
    public class CategoryWithProductsDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<ProductListDto> Products { get; set; }
    }
}
