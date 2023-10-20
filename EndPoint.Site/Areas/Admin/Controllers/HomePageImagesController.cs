using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.HomePage.Commands.AddHomePageImage;
using SamarStore.Application.Services.Products.Commands.AddNewProduct;
using SamarStore.Domain.Entities.HomePage;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageImagesController : Controller
    {
        private readonly IHomePageFacad _homePageFacad;
        public HomePageImagesController(IHomePageFacad homePageFacad)
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
        public IActionResult Add(IFormFile file, string link, ImageLocation imageLocation)
        {
            _homePageFacad.AddHomePageImageService.Execute(new requestAddHomePageImagesDto
            {
                ImageLocation = imageLocation,
                Link = link,    
                File = file 
            });

            return View();
        }

    }
}
