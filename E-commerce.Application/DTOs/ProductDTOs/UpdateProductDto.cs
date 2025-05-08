using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.DTOs.ProductDTOs
{
    public class UpdateProductDto : CreateProductDto
    {
        public int ProductID { get; set; }
    }
}
