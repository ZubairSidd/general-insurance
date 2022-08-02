using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Models;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Controller for Renewals Table 
//It will only call the method which are defined in the RenewalRepositery.cs and IRenewalRepositery.cs

namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenewalController : ControllerBase
    {
        private IRenewalRepositery _renewalRepo;
        public RenewalController(IRenewalRepositery renewalRepo)
        {
            _renewalRepo = renewalRepo;//Initializing the Repositery
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllRenewals()//It will fetch all renewals from the database
        {
            return Ok(await _renewalRepo.GetAllRenewalsAsync());//Calling the method defined in the repo
        }

        [Route("[action]/{Id:int}")]
        //It will receive the Id from the front-end
        public async Task<IActionResult> GetRenewal(int id)//It will fetch the specific renewal from the database
        {
            return Ok(await _renewalRepo.GetRenewalAsync(id));//Calling the method defined in the repo
        }
        [HttpPut]
        [Route("[action]/{Id:int}")]
        //It will receive the Id from the front-end
        //It will update the specific renewal by id in the database if it exists
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateRenewalViewModel renewal)
        {
            Renewal model = await _renewalRepo.Update(id, renewal);//Calling the method defined in the repo
            if (model != null) return Ok(model);
            else return NotFound("Error");//Update Failed
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdateRenewalViewModel renewal)//It will insert new renewal in the database
        {
            Renewal model = await _renewalRepo.Register(renewal);//Calling the method defined in the repo
            if (model != null) return Ok(model);
            else return NotFound("Error");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        //It will receive the Id from the front-end
        public async Task<IActionResult> DeleteRenewal([FromRoute] int id)//It will delete the specific renewal from the database
        {
            if (await _renewalRepo.Exists(id))//If it exists
            {
                var deletedRenewal = await _renewalRepo.Delete(id);//Calling the method defined in the repo
                return Ok(deletedRenewal);
            }
            return NotFound();
        }

    }
}
