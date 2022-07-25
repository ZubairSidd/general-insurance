using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class ClaimRepositery:IClaimRepositery
    {
        private readonly ApplicationDbContext _context;
        public ClaimRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Claim>> GetAllClaimsAsync()
        {
            return await _context.Claims.ToListAsync();
        }
        public async Task<Claim> GetClaimAsync(int id)
        {
            return await _context.Claims.Where(x => x.claim_no == id).FirstOrDefaultAsync();
        }

    }
}
