using EndPoint.Site.Models;
using EndPoint.Site.Models.HomePage;
using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Products.Queries.GetProductForSite;
using System.Diagnostics;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageFacad _homePageFadac;
        private readonly IProductFacadForSite _productFacadForSite;

        public HomeController(ILogger<HomeController> logger, IHomePageFacad homePageFacad, IProductFacadForSite productFacadForSite)
        {
            _logger = logger;
            _homePageFadac = homePageFacad;
            _productFacadForSite = productFacadForSite;   
        }

        public IActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel()
            {
                Sliders = _homePageFadac.GetSliderService.Execute().Data,
                HomePageImages = _homePageFadac.GetHomePageImagesService.Execute().Data,
                Camera = _productFacadForSite.GetProductForSiteService.Execute(Ordering.theNewest,null,3,1,6).Data.Products // Getting 6 Products from your selected Category ID that is 3 here
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}