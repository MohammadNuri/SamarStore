using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetProductDetailForSite
{
	public interface IGetProductDetailForSiteService
	{
		ResultDto<ProductDetailForSiteDto> Execute(long Id);
	}

	public class ProductDetailForSite_FeatureDto
	{
		public string DisplayName { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;

	}



}
