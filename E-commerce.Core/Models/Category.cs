using System.ComponentModel.DataAnnotations;

namespace E_commerce.Core.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [MaxLength(30, ErrorMessage = "Category can not be longer than 30 characters")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        public virtual ICollection<Product>? Products { get; set; } //reference navigation property

    }
}
