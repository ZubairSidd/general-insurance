using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class PlanRepositery:IPlanRepositery
    {
        private readonly ApplicationDbContext _context;
        public PlanRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Plan>> GetAllPlansAsync()
        {
            return await _context.Plans.ToListAsync();
        }
        public async Task<Plan> GetPlanAsync(int id)
        {
            return await _context.Plans.Where(x => x.plan_id == id).FirstOrDefaultAsync();
        }
    }
}
