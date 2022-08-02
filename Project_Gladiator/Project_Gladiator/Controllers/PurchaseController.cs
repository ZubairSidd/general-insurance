using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



//Controller for Purchases Table 
//It will only call the method which are defined in the PurchaseRepositery.cs and IPurchaseRepositery.cs


namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private IPurchaseRepositery _purchaseRepo;
        public PurchaseController(IPurchaseRepositery purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;//Initialising the Repositery
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllPurchases()//It will fetch all the purchases from the purchases table
        {
            return Ok(await _purchaseRepo.GetAllPurchasesAsync());//Calling the method defined in the repo
        }

        [Route("[action]/{Id:int}")]
        //It will receive Id from the front-end
        public async Task<IActionResult> GetPurchase(int id)//It will fetch specific purchase from the database
        {
            return Ok(await _purchaseRepo.GetPurchaseAsync(id));//Calling the method defined in the repo
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdatePurchaseViewModel model)//It will insert new Purchase made in the database
        {
            if (ModelState.IsValid)
            {
                var purchase = await _purchaseRepo.Register(model);//Calling the method defined in the repo
                return Ok(purchase);
            }
            else return NotFound("Purchase not created");
        }

        [Route("[action]/{Id:int}")]
        //It will receive Id from the front-end
        [HttpPut]
        //It will update the specific purchase by Id in the database if it exists
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody]UpdatePurchaseViewModel purchase)
        {
            var p = await _purchaseRepo.Update(id,purchase);//Calling the method defined in the repo
            if (p != null) return Ok(p);
            else return NotFound("Detail is not in the database");
        }
        [HttpDelete]
        [Route("[action]/{Id:int}")]
        //It will receive the Id from the front-end
        public async Task<IActionResult> DeletePurchase([FromRoute] int id)//It will delete the purchase from the database
        {
            if (await _purchaseRepo.Exists(id))//If it exists
            {
                var deletedPurchase = await _purchaseRepo.Delete(id);//Calling the method defined in the repo
                return Ok(deletedPurchase);
            }
            return NotFound();
        }
    }
}
