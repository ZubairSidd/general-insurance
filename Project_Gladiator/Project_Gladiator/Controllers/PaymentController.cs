﻿using Microsoft.AspNetCore.Http;
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
    }
}