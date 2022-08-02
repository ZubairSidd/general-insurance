using Microsoft.EntityFrameworkCore;
using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//This is the master database
//It contains all the tables exists in the ms-sql database
//It will serve as the database for this applicatoin everywhere
//It will communicate with the ms-sql database

namespace Project_Gladiator.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }

        //All the tables declared here


        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Detail>Details { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Renewal> Renewals { get; set; }

        public DbSet<Purchase> Purchases { get; set; }
    }
}
