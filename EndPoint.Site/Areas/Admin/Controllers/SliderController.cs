using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly IHomePageFacad _homePageFacad;
        public SliderController(IHomePageFacad homePageFacad)
        {
            _homePageFacad = homePageFacad;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Add(IFormFile file,string? link)
        {

            _homePageFacad.AddNewSliderService.Execute(file, link);

            return View();
        }

    }
}
