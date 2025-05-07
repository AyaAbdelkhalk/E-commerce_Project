using E_commerce.Application.DTOs.UserDTOs;
using E_commerce.Application.Helper;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response<UserDetails>> AddNewUser(AddUserDTO userdto)
        {
            var user = userdto.Adapt<User>();
            var response = await IsValidUser(userdto);
            if (response.Succeeded)
            {
                var newUser = await _userRepository.AddAsync(user);
                var userDetails = newUser.Adapt<UserDetails>();
                return new Response<UserDetails>
                {
                    Succeeded = true,
                    Data = userDetails
                };
            }
            else
            {
                return response;
            }
        }

        private async Task<Response<UserDetails>> IsValidUser(AddUserDTO userDTO)
        {
            List<string> errors = new List<string>();
            var existingUserName = await _userRepository.GetByUserNameAsync(userDTO.UserName);
            if (existingUserName != null)
            {
                errors.Add("The UserName is already registered.");
            }
            var existingUser = await _userRepository.GetByEmailAsync(userDTO.Email);
            if (existingUser != null)
            {
                errors.Add("The Email address is already registered.");

            }
            var isvalidPassword = PasswordHelper.IsStrongPassword(userDTO.Password);
            if (!isvalidPassword)
            {
                errors.Add("The password is invalid. It must contain a Upper letter, a lowercase letter, and a number.");
            }
            if (userDTO.Password != userDTO.PasswordConfirmed)
            {
                errors.Add("Password and Confirmed Password do not match");
            }
            if(errors.Count > 0)
            {
                return new Response<UserDetails>
                {
                    Succeeded = false,
                    Errors = errors
                };
            }
                
            return new Response<UserDetails>{Succeeded = true};
        }

        
    }
}
