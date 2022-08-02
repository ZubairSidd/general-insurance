using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//This will be used only for inserting new row or updating the existing row


namespace Project_Gladiator.UpdateViewModel
{
    public class UpdatePlanViewModel
    {
        public string type { get; set; }
        public int plan_details { get; set; }
        public decimal amount { get; set; }
        public int policy_number { get; set; }
    }
}
