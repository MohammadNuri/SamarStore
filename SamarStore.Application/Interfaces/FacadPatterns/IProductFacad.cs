using SamarStore.Application.Services.Products.Commands.AddNewCategory;
using SamarStore.Application.Services.Products.Commands.AddNewProduct;
using SamarStore.Application.Services.Products.Queries.GetCategories;
using SamarStore.Application.Services.Products.Queries.GetAllCategories;
using SamarStore.Application.Services.Products.Queries.GetProductDetailForAdmin;
using SamarStore.Application.Services.Products.Queries.GetProductForAdmin;
using SamarStore.Application.Services.Products.Commands.RemoveCategory;

namespace SamarStore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoryService GetCategoryService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IRemoveCategoryService RemoveCategoryService { get; }
        //<summary>
        //Getting List Of Products 
        //</summary>
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }   


    }
}
