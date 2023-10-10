using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetProductDetailForSite
{
	public interface IGetProductDetailForSiteService
	{
		ResultDto<ProductDetailForSiteDto> Execute(long Id);
	}

	public class GetProductDetailForSiteService : IGetProductDetailForSiteService
	{
		private readonly IDataBaseContext _context;

		public GetProductDetailForSiteService(IDataBaseContext dataBaseContext)
		{
			_context = dataBaseContext;	
		}
		public ResultDto<ProductDetailForSiteDto> Execute(long Id)
		{
			var product = _context.Products
				.Include(p => p.Category)
				.ThenInclude(p => p.ParentCategory)
				.Include(p => p.ProductImages)
				.Include(p => p.ProductFeatures)
				.FirstOrDefault(p => p.Id == Id);

			if (product == null)
			{
				throw new Exception("محصول پیدا نشد!");
			}

			return new ResultDto<ProductDetailForSiteDto>()
			{
				Data = new ProductDetailForSiteDto
				{
					Title = product.Name,
					Brand = product.Brand,
					Category = $"{product.Category.ParentCategory.Name} - {product.Category.Name}",
					Description = product.Description,
					Id = product.Id,
					Price = product.Price,
					Images = product.ProductImages.Select(p => p.Src).ToList(),
					Feature = product.ProductFeatures.Select(p => new ProductDetailForSite_FeatureDto()
					{
						DisplayName = p.DisplayName,
						Value = p.Value
					}).ToList(),

				},
				IsSuccess = true
			};
		}
	}



	public class ProductDetailForSiteDto
	{
		public long Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Brand { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;	
		public int Price { get; set; }	
		public List<string> Images { get; set; }
		public List<ProductDetailForSite_FeatureDto> Feature { get; set; }	

	}

	public class ProductDetailForSite_FeatureDto
	{
		public string DisplayName { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;

	}



}
