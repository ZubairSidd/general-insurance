using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class PaymentsRepositery : IPaymentRepositery
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

        public async Task<Payment> Register(UpdatePaymentViewModel payment)
        {
            Payment model = new Payment();
            model.user_id = payment.user_id;
            model.date = payment.date;
            model.purchase_id = payment.purchase_id;

            await _context.Payments.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<Payment> Update(int id, UpdatePaymentViewModel payment)
        {
            Payment model = await GetPaymentAsync(id);
            if (model != null)
            {
                model.user_id = payment.user_id;
                model.date = payment.date;
                model.purchase_id = payment.purchase_id;
                _context.Payments.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else return null;
        }
    }
}
