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
    public class RenewalRepositery:IRenewalRepositery
    {
        private readonly ApplicationDbContext _context;
        public RenewalRepositery(ApplicationDbContext context)
        {
            _context = context;//Initialising the database context
        }
        public async Task<List<Renewal>> GetAllRenewalsAsync()//Definition for fetching all the renewal from the database
        {
            return await _context.Renewals.ToListAsync();
        }
        public async Task<Renewal> GetRenewalAsync(int id)//Definition for fetching the sepefic renewal from the database
        {
            return await _context.Renewals.Where(x => x.renew_id == id).FirstOrDefaultAsync();
        }
        public async Task<Renewal> Update(int id, UpdateRenewalViewModel renewal)//Definition for updating the renewal in  the database
        {
            Renewal model = await GetRenewalAsync(id);
            if (model != null)
            {
                 model.purchase_id = renewal.purchase_id;
                 model.user_id = renewal.user_id;
                 _context.Renewals.Update(model);
                 await _context.SaveChangesAsync();
                 return model;
             }
             else return null;
        }
        public async Task<Renewal> Register(UpdateRenewalViewModel renewal)//Definition for inserting new renewal into the database
        {
            Renewal model = new Renewal();
            model.purchase_id = renewal.purchase_id;
            model.user_id = renewal.user_id;
            await _context.Renewals.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<bool> Exists(int id)//Definition for check whether the specific renewal exists in the database
        {
            return await _context.Renewals.AnyAsync(x => x.renew_id == id);
        }
        public async Task<Renewal> Delete(int id)
        {
            var renewal = await this.GetRenewalAsync(id);
            if (renewal != null)
            {
                _context.Renewals.Remove(renewal);
                await _context.SaveChangesAsync();
                return renewal;
            }
            return null;
        }
    }
}
