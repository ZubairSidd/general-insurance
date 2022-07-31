using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
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
            var user = await _context.Users.Where(x => x.user_id == id).FirstOrDefaultAsync();
            if (user != null) return user;
            else return null;
        }
        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Users.Where(u => u.email == email & u.password == password).FirstOrDefaultAsync();
        }

        public async Task<User> Create(UpdateUserViewModel user)
        {
            User model = new User();
            model.name = user.name;
            model.email = user.email;
            model.dob = user.dob;
            model.password = user.password;
            model.conf_password = user.conf_password;
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
            return model; 
        }
        public async Task<User> Update(int id,UpdateUserViewModel user)
        {
            User model = await GetUserAsync(id);
            if (model != null)
            {
                model.name = user.name;
                model.email = user.email;
                model.dob = user.dob;
                model.password = user.password;
                model.conf_password = user.conf_password;
                _context.Users.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else return null;            
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.Users.AnyAsync(x => x.user_id == id);
        }
        public async Task<User> Delete(int id)
        {
            var user = await this.GetUserAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }
        public async Task<bool> UserByEmail(string email)
        {
            return await _context.Users.AnyAsync(x => x.email == email);
        }
    }
}
