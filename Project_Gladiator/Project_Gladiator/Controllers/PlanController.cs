using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



//Controller for Plans Table 
//It will only call the method which are defined in the PlanRepositery.cs and IPlanRepositery.cs
namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private IPlanRepositery _planRepo;
        public PlanController(IPlanRepositery planRepo)
        {
            _planRepo = planRepo;//Initialising the Repositery
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllPlans()//It will fetch all the plans from the database
        {
            return Ok(await _planRepo.GetAllPlansAsync());//Calling the method defined in the Repo
        }

        [Route("[action]/{Id:int}")]
        //It will get the Id from the front-end
        public async Task<IActionResult> GetPlan(int id)//It will fetch the plan by Id from the database
        {
            return Ok(await _planRepo.GetPlanAsync(id));//Calling the method defined in the Repo
        }
        [Route("[action]/{Id:int}")]
        //It will fetch Id from the front-end
        [HttpPut]
        //This method will update the plan by id from the database if it exists
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]UpdatePlanViewModel plan)
        {
            var model = await _planRepo.Update(id, plan);//Calling the method defined in the Repo
            if (model != null) return Ok(model);//If plan exists
            return BadRequest("Error");
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UpdatePlanViewModel plan)//It will insert new Plan in the database
        {
            var model = await _planRepo.Register(plan);
            if (model != null) return Ok(model);//Calling the method defined in the Repo
            else return NotFound("Error in Register");
        }
        [HttpDelete]
        [Route("[action]/{Id:int}")]
        //It will get the Id from the front-end
        public async Task<IActionResult> DeletePlan([FromRoute] int id)//It will delete the specific plan by id from the database
        {
            if (await _planRepo.Exists(id))//If it exists
            {
                var deletedPlan = await _planRepo.Delete(id);//Calling the method defined in the Repo
                return Ok(deletedPlan);
            }
            return NotFound();
        }
    }
}
