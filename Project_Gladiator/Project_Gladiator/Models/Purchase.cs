using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Models
{
    public class Purchase
    {
        [Key]
        public int id { get; set; }
        public int plan_id { get; set; }
        public int user_id { get; set; }
        public DateTime DOP { get; set; }
        public DateTime end_date { get; set; }
    }
}
