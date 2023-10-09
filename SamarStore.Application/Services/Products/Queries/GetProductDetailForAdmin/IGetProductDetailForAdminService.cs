using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetProductDetailForAdmin
{
    public interface IGetProductDetailForAdminService
    {
        ResultDto<ProductDetailForAdminDto> Execute(long Id);
    }
}
