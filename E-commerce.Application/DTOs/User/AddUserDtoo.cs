
namespace E_commerce.Application.DTOs.User
{
    public class AddUserDtoo
    {
        public int UserID { get; set; } // ضفنا ده عشان نستخدمه في الـ UpdateUser
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}