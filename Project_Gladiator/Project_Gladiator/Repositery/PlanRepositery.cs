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
        public async Task<Plan> Register(UpdatePlanViewModel plan)
        {
            Plan model = new Plan();
            model.amount = plan.amount;
            model.plan_details = plan.plan_details;
            model.policy_number = plan.policy_number;
            model.type = plan.type;
            await _context.Plans.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<Plan> Update(int id, UpdatePlanViewModel plan)
        {
            var model = await GetPlanAsync(id);
            if(model != null)
            {
                model.amount = plan.amount;
                model.plan_details = plan.plan_details;
                model.policy_number = plan.policy_number;
                model.type = plan.type;
                _context.Plans.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }return null;

        }
    }
}
