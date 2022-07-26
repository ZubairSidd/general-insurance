using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
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
    }
}
