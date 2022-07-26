﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Models
{
    public class Renewal
    {
        [Key]
        public int renew_id { get; set; }
        public int user_id { get; set; }
        public int purchase_id { get; set; }
    }
}