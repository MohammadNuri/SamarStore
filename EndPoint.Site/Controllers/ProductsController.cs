using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.Controllers
{
	public class ProductsController : Controller
	{
		private IProductFacadForSite _productFacadForSite;

        public ProductsController(IProductFacadForSite productFacadForSite)
        {
            _productFacadForSite = productFacadForSite;	
        }
		public IActionResult Index(int page = 1)
		{
			return View(_productFacadForSite.GetProductForSiteService.Execute(page).Data);
		}
	}
}
