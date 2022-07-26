﻿using Project_Gladiator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Repositery
{
    public interface IPlanRepositery
    {
        Task<List<Plan>> GetAllPlansAsync();
        Task<Plan> GetPlanAsync(int id);
    }
}
