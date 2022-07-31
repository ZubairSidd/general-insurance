using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class DetailController : ControllerBase
    {
        private IDetailsRepositery _detailRepo;
        public DetailController(IDetailsRepositery detailRepo)
        {
            _detailRepo = detailRepo;
        }
        [Route("[action]")]
        public async Task<IActionResult> GetAllDetails()
        {
            return Ok(await _detailRepo.GetAllDetailsAsync());
        }

        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            return Ok(await _detailRepo.GetDetailAsync(id));
        }
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] UpdateDetailViewModel model)
        {
            if (ModelState.IsValid)
            {

                var detail = await _detailRepo.Register(model);
                return Ok(detail);
            }
            else return NotFound("Detail not created");
        }
        [Route("[action]/{Id:int}")]
        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] UpdateDetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var detail = await _detailRepo.Update(id,model);
                if (detail != null) return Ok(detail);
                else return NotFound("Detail is not in database");
            }
            else return NotFound("Detail not created");
        }
    }
}
