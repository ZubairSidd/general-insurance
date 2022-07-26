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
    public class PurchaseController : ControllerBase
    {
        private IPurchaseRepositery _purchaseRepo;
        public PurchaseController(IPurchaseRepositery purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllPurchases()
        {
            return Ok(await _purchaseRepo.GetAllPurchasesAsync());
        }

        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> GetPurchase(int id)
        {
            return Ok(await _purchaseRepo.GetPurchaseAsync(id));
        }
    }
}
