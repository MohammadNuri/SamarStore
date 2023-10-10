using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Products.Commands.AddNewCategory;
using SamarStore.Application.Services.Products.Queries.GetCategories;
using SamarStore.Application.Services.Products.Commands.AddNewProduct;
using SamarStore.Application.Services.Products.Queries.GetAllCategories;
using SamarStore.Application.Services.Products.Queries.GetProductForAdmin;
using SamarStore.Application.Services.Products.Queries.GetProductDetailForAdmin;
using SamarStore.Application.Services.Products.Commands.RemoveCategory;

namespace SamarStore.Application.Services.Products.FacadPattern
{
	public class ProductFacad : IProductFacad
    {
        //--Inject DataBase
        private readonly IDataBaseContext _context;
        public ProductFacad(IDataBaseContext context)
        {
            _context = context;
        }

        //--Inject AddNewCategoryService
        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }

        //--Inject GetCategoryService
        private IGetCategoryService _getCategory;
        public IGetCategoryService GetCategoryService
        {
            get
            {
                return _getCategory = _getCategory ?? new GetCategoryService(_context);   
            }
        }

        private AddNewProductService _addNewProduct;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _addNewProduct = _addNewProduct ?? new AddNewProductService(_context);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }
        private IGetProductForAdminService _getProductForAdmin;

        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdmin = _getProductForAdmin ?? new GetProductForAdminService(_context);    
            }
        }
        private IGetProductDetailForAdminService _getProductDetailForAdmin;

        public IGetProductDetailForAdminService GetProductDetailForAdminService
        {
            get
            {
                return _getProductDetailForAdmin = _getProductDetailForAdmin ?? new GetProductDetailForAdminService(_context);  
            }
        }
        private IRemoveCategoryService _removeCategoryService;
        public IRemoveCategoryService RemoveCategoryService
        {
            get
            {
                return _removeCategoryService = _removeCategoryService ?? new RemoveCategoryService(_context);
            }
        }
    }
    
}
