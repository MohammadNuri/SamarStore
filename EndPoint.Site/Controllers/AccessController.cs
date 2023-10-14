using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View("AccessDenied"); // Matches the name of your custom view
        }
    }
}
