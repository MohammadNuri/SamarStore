using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Common.Queries.GetHomePageImages
{
    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImagesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImagesDto>> Execute()
        {
            var images = _context.HomePageImages
                .OrderByDescending(p => p.Id)
                .Select(p => new HomePageImagesDto
            {
                Id = p.Id,  
                ImageLocation = p.ImageLocation,    
                Link = p.Link,  
                Src = p.Src

            }).ToList();   
            
            return new ResultDto<List<HomePageImagesDto>>()
            {
                Data = images,
                IsSuccess = true,
                Message = "عکس با موفقیت اضافه شد"
            };   
        }
    }
}
