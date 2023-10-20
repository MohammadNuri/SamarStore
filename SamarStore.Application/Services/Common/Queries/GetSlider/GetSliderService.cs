using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Common.Queries.GetSlider
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSliderService(IDataBaseContext context)
        {
            _context = context;

        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var slider = _context.Slider
                .OrderByDescending(p => p.Id)
                .ToList()
                .Select(p => new SliderDto()
                {

                    Link = p.Link,
                    Src = p.Src

                }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = slider,
                IsSuccess = true,
            };
        }
    }
}
