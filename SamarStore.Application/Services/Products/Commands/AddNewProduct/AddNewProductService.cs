using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Services.Common;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.Products;

namespace SamarStore.Application.Services.Products.Commands.AddNewProduct;

public class AddNewProductService : IAddNewProductService
{
    private readonly IDataBaseContext _context;

    public AddNewProductService(IDataBaseContext context)
    {
        _context = context;
    }
    public ResultDto Execute(RequestAddNewProductDto request)
    {

        try
        {

            var category = _context.Categories.Find(request.CategoryId);
            if (category == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "دسته بندی پیدا نشد",
                };
            }

            Product product = new Product()
            {
                Brand = request.Brand,
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                Inventory = request.Inventory,
                Category = category,
                Displayed = request.Displayed,
            };

            _context.Products.Add(product);

            var uploadFileService = new UploadFileService("wwwroot/images/ProductImages");
            var uploadedResults = uploadFileService.UploadFiles(request.Images);

            // Add the product images
            var productImages = new List<ProductImages>();
            foreach (var uploadedResult in uploadedResults)
            {
                productImages.Add(new ProductImages
                {
                    Product = product,
                    Src = uploadedResult.FileNameAddress
                });
            }

            _context.ProductImages.AddRange(productImages);


            List<ProductFeatures> productFeatures = new List<ProductFeatures>();
            foreach (var item in request.Features)
            {
                productFeatures.Add(new ProductFeatures
                {
                    DisplayName = item.DisplayName,
                    Value = item.Value,
                    Product = product,
                });
            }
            _context.ProductFeatures.AddRange(productFeatures);

            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "محصول با موفقیت به محصولات فروشگاه اضافه شد",
            };
        }
        catch (Exception)
        {

            return new ResultDto
            {
                IsSuccess = false,
                Message = "خطا رخ داد ",
            };
        }

    }
}