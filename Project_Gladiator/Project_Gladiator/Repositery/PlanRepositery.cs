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
    public class PlanRepositery:IPlanRepositery
    {
        private readonly ApplicationDbContext _context;
        public PlanRepositery(ApplicationDbContext context)
        {
            _context = context;//Initialising the database context
        }
        public async Task<List<Plan>> GetAllPlansAsync()//Definition for fetching all the plan from the database
        {
            return await _context.Plans.ToListAsync();
        }
        public async Task<Plan> GetPlanAsync(int id)//Definition for fetching the sepefic plan from the database
        {
            return await _context.Plans.Where(x => x.plan_id == id).FirstOrDefaultAsync();
        }
        public async Task<Plan> Register(UpdatePlanViewModel plan)//Definition for inserting new plan into the database
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
        public async Task<Plan> Update(int id, UpdatePlanViewModel plan)//Definition for updating the plan in  the database
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

        public async Task<bool> Exists(int id)//Definition for check whether the specific plan exists in the database
        {
            return await _context.Plans.AnyAsync(x => x.plan_id == id);
        }
        public async Task<Plan> Delete(int id)
        {
            var plan = await this.GetPlanAsync(id);
            if (plan != null)
            {
                _context.Plans.Remove(plan);
                await _context.SaveChangesAsync();
                return plan;
            }
            return null;
        }
    }
}
