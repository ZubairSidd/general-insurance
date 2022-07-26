using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class UserRepositery:IUserRepositery
    {
        private readonly ApplicationDbContext _context;
        public UserRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.Where(x => x.user_id == id).FirstOrDefaultAsync();
        }

    }
}
