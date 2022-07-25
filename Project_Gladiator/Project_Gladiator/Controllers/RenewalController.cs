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
    }
}
