using E_commerce.Application.DTOs.UserDTOs;
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
        private readonly Mapper _mapper;
        public UserServices(IUserRepository userRepository, Mapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDetails> AddNewUser(AddUserDTO user)
        {
            var userEntity = user.Adapt<User>();
            //hash password
            //var hashedPassword = _passwordHasher.HashPassword(userEntity, userEntity.Password);
            var result = await _userRepository.AddAsync(userEntity);
            return result.Adapt<UserDetails>();
        }

         
    }
}
