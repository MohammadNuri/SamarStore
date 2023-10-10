using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.ViewComponents
{
	
	public class Search : ViewComponent 
	{
		private readonly IProductFacadForSite _productFacadForSite;
        public Search(IProductFacadForSite productFacadForSite)
        {
            _productFacadForSite = productFacadForSite; 
        }

        public IViewComponentResult Invoke()
        {
            return View(viewName:"Search", _productFacadForSite.GetCategoriesService.Execute().Data);  
        }
    }
}
