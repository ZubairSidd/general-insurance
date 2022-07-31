using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Models;
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
    public class RenewalController : ControllerBase
    {
        private IRenewalRepositery _renewalRepo;
        public RenewalController(IRenewalRepositery renewalRepo)
        {
            _renewalRepo = renewalRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllRenewals()
        {
            return Ok(await _renewalRepo.GetAllRenewalsAsync());
        }

        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> GetRenewal(int id)
        {
            return Ok(await _renewalRepo.GetRenewalAsync(id));
        }
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateRenewalViewModel renewal)
        {
            if (id != null) return NotFound("Error");
            else
            {
                Renewal model = await _renewalRepo.Update(id, renewal);
                if (model != null) return Ok(model);
                else return NotFound("Error");
            }
        }
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdateRenewalViewModel renewal)
        {
            Renewal model = await _renewalRepo.Register(renewal);
            if (model != null) return Ok(model);
            else return NotFound("Error");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> DeleteRenewal([FromRoute] int id)
        {
            if (await _renewalRepo.Exists(id))
            {
                var deletedRenewal = await _renewalRepo.Delete(id);
                return Ok(deletedRenewal);
            }
            return NotFound();
        }

    }
}
