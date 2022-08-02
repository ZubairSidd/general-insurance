using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


//Mathching field names are declared here 
//This will communicate through appdbcontext with the ms-sql database
namespace Project_Gladiator.Models
{
    public class Claim
    {
        [Key]
        public int claim_no { get; set; }
        public int user_id { get; set; }
        public int pay_id { get; set; }
        public DateTime date { get; set; }
        public string reason { get; set; }
        public decimal amount { get; set; }
        public int status { get; set; }
    }
}
