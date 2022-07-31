using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public interface IRenewalRepositery
    {
        Task<List<Renewal>> GetAllRenewalsAsync();
        Task<Renewal> GetRenewalAsync(int id);
        Task<Renewal> Register(UpdateRenewalViewModel renewal);
        Task<Renewal> Update(int id, UpdateRenewalViewModel renewal);
    }
}
