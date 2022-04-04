using Microsoft.AspNetCore.Mvc;

namespace OmniVusWebApp.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
