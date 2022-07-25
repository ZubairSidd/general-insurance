using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private IPlanRepositery _planRepo;
        public PlanController(IPlanRepositery planRepo)
        {
            _planRepo = planRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllPlans()
        {
            return Ok(await _planRepo.GetAllPlansAsync());
        }

        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> GetPlan(int id)
        {
            return Ok(await _planRepo.GetPlanAsync(id));
        }
    }
}
