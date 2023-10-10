using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetAllCategories
{

    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }

}

