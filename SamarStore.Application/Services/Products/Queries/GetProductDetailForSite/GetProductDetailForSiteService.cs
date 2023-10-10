using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetProductDetailForSite
{
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

			product.ViewCount++;
			_context.SaveChanges();
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



}
