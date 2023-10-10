using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetCategories
{
	public interface IGetCategoryService
    {
        ResultDto<List<CategoriesDto>> Execute(long? parentId);
    }
}
