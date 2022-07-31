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
        public async Task<Detail> Register(UpdateDetailViewModel detail)
        {
            Detail model = new Detail();
            model.user_id = detail.user_id;
            model.manufacturer=detail.manufacturer;
            model.purchase_date=detail.purchase_date;
            model.model = detail.model;
            model.reg_number=detail.reg_number;
            model.engine_number=detail.engine_number;
            model.driving_license=detail.driving_license;
            model.chasis_number=detail.chasis_number;
            model.address = detail.address;
            model.type=detail.type;
            await _context.Details.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }
        public async Task<Detail> Update(int id, UpdateDetailViewModel detail)
        {
            Detail model = await GetDetailAsync(id);
            if (model != null)
            {
                model.user_id = detail.user_id;
                model.manufacturer = detail.manufacturer;
                model.purchase_date = detail.purchase_date;
                model.model = detail.model;
                model.reg_number = detail.reg_number;
                model.engine_number = detail.engine_number;
                model.driving_license = detail.driving_license;
                model.chasis_number = detail.chasis_number;
                model.address = detail.address;
                model.type = detail.type;
                _context.Details.Update(model);
                await _context.SaveChangesAsync();
                return model;
            }
            else return null;
        }
    }
}
