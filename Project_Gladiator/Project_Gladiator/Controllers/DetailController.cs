using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Gladiator.Repositery;
using Project_Gladiator.UpdateViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Controller for Details Table 
//It will only call the method which are defined in the DetailRepositery.cs and IDetailRepositery.cs

namespace Project_Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private IDetailsRepositery _detailRepo;
        public DetailController(IDetailsRepositery detailRepo)
        {
            _detailRepo = detailRepo;//Initialising the Repositery
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllDetails()//This method will fetch all details from the details table.
        {
            return Ok(await _detailRepo.GetAllDetailsAsync());//Calling the method which is defined in the Repo
        }

        [Route("[action]/{Id:int}")]
        //This method will receive Id from the front-end
        public async Task<IActionResult> GetDetail(int id)//This method will fetch the specific detail by Id from the details table
        {
            return Ok(await _detailRepo.GetDetailAsync(id));//Calling the method which is defined in the Repo
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UpdateDetailViewModel model)//This method will insert new detail in the details table.
        {
            if (ModelState.IsValid)
            {

                var detail = await _detailRepo.Register(model);//Calling the method which is defined in the Repo
                return Ok(detail);
            }
            else return NotFound("Detail not created");//Inserting failed
        }
        [Route("[action]/{Id:int}")]
        //This will receive Id from the front-end
        [HttpPut]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateDetailViewModel model)//This method will update Detail by Id
        {
            if (ModelState.IsValid)
            {
                var detail = await _detailRepo.Update(id,model);//Calling the method which is defined in the Repo
                if (detail != null) return Ok(detail);//If that exists
                else return NotFound("Detail is not in database");//Not exists in the table
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("[action]/{Id:int}")]
        //This method will get Id from the front-end
        public async Task<IActionResult> DeleteDetail([FromRoute] int id)//It will delete the specific detail by Id from the database.
        {
            if (await _detailRepo.Exists(id))
            {
                var deletedDetail = await _detailRepo.Delete(id);//Calling the method which is defined in the Repo
                return Ok(deletedDetail);
            }
            return BadRequest();
        }
    }
}
