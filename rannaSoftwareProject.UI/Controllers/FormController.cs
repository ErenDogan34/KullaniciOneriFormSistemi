using Microsoft.AspNetCore.Mvc;

namespace rannaSoftwareProject.UI.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllForm()
        {
            return View();
        }
    }
}
