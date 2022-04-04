using Microsoft.AspNetCore.Mvc;

namespace OmniVusWebApp.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
