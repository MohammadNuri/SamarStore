using SamarStore.Application.Services.Common.Queries.GetCategories;
using SamarStore.Application.Services.Common.Queries.GetMenuItem;
using SamarStore.Application.Services.Products.Queries.GetProductDetailForSite;
using SamarStore.Application.Services.Products.Queries.GetProductForSite;

namespace SamarStore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacadForSite
    {
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
        IGetMenuItemService GetMenuItemService { get; }
		IGetCategoriesService GetCategoriesService { get; }
	}
}
