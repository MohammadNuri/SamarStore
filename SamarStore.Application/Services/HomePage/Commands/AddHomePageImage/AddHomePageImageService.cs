using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Services.Common;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.HomePage;

namespace SamarStore.Application.Services.HomePage.Commands.AddHomePageImage
{
    public class AddHomePageImageService : IAddHomePageImageService
    {
        private readonly IDataBaseContext _context;
        public AddHomePageImageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(requestAddHomePageImagesDto request)
        {
            var uploadFileService = new UploadFileService("wwwroot/images/HomePageImages");

            var resultUpload = uploadFileService.UploadFile(request.File);

            HomePageImages homePageImages = new HomePageImages()
            {
                Link = request.Link, 
                Src = resultUpload.FileNameAddress,
                ImageLocation = request.ImageLocation,
            };
            _context.HomePageImages.Add(homePageImages);
            _context.SaveChanges();
            
            return new ResultDto()
            {
                IsSuccess = true,   
                Message = "عکس با موفقیت اضافه شد"
            };
        }
    }
}
