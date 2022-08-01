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
    public class PaymentController : ControllerBase
    {
        private IPaymentRepositery _paymentRepo;
        public PaymentController(IPaymentRepositery paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllPayments()
        {
            return Ok(await _paymentRepo.GetAllPaymentsAsync());
        }

        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            return Ok(await _paymentRepo.GetPaymentAsync(id));
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdatePaymentViewModel model)
        {
            if (ModelState.IsValid)
            {

                var detail = await _paymentRepo.Register(model);
                return Ok(detail);
            }
            else return NotFound("Payment not created");
        }
        [Route("[action]/{Id:int}")]
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePaymentViewModel payment)
        {
            if (ModelState.IsValid)
            {
                var registeredPayment = await _paymentRepo.Update(id, payment);
                if (registeredPayment != null)
                    return Ok(registeredPayment);
                else return NotFound("Payment is not in database");
            }
            else return NotFound("Payment not created");
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int id)
        {
            if (await _paymentRepo.Exists(id))
            {
                var deletedPayment = await _paymentRepo.Delete(id);
                return Ok(deletedPayment);
            }
            return NotFound();
        }
    }
}
