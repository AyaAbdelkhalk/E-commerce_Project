using E_commerce.Application.DTOs.User;
using E_commerce.Application.Hepler;
using E_commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.UserServices
{
    public interface IUserServices 
    {
        Task<Response<UserDetails>> AddNewUser(AddUserDTO userdto);
        Task<Response<UserDetails>> Login(LoginDTO loginDto);
        Response<string> Logout();







    }
}
