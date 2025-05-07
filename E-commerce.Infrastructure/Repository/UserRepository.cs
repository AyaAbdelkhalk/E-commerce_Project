using E_commerce.Application.Interfaces;
using E_commerce.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<User> GetByEmailAsync(string email)
        {
            var user = await _dbSet.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
            return user;
        }

    }
}
