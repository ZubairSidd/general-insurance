using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



//Controller for Claims Table 
//It will only call the method which are defined in the ClaimRepositery.cs and IClaimRepositery.cs

namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private IClaimRepositery _claimRepo;
        public ClaimController(IClaimRepositery claimRepo)
        {
            //Initialisation of Claim Repo
            _claimRepo = claimRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllClaims()//This method will get all claim details which are in the claim table in the database.
        {
            return Ok(await _claimRepo.GetAllClaimsAsync());//Calling the method which is defined in the Repo
        }

        [Route("[action]/{Id:int}")]
        //It will receive Id from the front-end
        public async Task<IActionResult> GetClaim(int id)//This method will get the specific claim  by id from the claim table
        {
            return Ok(await _claimRepo.GetClaimAsync(id));//Calling the method which is defined in the Repo
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UpdateClaimViewModel model)//This method will insert the new claim in the claim table.
        {
            if (ModelState.IsValid)
            {

                var claim = await _claimRepo.Register(model);//Calling the method which is defined in the Repo
                return Ok(claim);
            }
            else return NotFound("claim not created");
        }
        [Route("[action]/{Id:int}")]
        //It will receive Id from the front-end
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClaimViewModel claim)//This method will update the specific claim by id in the cliam table
        {
            if (ModelState.IsValid)
            {
                var registeredClaim = await _claimRepo.Update(id, claim);//Calling the method which is defined in the Repo
                if (registeredClaim != null)//If claim exist in the database then return the claim
                    return Ok(registeredClaim);
                else return NotFound("Claim is not in database");//Claim is not in the database.
            }
            else return BadRequest("Claim not created");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> DeleteClaim([FromRoute] int id)//This method will delete the specific claim by id from the table.
        {
            if (await _claimRepo.Exists(id))//If claim_id exists in the table
            {
                var deletedClaim = await _claimRepo.Delete(id);
                return Ok(deletedClaim);
            }
            return NotFound();//Claim not in the  database
        }
    }
}
