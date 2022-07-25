using Project_Gladiator.Models;
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
    }
}
