using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
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
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]UpdatePlanViewModel plan)
        {
            var model = await _planRepo.Update(id, plan);
            if (model != null) return Ok(model);
            return NotFound("Error");
        }
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdatePlanViewModel plan)
        {
            var model = await _planRepo.Register(plan);
            if (model != null) return Ok(model);
            else return NotFound("Error in Register");
        }
        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> DeletePlan([FromRoute] int id)
        {
            if (await _planRepo.Exists(id))
            {
                var deletedPlan = await _planRepo.Delete(id);
                return Ok(deletedPlan);
            }
            return NotFound();
        }
    }
}
