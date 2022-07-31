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
    public class Plan_DetailsController : ControllerBase
    {
        private IPlan_DetailsRepositery _planRepo;
        public Plan_DetailsController(IPlan_DetailsRepositery planRepo)
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
