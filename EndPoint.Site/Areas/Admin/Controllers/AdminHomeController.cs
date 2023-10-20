using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
