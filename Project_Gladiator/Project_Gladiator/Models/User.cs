using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



//Mathching field names are declared here 
//This will communicate through appdbcontext with the ms-sql database

namespace Project_Gladiator.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set;}
        public string password { get; set; }
        public DateTime dob { get; set; }
        public string conf_password { get; set; }
    }
}
