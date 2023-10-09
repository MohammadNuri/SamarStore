using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Queries.GetProductForAdmin;

public class GetProductForAdminService : IGetProductForAdminService
{
    private readonly IDataBaseContext _context;
    public GetProductForAdminService(IDataBaseContext context)
    {
        _context = context;
    }

    public ResultDto<ProductForAdminDto> Execute(int Page = 1, int PageSize = 20)
    {
        int rowCount = 0;

        var products = _context.Products
            .Include(p => p.Category)
            .ToPaged(Page, PageSize, out rowCount)
            .Select(p => new ProductsForAdminList_Dto
            {
                Id = p.Id,
                Brand = p.Brand,
                Category = p.Category.Name,
                Description = p.Description,
                Displayed = p.Displayed,
                Inventory = p.Inventory,
                Name = p.Name,
                Price = p.Price,
            }).ToList();

        return new ResultDto<ProductForAdminDto>()
        {
            Data = new ProductForAdminDto()
            {
                Products = products,
                CurrentPage = Page,
                PageSize = PageSize,
                RowCount = rowCount
            },
            IsSuccess = true,
            Message = "",
        };
    }
}