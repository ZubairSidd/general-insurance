using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public interface IUserRepositery
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> GetByUserNameAndPassword(string email, string password);

    }
}
