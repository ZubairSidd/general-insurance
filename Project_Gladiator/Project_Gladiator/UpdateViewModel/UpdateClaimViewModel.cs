using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//This will be used only for inserting new row or updating the existing row

namespace Project_Gladiator.UpdateViewModel
{
    public class UpdateClaimViewModel
    {
        public int user_id { get; set; }
        public int pay_id { get; set; }
        public DateTime date { get; set; }
        public string reason { get; set; }
        public decimal amount { get; set; }
        public int status { get; set; }
    }
}
