using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public interface IDetailsRepositery
    {
        Task<List<Detail>> GetAllDetailsAsync();
        Task<Detail> GetDetailAsync(int id);
        Task<Detail> Register(UpdateDetailViewModel detail);
        Task<Detail> Update(int id, UpdateDetailViewModel detail);
        Task<Detail> Delete(int id);
        Task<bool> Exists(int id);
    }
}
