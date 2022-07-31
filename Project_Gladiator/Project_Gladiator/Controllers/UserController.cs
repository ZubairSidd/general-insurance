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
        public async Task<IActionResult> GetUserById(int id)
        {
            User user = await _userRepo.GetUserAsync(id);
            if (user != null) return Ok(user);
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
            if (await _userRepo.UserByEmail(user.email))
                return BadRequest("This email already Exists");
            var registeredUser = await _userRepo.Create(user);
            if(registeredUser!= null)
                return Ok(registeredUser);
            return NotFound("User not created");
        }
        [Route("[action]/{Id:int}")]
        [HttpPost]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var registeredUser = await _userRepo.Update(id, user);
                if (registeredUser != null)
                    return Ok(registeredUser);
                else return NotFound("User is not in database");
            }
            else return NotFound("User not created");
        }
        [HttpDelete]
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (await _userRepo.Exists(id))
            {
                var deletedUser = await _userRepo.Delete(id);
                return Ok(deletedUser);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPass fp)
        {
            if(!await _userRepo.UserByEmail(fp.email))
            {
                return BadRequest("Email doesn't not exist");
            }
            else
            {
                User u = await _userRepo.ForgotPassword(fp.email, fp.pass);
                return Ok(u);
            }
        }
    }

}
