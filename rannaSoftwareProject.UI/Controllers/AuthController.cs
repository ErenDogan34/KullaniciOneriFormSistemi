using Microsoft.AspNetCore.Mvc;

namespace rannaSoftwareProject.UI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
    }
}
