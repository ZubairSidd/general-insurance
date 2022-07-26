using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Data;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public class DetailsRepositery:IDetailsRepositery
    {
        private readonly ApplicationDbContext _context;
        public DetailsRepositery(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Detail>> GetAllDetailsAsync()
        {
            return await _context.Details.ToListAsync();
        }
        public async Task<Detail> GetDetailAsync(int id)
        {
            return await _context.Details.Where(x => x.id == id).FirstOrDefaultAsync();
        }
    }
}
