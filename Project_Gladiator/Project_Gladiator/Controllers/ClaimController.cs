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
    public class ClaimController : ControllerBase
    {
        private IClaimRepositery _claimRepo;
        public ClaimController(IClaimRepositery claimRepo)
        {
            _claimRepo = claimRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllClaims()
        {
            return Ok(await _claimRepo.GetAllClaimsAsync());
        }

        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> GetClaim(int id)
        {
            return Ok(await _claimRepo.GetClaimAsync(id));
        }

        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdateClaimViewModel model)
        {
            if (ModelState.IsValid)
            {

                var claim = await _claimRepo.Register(model);
                return Ok(claim);
            }
            else return NotFound("claim not created");
        }
        [Route("[action]/{Id:int}")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClaimViewModel claim)
        {
            if (ModelState.IsValid)
            {
                var registeredClaim = await _claimRepo.Update(id, claim);
                if (registeredClaim != null)
                    return Ok(registeredClaim);
                else return NotFound("Claim is not in database");
            }
            else return NotFound("Claim not created");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> DeleteClaim([FromRoute] int id)
        {
            if (await _claimRepo.Exists(id))
            {
                var deletedClaim = await _claimRepo.Delete(id);
                return Ok(deletedClaim);
            }
            return NotFound();
        }
    }
}
