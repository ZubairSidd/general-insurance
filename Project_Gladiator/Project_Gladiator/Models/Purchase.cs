using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



//Mathching field names are declared here 
//This will communicate through appdbcontext with the ms-sql database

namespace Project_Gladiator.Models
{
    public class Purchase
    {
        [Key]
        public int id { get; set; }
        public int plan_id { get; set; }
        public int detail_id { get; set; }
        public DateTime DOP { get; set; }
        public DateTime end_date { get; set; }
        public int status { get; set; }
    }
}
