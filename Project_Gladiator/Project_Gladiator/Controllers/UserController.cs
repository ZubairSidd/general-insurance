using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Models;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



//Controller for Users Table 
//It will only call the method which are defined in the UserRepositery.cs and IUserRepositery.cs


namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepositery _userRepo;
        public UserController(IUserRepositery userRepo)
        {
            _userRepo = userRepo;//Initialing the Repositery
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllUsers()//It will fetch all the users from the database
        {

            return Ok(await _userRepo.GetAllUsersAsync());//Calling the method defined in the repo
        }
        
        [Route("[action]/{Id:int}")]
        //It will receive the Id from the front-end
        public async Task<IActionResult> GetUserById(int id)//It will fetch the specific user from the database
        {
            User user = await _userRepo.GetUserAsync(id);//Calling the method defined in the repo
            if (user != null) return Ok(user);
            else return NotFound();//User doesn't exist
        }
        
        [Route("[action]")]
        [HttpPost]
        //It will return the user if it exists in the database by receiving the login details
        public async Task<IActionResult> Login([FromBody]Login login)
        {
            var u = await _userRepo.GetByEmailAndPassword(login.email, login.password);//Calling the method defined in the repo
            if (u == null) return NotFound();
            return Ok(u);
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UpdateUserViewModel user)//It will insert new user in the database
        {
            if (await _userRepo.UserByEmail(user.email))//Calling the method defined in the repo
                return BadRequest("This email already Exists");
            var registeredUser = await _userRepo.Create(user);//Calling the method defined in the repo
            if (registeredUser!= null)
                return Ok(registeredUser);
            return NotFound("User not created");
        }
        [Route("[action]/{Id:int}")]
        //It will receive the Id from the front-end
        [HttpPut]
        //It will update the user by id in the database if it exists
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var registeredUser = await _userRepo.Update(id, user);//Calling the method defined in the repo
                if (registeredUser != null)
                    return Ok(registeredUser);
                else return NotFound("User is not in database");//User doesn't exist
            }
            else return BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{Id:int}")]
        //It will receive the Id from the front-end
        public async Task<IActionResult> DeleteUser([FromRoute] int id)//It will delete the user from the databae if it exists
        {
            if (await _userRepo.Exists(id))//Cheking if it exists
            {
                var deletedUser = await _userRepo.Delete(id);//Calling the method defined in the repo
                return Ok(deletedUser);
            }
            return BadRequest("User not in the database");//User not in the database
        }
        [HttpPut]
        [Route("[action]")]
        //If user fortget his password then  this method will be called
        //It will receive the forgotpass details which contain email and new password that the user wants
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPass fp)
        {
            if(!await _userRepo.UserByEmail(fp.email))//Checking if that email exists
            {
                return BadRequest("Email doesn't not exist");
            }
            else
            {
                User u = await _userRepo.ForgotPassword(fp.email, fp.pass);//Calling the method defiend in the repo
                return Ok(u);
            }
        }
    }

}
