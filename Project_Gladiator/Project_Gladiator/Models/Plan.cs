using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



//Mathching field names are declared here 
//This will communicate through appdbcontext with the ms-sql database

namespace Project_Gladiator.Models
{
    public class Plan
    {
        [Key]
        public int plan_id { get; set; }
        public string type { get; set; }
        public int plan_details { get; set; }
        public decimal amount { get; set; }
        public int policy_number { get; set; }
    }
}
