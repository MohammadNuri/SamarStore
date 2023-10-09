using SamarStore.Application.Services.Products.Commands.AddNewCategory;
using SamarStore.Application.Services.Products.Commands.AddNewProduct;
using SamarStore.Application.Services.Products.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamarStore.Application.Services.Products.Queries.GetAllCategories;
using SamarStore.Application.Services.Products.Queries.GetProductForAdmin;

namespace SamarStore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoryService GetCategoryService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        //<summary>
        //Getting List Of Products 
        //</summary>
        IGetProductForAdminService GetProductForAdminService { get; }
    }
}
