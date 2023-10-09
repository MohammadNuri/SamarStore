using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.Products;

namespace SamarStore.Application.Services.Products.Commands.AddNewProduct;

public class AddNewProductService : IAddNewProductService
{
    private readonly IDataBaseContext _context;
    private readonly IHostingEnvironment _environment;

    public AddNewProductService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
    {
        _context = context;
        _environment = hostingEnvironment;
    }
    public ResultDto Execute(RequestAddNewProductDto request)
    {

        try
        {

            var category = _context.Categories.Find(request.CategoryId);

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

            //List<ProductImages> productImages = new List<ProductImages>();
            //foreach (var item in request.Images)
            //{
            //    var uploadedResult = UploadFile(item);
            //    productImages.Add(new ProductImages
            //    {
            //        Product = product,
            //        Src = uploadedResult.FileNameAddress,
            //    });
            //}

            var uploadedResults = UploadFiles(request.Images);

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
        catch (Exception ex)
        {

            return new ResultDto
            {
                IsSuccess = false,
                Message = "خطا رخ داد ",
            };
        }

    }

    public List<UploadDto> UploadFiles(List<IFormFile> files)
    {
        var uploadedResults = new List<UploadDto>();

        foreach (var file in files)
        {
            var uploadedResult = UploadFile(file);
            uploadedResults.Add(uploadedResult);
        }

        return uploadedResults;
    }

    private UploadDto UploadFile(IFormFile file)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "wwwroot/images/ProductImages");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (file != null && file.Length > 0)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(path, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            var relativePath = filePath.Replace(Environment.CurrentDirectory, string.Empty)
                .Replace("wwwroot/", string.Empty)
                .TrimStart(Path.DirectorySeparatorChar);

            return new UploadDto
            {
                FileNameAddress = relativePath,
                Status = true
            };
        }

        return null;
    }
}







//public UploadDto UploadFile(List<IFormFile> files)
//{



//    string path = string.Empty;


//    if (files == null || files.Count == 0)
//    {
//        return null;
//    }

//    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot/images/ProductImages"));
//    if (!Directory.Exists(path))
//    {
//        Directory.CreateDirectory(path);
//    }

//    foreach (var file in files)
//    {
//        if (file.Length > 0)
//        {
//            using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
//            {
//                file.CopyTo(fileStream);
//            }
//        }
//    }

//    return null;


//if (file != null)
//{
//    string folder = $@"\images\ProductImages\";

//    var uploadsRootFolder = Path.Combine(Environment.CurrentDirectory, folder);

//    if (!Directory.Exists(uploadsRootFolder))
//    {
//        Directory.CreateDirectory(uploadsRootFolder);
//    }


//if (file == null || file.Length == 0)
//{
//    return new UploadDto()
//    {
//        Status = false,
//        FileNameAddress = "",
//    };
//}

//string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
//var filePath = Path.Combine(uploadsRootFolder, fileName);
//using (var fileStream = new FileStream(filePath, FileMode.Create))
//{
//    file.CopyTo(fileStream);
//}

//return new UploadDto()
//{
//    FileNameAddress = folder + fileName,
//    Status = true,
//};
//}
//return null;
//    }
//}