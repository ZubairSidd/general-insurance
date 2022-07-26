using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class PurchaseRepositery:IPurchaseRepositery
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
    }
}
