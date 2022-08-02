using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



//Controller for Payments Table 
//It will only call the method which are defined in the PaymentRepositery.cs and IPaymentRepositery.cs
namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentRepositery _paymentRepo;
        public PaymentController(IPaymentRepositery paymentRepo)
        {
            _paymentRepo = paymentRepo;//Initialising the Repositery
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllPayments()//It will fetch all the payments from the payments table
        {
            return Ok(await _paymentRepo.GetAllPaymentsAsync());//Calling the method defined in the Repo
        }

        [Route("[action]/{Id:int}")]
        //It will receive Id from the front-end
        public async Task<IActionResult> GetPayment(int id)//This method will fetch the specific payment by Id from the database.
        {
            return Ok(await _paymentRepo.GetPaymentAsync(id));////Calling the method defined in the Repo
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdatePaymentViewModel model)//It will insert a new Payment in the database.
        {
            if (ModelState.IsValid)
            {
                var detail = await _paymentRepo.Register(model);//Calling the method defined in the Repo
                return Ok(detail);
            }
            else return BadRequest("Payment not created");
        }
        [Route("[action]/{Id:int}")]
        //This method will get the Id from the front-end
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePaymentViewModel payment)//It will update the payment by Id in the database.
        {
            if (ModelState.IsValid)
            {
                var registeredPayment = await _paymentRepo.Update(id, payment);//Calling the method defined in the Repo
                if (registeredPayment != null)
                    return Ok(registeredPayment);
                else return BadRequest("Payment is not in database");
            }
            else return BadRequest("Payment not created");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        //It will get the Id from the front-end
        public async Task<IActionResult> DeletePayment([FromRoute] int id)//It will delete the payment by Id from the database.
        {
            if (await _paymentRepo.Exists(id))//If payment exists
            {
                var deletedPayment = await _paymentRepo.Delete(id);//Calling the method defined in the Repo
                return Ok(deletedPayment);
            }
            return BadRequest("Payment doesn't exists");//Payment doesn't exists
        }
    }
}
