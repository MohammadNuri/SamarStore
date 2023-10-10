using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;

namespace EndPoint.Site.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IProductFacadForSite _productFacadForSite;
        public GetMenu(IProductFacadForSite productFacadForSite)
        {
            _productFacadForSite = productFacadForSite;
        }

        public IViewComponentResult Invoke()
        {
            var menuItem = _productFacadForSite.GetMenuItemService.Execute();

            return View(viewName: "GetMenu", menuItem.Data);
        }

    }
}
