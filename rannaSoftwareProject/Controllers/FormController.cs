using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rannaSoftwareProject.Business.Abstract;
using rannaSoftwareProject.Data.Entities;

namespace rannaSoftwareProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormBusinessService formBusinessService;
       

        public FormController(IFormBusinessService formBusinessService)
        {
            this.formBusinessService = formBusinessService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllForm()
        {
            var form=await formBusinessService.FormGetAllAsync();
            return Ok(form);
        }
        [HttpPost]
        [Authorize(Roles = "User")]

        public async Task<IActionResult> AddForm(SupportForm supportForm)
        {
            await formBusinessService.FormAddAsync(supportForm);
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteForm(int id)
        {
            var result=await formBusinessService.FormDeleteAsync(id);
            if(result==false)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FormProcessed(int id)
        {
            await formBusinessService.CheckForm(id);
            return Ok();
        }
    }
}
