using Microsoft.AspNetCore.Http;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Services.Common;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.HomePage;

namespace SamarStore.Application.Services.HomePage.Commands.AddNewSlider
{
    public class AddNewSliderService : IAddNewSliderService
    {
        private readonly IDataBaseContext _context;
        public AddNewSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(IFormFile file, string? link)
        {
            var uploadFileService = new UploadFileService("wwwroot/images/SliderImages");

            var resultUpload = uploadFileService.UploadFile(file);

            Slider slider = new Slider()
            {
                Link = link,
                Src = resultUpload.FileNameAddress,
            };   

            _context.Slider.AddRange(slider);  
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "آپلود انجام شد"
            };

        }
    }
}
