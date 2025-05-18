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
            //var existingUser = await _userRepository.GetByUserNameAsync(userdto.UserName);
            //if (existingUser != null)
            //{
            //    return new Response<User>
            //    {
            //        Succeeded = false,
            //        Errors = new List<string> { "The UserName is already registered." }
            //    };
            //}
            var x=await _userRepository.AddAsync(user);
            SessionManager.Login(x);
            return new Response<User> { Data = x, Succeeded = true };
        }

        public async Task<Response<User>> Login(LoginDTO loginDto)
        {
            var user = await _userRepository.GetByUserNameAsync(loginDto.UserName);
            if (user == null)
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Invalid User Name or password." }
                };
            }
            if (!PasswordHelper.VerifyPassword(user.Password, loginDto.Password))
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Invalid User Name or password." }
                };
            }
            if (!user.IsActive)
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "User is not active." }
                };
            }
            user.LastLoginDate = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);
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

        public async Task<Response<User>> UpdateUser(AddUserDTO userdto)
        {
            var response = await IsValidUser(userdto);
            if (!response.Succeeded)
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = response.Errors
                };
            }

            var existingUser = SessionManager.CurrentUser;
            if (existingUser == null)
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "The User does not exist." }
                };
            }

            var usr = await _userRepository.GetByIdAsync(existingUser.UserID);
            if (usr == null)
            {
                return new Response<User>
                {
                    Succeeded = false,
                    Errors = new List<string> { "User not found in the database." }
                };
            }

            usr.FirstName = userdto.FirstName;
            usr.LastName = userdto.LastName;
            usr.UserName = userdto.UserName;
            usr.Email = userdto.Email;

            if (!string.IsNullOrWhiteSpace(userdto.Password))
            {
                usr.Password = PasswordHelper.HashPassword(userdto.Password);
            }

            var updated = await _userRepository.UpdateAsync(usr);

            return new Response<User>
            {
                Data = updated,
                Succeeded = true
            };
        }


        private async Task<Response<UserDetails>> IsValidUser(AddUserDTO userDTO)
        {
            List<string> errors = new List<string>();
            //var currentUser = SessionManager.CurrentUser;

            var existingUserName = await _userRepository.GetByUserNameAsync(userDTO.UserName);
            if (userDTO.UserName.Length < 3)
            {
                errors.Add("The UserName must be at least 3 characters long.");
            }
            if (string.IsNullOrEmpty(userDTO.UserName) )
            {
                errors.Add("The UserName is invalid");
            }

            if (string.IsNullOrEmpty(userDTO.FirstName) || userDTO.FirstName.Length < 3)
            {
                errors.Add("The First Name is invalid. It must be at least 3 characters long.");
            }
            if (string.IsNullOrEmpty(userDTO.LastName) || userDTO.LastName.Length < 3)
            {
                errors.Add("The Last Name is invalid. It must be at least 3 characters long.");
            }
            //if (currentUser == null)
            //{
            //    errors.Add("Current user session is invalid.");
            //}
            if (existingUserName != null )
            {
                errors.Add("The UserName is already registered.");
            }
            var existingUser = await _userRepository.GetByEmailAsync(userDTO.Email);
            if (existingUser != null /*&& existingUser.Email != currentUser.Email*/)
            {
                errors.Add("The Email address is already registered.");

            }
            if (string.IsNullOrEmpty(userDTO.Email) || !userDTO.Email.Contains("@"))
            {
                errors.Add("The Email address is invalid.");
            }
            var isvalidPassword = PasswordHelper.IsStrongPassword(userDTO.Password);
            if (!isvalidPassword)
            {
                errors.Add("The password must contain at least one uppercase letter, one lowercase letter, and one number.");
            }
            if (userDTO.Password != userDTO.PasswordConfirmed)
            {
                errors.Add("Password and Confirmed Password do not match");
            }
            if (errors.Count > 0)
            {
                return new Response<UserDetails>
                {
                    Succeeded = false,
                    Errors = errors
                };
            }

            return new Response<UserDetails> { Succeeded = true };
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        //get all users


        public async Task<Response<List<userD>>> GetAllUsers()
        {
            var currentUser = SessionManager.CurrentUser;
            if (currentUser == null)
            {
                return new Response<List<userD>>
                {
                    Succeeded = false,
                    Errors = new List<string> { "Current user not found in session." }
                };
            }

            var users = await _userRepository.GetAllAsync();

            if (users == null || !users.Any())
            {
                return new Response<List<userD>>
                {
                    Succeeded = false,
                    Errors = new List<string> { "No users found." }
                };
            }

            var filteredUsers = users
                .Where(u => u.UserID != currentUser.UserID)
                .ToList(); // مهم تحط ToList() هنا عشان تفصل ال LINQ عن EF

            // التحويل إلى DTO
            var userDetails = filteredUsers.Select(u => new userD
            {
                Id = u.UserID,
                UserName = u.UserName,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsActive = u.IsActive ? "Active" : "Inactive",
                Role = u.Role.ToString()
            }).ToList();

            return new Response<List<userD>>
            {
                Succeeded = true,
                Data = userDetails
            };
        }

        public async Task<int> GetTotalUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Count();
        }

    }

}