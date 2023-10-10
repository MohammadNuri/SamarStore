using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Products.Queries.GetProductDetailForSite;
using SamarStore.Application.Services.Products.Queries.GetProductForSite;

namespace SamarStore.Application.Services.Products.FacadPattern
{
    public class ProductFacadForSite : IProductFacadForSite
    {
        private readonly IDataBaseContext _context;

        public ProductFacadForSite(IDataBaseContext dataBaseContext)
        {
            _context = dataBaseContext; 
        }

        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
	        get
	        {
		        return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
			}
        }
    }
}
