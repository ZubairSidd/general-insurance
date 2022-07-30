using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
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
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<User> Create(UpdateUserViewModel user);

    }
}
