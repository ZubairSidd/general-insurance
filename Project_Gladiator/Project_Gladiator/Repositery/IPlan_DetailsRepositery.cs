using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public interface IPlan_DetailsRepositery
    {
        Task<List<Plan_Details>> GetAllPlansAsync();
        Task<Plan_Details> GetPlanAsync(int id);
    }
}
