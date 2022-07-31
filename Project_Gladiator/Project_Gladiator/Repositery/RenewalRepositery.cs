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
    public class RenewalRepositery:IRenewalRepositery
    {
        private readonly ApplicationDbContext _context;
        public RenewalRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Renewal>> GetAllRenewalsAsync()
        {
            return await _context.Renewals.ToListAsync();
        }
        public async Task<Renewal> GetRenewalAsync(int id)
        {
            return await _context.Renewals.Where(x => x.renew_id == id).FirstOrDefaultAsync();
        }
        public async Task<Renewal> Update(int id, UpdateRenewalViewModel renewal)
        {
            if(id!= null)
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
            return null;
        }
        public async Task<Renewal> Register(UpdateRenewalViewModel renewal)
        {
            Renewal model = new Renewal();
            model.purchase_id = renewal.purchase_id;
            model.user_id = renewal.user_id;
            await _context.Renewals.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
