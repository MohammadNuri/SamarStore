using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Products.Commands.AddNewCategory;
using SamarStore.Application.Services.Products.Queries.GetCategories;
using Microsoft.AspNetCore.Hosting;
using SamarStore.Application.Services.Products.Commands.AddNewProduct;
using SamarStore.Application.Services.Products.Queries.GetAllCategories;
using SamarStore.Application.Services.Products.Queries.GetProductForAdmin;

namespace SamarStore.Application.Services.Products.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        //--Inject DataBase
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            hostingEnvironment = _environment;
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
                return _addNewProduct = _addNewProduct ?? new AddNewProductService(_context, _environment);
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
    }
    
}
