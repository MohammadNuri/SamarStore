using SamarStore.Application.Services.Product.Commands.AddNewCategory;
using SamarStore.Application.Services.Product.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        IAddNewCategoryService AddNewCategoryService { get; }
        IGetCategoryService GetCategoryService { get; } 
    }
}
