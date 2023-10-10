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
		public IActionResult Index(string? searchKey,long? catId, int page = 1)
		{
            if (string.IsNullOrEmpty(searchKey) || string.IsNullOrWhiteSpace(searchKey))
            {
                return View(_productFacadForSite.GetProductForSiteService.Execute(searchKey, catId, page).Data);
            }

            searchKey = searchKey.Trim();
            return View(_productFacadForSite.GetProductForSiteService.Execute(searchKey, catId, page).Data);
        }
        
		public IActionResult Detail(long id)
		{
			return View(_productFacadForSite.GetProductDetailForSiteService.Execute(id).Data);
		}
	}
}
