using E_commerce.Application.DTOs.User;
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

namespace E_commerce.Application.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response<User>> AddNewUser(AddUserDTO userdto)
        {
            var user = userdto.Adapt<User>();
            user.Password = PasswordHelper.HashPassword(userdto.Password);
            var response = await IsValidUser(userdto);
            if (!response.Succeeded)
            {

                return new Response<User>
                {
                    Succeeded = false,
                    Errors = response.Errors
                };
            }
            var existingUser = await _userRepository.GetByEmailAsync(userdto.UserName);
            if (existingUser != null)
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "The UserName is already registered." }
                };
            }
            return new Response<User> { Data = await _userRepository.AddAsync(user), Succeeded = true };
        }

        public async Task<Response<User>> Login(LoginDTO loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.UserName);
            if (user == null)
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Invalid email or password." }
                };
            }
            if (!PasswordHelper.VerifyPassword(loginDto.Password, user.Password))
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Invalid email or password." }
                };
            }
            SessionManager.Login(user);
            return new Response<User>
            {
                Succeeded = true,
                Data = user
            };
        }

        public Response<string> Logout()
        {
            if (SessionManager.IsLoggedIn)
            {
                SessionManager.Logout();
                return new Response<string>
                {
                    Succeeded = true,
                    Data = "Logout successful."
                };
            }
            else
            {
                return new Response<string>
                {
                    Succeeded = false,
                    Errors = new List<string> { "User is not logged in." }
                };
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
        public User GetUserById(int id)
        {
            var user = _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return user.Result;

        }


    }
}
