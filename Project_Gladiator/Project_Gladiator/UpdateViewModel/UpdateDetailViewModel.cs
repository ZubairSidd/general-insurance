using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.UpdateViewModel
{
    public class UpdateDetailViewModel
    {
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
