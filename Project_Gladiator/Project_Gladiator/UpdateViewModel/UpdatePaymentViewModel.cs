using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//This will be used only for inserting new row or updating the existing row


namespace Project_Gladiator.UpdateViewModel
{
    public class UpdatePaymentViewModel
    {
        public int user_id { get; set; }
        public DateTime date { get; set; }
        public int purchase_id { get; set; }
    }
}
