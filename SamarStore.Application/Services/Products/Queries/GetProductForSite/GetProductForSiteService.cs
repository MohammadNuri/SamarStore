using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetProductForSite;

public class GetProductForSiteService : IGetProductForSiteService
{
    private readonly IDataBaseContext _context;

    public GetProductForSiteService(IDataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }
    public ResultDto<ResultProductForSiteDto> Execute(string? searchKey, long? catId, int page)
    {
        int totalRow = 0;
        var productQuery = _context.Products
            .Include(p => p.ProductImages).AsQueryable();

          if(catId != null)
        {
			productQuery = productQuery.Where(p => p.CategoryId == catId || p.Category.ParentCategoryId == catId).AsQueryable();    

		}
        if (!string.IsNullOrEmpty(searchKey))
        {
            productQuery = productQuery.Where(p => p.Name.Contains(searchKey) || p.Brand.Contains(searchKey)).AsQueryable();
        }

          var product = productQuery.ToPaged(page, 10, out totalRow);

        Random rd = new Random();

        return new ResultDto<ResultProductForSiteDto>()
        {
            Data = new ResultProductForSiteDto
            {
                TotalRow = totalRow,
                Products = product.Select(p => new ProductForSiteDto
                {
                    Id = p.Id,
                    Star = rd.Next(1, 5),
                    Title = p.Name,
                    ImageSrc = p.ProductImages.FirstOrDefault().Src,
                    Price = p.Price
                }).ToList(),
            },
            IsSuccess = true,
        };
        
    }
}