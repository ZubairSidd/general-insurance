using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Detail>Details { get; set; }
        public DbSet<Plan_Details> Plans { get; set; }
        public DbSet<Renewal> Renewals { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
