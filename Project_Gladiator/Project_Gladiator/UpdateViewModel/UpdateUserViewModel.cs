using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//This will be used only for inserting new row or updating the existing row


namespace Project_Gladiator.UpdateViewModel
{
    public class UpdateUserViewModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime dob { get; set; }
        public string conf_password { get; set; }
    }
}
