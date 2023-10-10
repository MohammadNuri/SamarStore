using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenuTiny : ViewComponent
    {
        private readonly IProductFacadForSite _productFacadForSite;
        public GetMenuTiny(IProductFacadForSite productFacadForSite)
        {
            _productFacadForSite = productFacadForSite;
        }

        public IViewComponentResult Invoke()
        {
            var menuItem = _productFacadForSite.GetMenuItemService.Execute();

            return View(viewName: "GetMenuTiny", menuItem.Data);
        }

    }
}
