using Microsoft.AspNetCore.Mvc;

namespace OmniVusWebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
