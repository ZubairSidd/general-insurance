using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//It will commnunicate with the database through dbcontext
//Contains all the definition of the methods which are declared in its interface


namespace Project_Gladiator.Repositery
{
    public class PurchaseRepositery : IPurchaseRepositery
    {
        private readonly ApplicationDbContext _context;
        public PurchaseRepositery(ApplicationDbContext context)
        {
            _context = context;//Initialising the database context
        }
        public async Task<List<Purchase>> GetAllPurchasesAsync()//Definition for fetching all the purchase from the database
        {
            return await _context.Purchases.ToListAsync();
        }
        public async Task<Purchase> GetPurchaseAsync(int id)//Definition for fetching the sepefic purchase from the database
        {
            return await _context.Purchases.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<Purchase> Register(UpdatePurchaseViewModel purchase)//Definition for inserting new purchase into the database
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
        public async Task<Purchase> Update(int id, UpdatePurchaseViewModel purchase)//Definition for updating the purchase in  the database
        {
            Purchase model = await GetPurchaseAsync(id);
            if (model != null)
            {
                model.plan_id = purchase.plan_id;
                model.detail_id = purchase.detail_id;
                model.DOP = purchase.DOP;
                model.end_date = purchase.end_date;
                model.status = purchase.status;

                 _context.Purchases.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else return null;            
        }
        public async Task<bool> Exists(int id)//Definition for check whether the specific purchase exists in the database
        {
            return await _context.Purchases.AnyAsync(x => x.id == id);
        }
        public async Task<Purchase> Delete(int id)
        {
            var purchase = await this.GetPurchaseAsync(id);
            if (purchase != null)
            {
                _context.Purchases.Remove(purchase);
                await _context.SaveChangesAsync();
                return purchase;
            }
            return null;
        }
    }
}
