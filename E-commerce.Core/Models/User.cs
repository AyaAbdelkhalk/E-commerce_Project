using E_commerce.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Core.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        [MaxLength(50, ErrorMessage = "Email address can not be longer than 64 characters")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } 
        public DateTime LastLoginDate { get; set; }
        public virtual ICollection<Order>? Orders { get; set; } // reference navigation property

    }
}
