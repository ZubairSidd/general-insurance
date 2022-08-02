using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This interface declares all the methods which will be used by  its repositery and its controller


namespace Project_Gladiator.Repositery
{
    public interface IPlanRepositery
    {
        Task<List<Plan>> GetAllPlansAsync();
        Task<Plan> GetPlanAsync(int id);
        Task<Plan> Register(UpdatePlanViewModel plan);
        Task<Plan> Update(int id, UpdatePlanViewModel plan);
        Task<Plan> Delete(int id);
        Task<bool> Exists(int id);
    }
}
