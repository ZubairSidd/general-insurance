using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
