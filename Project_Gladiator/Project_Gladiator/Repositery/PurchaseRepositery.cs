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
    public class PurchaseRepositery : IPurchaseRepositery
    {
        private readonly ApplicationDbContext _context;
        public PurchaseRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Purchase>> GetAllPurchasesAsync()
        {
            return await _context.Purchases.ToListAsync();
        }
        public async Task<Purchase> GetPurchaseAsync(int id)
        {
            return await _context.Purchases.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<Purchase> Register(UpdatePurchaseViewModel purchase)
        {
            Purchase model = new Purchase();
            model.plan_id = purchase.plan_id;
            model.detail_id = purchase.detail_id;
            model.DOP = purchase.DOP;
            model.end_date = purchase.end_date;
            model.status = purchase.status;

            await _context.Purchases.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<Purchase> Update(int id, UpdatePurchaseViewModel purchase)
        {
            Purchase model = await GetPurchaseAsync(id);
            if (model != null)
            {
                model.plan_id = purchase.plan_id;
                model.detail_id = purchase.detail_id;
                model.DOP = purchase.DOP;
                model.end_date = purchase.end_date;
                model.status = purchase.status;

                await _context.Purchases.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else return null;
            
        }
    }
}
