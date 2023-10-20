using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Common.Queries.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();
    }
}
