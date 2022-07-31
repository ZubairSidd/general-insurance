using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class ClaimRepositery : IClaimRepositery
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

        public async Task<Claim> Register(UpdateClaimViewModel claim)
        {
            Claim model = new Claim();
            model.user_id = claim.user_id;
            model.plan_id = claim.plan_id;
            model.date = claim.date;
            model.reason = claim.reason;
            model.amount = claim.amount;
            model.status = claim.status;

            await _context.Claims.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<Claim> Update(int id, UpdateClaimViewModel claim)
        {
            Claim model = await GetClaimAsync(id);
            if (model != null)
            {
                model.user_id = claim.user_id;
                model.plan_id = claim.plan_id;
                model.date = claim.date;
                model.reason = claim.reason;
                model.amount = claim.amount;
                model.status = claim.status;
                _context.Claims.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else return null;
        }
    }
}
