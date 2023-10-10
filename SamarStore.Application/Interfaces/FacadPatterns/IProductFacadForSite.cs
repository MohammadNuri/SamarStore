using SamarStore.Application.Services.Products.Queries.GetProductDetailForSite;
using SamarStore.Application.Services.Products.Queries.GetProductForSite;

namespace SamarStore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacadForSite
    {
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; } 
	}
}
