using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public interface IPaymentRepositery
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment> GetPaymentAsync(int id);
    }
}
