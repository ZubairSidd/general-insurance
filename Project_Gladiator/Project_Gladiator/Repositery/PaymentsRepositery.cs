using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class PaymentsRepositery:IPaymentRepositery
    {
        private readonly ApplicationDbContext _context;
        public PaymentsRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task<Payment> GetPaymentAsync(int id)
        {
            return await _context.Payments.Where(x => x.pay_id == id).FirstOrDefaultAsync();
        }
    }
}
