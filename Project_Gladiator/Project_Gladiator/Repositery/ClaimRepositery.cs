using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//It will commnunicate with the database through dbcontext
//Contains all the definition of the methods which are declared in its interface

namespace Project_Gladiator.Repositery
{
    public class ClaimRepositery : IClaimRepositery
    {
        private readonly ApplicationDbContext _context;
        public ClaimRepositery(ApplicationDbContext context)
        {
            _context = context;//Initialising the database context
        }
        public async Task<List<Claim>> GetAllClaimsAsync()
        {
            return await _context.Claims.ToListAsync();//
        }
        public async Task<Claim> GetClaimAsync(int id)
        {
            return await _context.Claims.Where(x => x.claim_no == id).FirstOrDefaultAsync();
        }

        public async Task<Claim> Register(UpdateClaimViewModel claim)//Definition for inserting new claim into the database
        {
            Claim model = new Claim();
            model.user_id = claim.user_id;
            model.pay_id = claim.pay_id;
            model.date = claim.date;
            model.reason = claim.reason;
            model.amount = claim.amount;
            model.status = claim.status;

            await _context.Claims.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<Claim> Update(int id, UpdateClaimViewModel claim)//Definition for updating the claim if it exists
        {
            Claim model = await GetClaimAsync(id);
            if (model != null)
            {
                model.user_id = claim.user_id;
                model.pay_id = claim.pay_id;
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
        public async Task<bool> Exists(int id)//Definition for  checking whether claim exists or not
        {
            return await _context.Claims.AnyAsync(x => x.claim_no == id);
        }
        public async Task<Claim> Delete(int id)////Definition for deleting the claim from the database
        {
            var claim = await this.GetClaimAsync(id);
            if (claim != null)
            {
                _context.Claims.Remove(claim);
                await _context.SaveChangesAsync();
                return claim;
            }
            return null;
        }
    }
}
