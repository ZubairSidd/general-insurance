using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
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
        Task<Payment> Update(int id, UpdatePaymentViewModel payment);
        Task<Payment> Register(UpdatePaymentViewModel payment);
    }
}
