using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;




//Mathching field names are declared here 
//This will communicate through appdbcontext with the ms-sql database
namespace Project_Gladiator.Models
{
    public class Detail
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public DateTime purchase_date { get; set; }
        public string reg_number { get; set; }
        public int engine_number { get; set; }
        public string driving_license { get; set; }
        public string chasis_number { get; set; }
        public string address { get; set; }
        public string type { get; set; }
    }
}
