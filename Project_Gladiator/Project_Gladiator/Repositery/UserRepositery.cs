using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//It will commnunicate with the database through dbcontext
//Contains all the definition of the methods which are declared in its interface

namespace Project_Gladiator.Repositery
{
    public class UserRepositery:IUserRepositery
    {
        private readonly ApplicationDbContext _context;
        public UserRepositery(ApplicationDbContext context)
        {
            _context = context;//Initialising the database context
        }
        public async Task<List<User>> GetAllUsersAsync()//Definition for fetching all the user from the database
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserAsync(int id)//Definition for fetching the sepefic user from the database
        {
            var user = await _context.Users.Where(x => x.user_id == id).FirstOrDefaultAsync();
            if (user != null) return user;
            else return null;
        }

        //This method will return the user by receiving the email and password if it exists in the database
        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Users.Where(u => u.email == email & u.password == password).FirstOrDefaultAsync();
        }

        public async Task<User> Create(UpdateUserViewModel user)////Definition for inserting new user into the database
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
        public async Task<User> Update(int id,UpdateUserViewModel user)//Definition for updating the user in  the database
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
        public async Task<bool> Exists(int id)//Definition for check whether the specific user exists in the database
        {
            return await _context.Users.AnyAsync(x => x.user_id == id);
        }
        public async Task<User> Delete(int id)//Definition for deleting the user from the database
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

        //This method will return the user by email if it exists in the database
        public async Task<bool> UserByEmail(string email)
        {
            return await _context.Users.AnyAsync(x => x.email == email);
        }
        //This method will be used if user forgot his password and it will update the password of the user
        public async Task<User> ForgotPassword(string email,string password)
        {
            User model = await _context.Users.Where(u => u.email == email).FirstOrDefaultAsync();
            model.password = password;
            model.conf_password = password;
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
