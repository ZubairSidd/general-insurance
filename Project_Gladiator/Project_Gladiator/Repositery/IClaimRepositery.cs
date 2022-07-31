using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public interface IClaimRepositery
    {
        Task<List<Claim>> GetAllClaimsAsync();
        Task<Claim> GetClaimAsync(int id);
        Task<Claim> Register(UpdateClaimViewModel claim);
        Task<Claim> Update(int id, UpdateClaimViewModel claim);
        Task<Claim> Delete(int id);
        Task<bool> Exists(int id);
    }
}
