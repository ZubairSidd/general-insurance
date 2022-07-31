using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class Plan_DetailsRepositery:IPlan_DetailsRepositery
    {
        private readonly ApplicationDbContext _context;
        public Plan_DetailsRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Plan_Details>> GetAllPlansAsync()
        {
            return await _context.Plans.ToListAsync();
        }
        public async Task<Plan_Details> GetPlanAsync(int id)
        {
            return await _context.Plans.Where(x => x.plan_id == id).FirstOrDefaultAsync();
        }
    }
}
