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

        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdatePurchaseViewModel model)
        {
            if (ModelState.IsValid)
            {

                var purchase = await _purchaseRepo.Register(model);
                return Ok(purchase);
            }
            else return NotFound("Purchase not created");
        }

        [Route("[action]/{Id:int}")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]UpdatePurchaseViewModel purchase)
        {
            var p = await _purchaseRepo.Update(id,purchase);
            if (p != null) return Ok(p);
            else return NotFound("Detail is not in the database");
        }
        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> DeletePurchase([FromRoute] int id)
        {
            if (await _purchaseRepo.Exists(id))
            {
                var deletedPurchase = await _purchaseRepo.Delete(id);
                return Ok(deletedPurchase);
            }
            return NotFound();
        }
    }
}
