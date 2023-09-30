using SamarStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.Product.Queries.GetCategories
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoriesDto>> Execute(long? parentId);
    }
}
