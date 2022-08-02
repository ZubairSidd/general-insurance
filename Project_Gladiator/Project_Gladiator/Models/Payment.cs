using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


//Mathching field names are declared here 
//This will communicate through appdbcontext with the ms-sql database

namespace Project_Gladiator.Models
{
    public class Payment
    {
        [Key]
        public int pay_id { get; set; }
        public int user_id { get; set; }
        public DateTime date { get; set; }
        public int purchase_id { get; set; }
    }
}
