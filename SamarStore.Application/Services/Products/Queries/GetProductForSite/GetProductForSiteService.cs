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
    public ResultDto<ResultProductForSiteDto> Execute(int page)
    {
        int totalRow = 0;
        var products = _context.Products
            .Include(p => p.ProductImages)
            .ToPaged(page, 10, out totalRow);

        Random rd = new Random();

        return new ResultDto<ResultProductForSiteDto>()
        {
            Data = new ResultProductForSiteDto
            {
                TotalRow = totalRow,
                Products = products.Select(p => new ProductForSiteDto
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