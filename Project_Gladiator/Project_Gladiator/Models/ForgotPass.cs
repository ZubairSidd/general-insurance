using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Email and new Password are declared here
//It will serve as the class for updating password of the user if he forgets
namespace Project_Gladiator.Models
{
    public class ForgotPass
    {
        public string email { get; set; }
        public string pass { get; set; }
    }
}
