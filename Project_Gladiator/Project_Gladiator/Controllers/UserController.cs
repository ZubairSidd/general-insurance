using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Models;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
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
            User user = await _userRepo.GetUserAsync(id);
            if (user != null) return Ok(User);
            else return NotFound();
        }
        
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            var u = await _userRepo.GetByEmailAndPassword(login.email, login.password);
            if (u == null) return NotFound();
            return Ok(u);
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UpdateUserViewModel user)
        {
            if (ModelState.IsValid)
            {

                var registeredUser = await _userRepo.Create(user);
                return Ok(registeredUser);
            }
            else return NotFound("User not created");
        }

    }

}
