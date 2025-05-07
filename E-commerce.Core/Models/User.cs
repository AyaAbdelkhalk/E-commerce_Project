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
        [MaxLength(50, ErrorMessage = "Email address can not be longer than 50 characters")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public Role Role { get; set; } = Role.Client;
        public string LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime LastLoginDate { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Order>? Orders { get; set; } // reference navigation property

    }
}
