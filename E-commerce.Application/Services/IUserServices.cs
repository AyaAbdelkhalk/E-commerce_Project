using E_commerce.Application.DTOs.UserDTOs;
using E_commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public interface IUserServices 
    {
        Task<UserDetails> AddNewUser(AddUserDTO user);

    }
}
