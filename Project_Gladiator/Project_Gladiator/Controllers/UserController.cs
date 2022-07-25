using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepositery _userRepo;
        public UserController(IUserRepositery userRepo)
        {
            _userRepo = userRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userRepo.GetAllUsersAsync());
        }

        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return Ok(await _userRepo.GetUserAsync(id));
        }
    }

}
