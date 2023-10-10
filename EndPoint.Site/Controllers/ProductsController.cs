using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;
using System.Drawing.Printing;

namespace EndPoint.Site.Controllers
{
	public class ProductsController : Controller
	{
		private IProductFacadForSite _productFacadForSite;

		public ProductsController(IProductFacadForSite productFacadForSite)
		{
			_productFacadForSite = productFacadForSite;
		}
		public IActionResult Index(string? searchKey, long? catId, int page = 1, int pageSize = 20)
		{
            if (string.IsNullOrEmpty(searchKey) || string.IsNullOrWhiteSpace(searchKey))
            {
                return View(_productFacadForSite.GetProductForSiteService.Execute(searchKey, catId, page, pageSize).Data);
            }
			searchKey = searchKey.Trim();
            return View(_productFacadForSite.GetProductForSiteService.Execute(searchKey, catId, page, pageSize).Data);
        }
        
		public IActionResult Detail(long id)
		{
			return View(_productFacadForSite.GetProductDetailForSiteService.Execute(id).Data);
		}
	}
}
