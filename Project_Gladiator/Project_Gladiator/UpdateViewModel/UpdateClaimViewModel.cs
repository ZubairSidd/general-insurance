using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.UpdateViewModel
{
    public class UpdateClaimViewModel
    {
        public int user_id { get; set; }
        public int plan_id { get; set; }
        public DateTime date { get; set; }
        public string reason { get; set; }
        public decimal amount { get; set; }
        public int status { get; set; }
    }
}
