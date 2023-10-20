using SamarStore.Application.Services.Common.Queries.GetHomePageImages;
using SamarStore.Application.Services.Common.Queries.GetSlider;
using SamarStore.Application.Services.HomePage.Commands.AddHomePageImage;
using SamarStore.Application.Services.HomePage.Commands.AddNewSlider;
using SamarStore.Application.Services.HomePage.FacadPattern;

namespace SamarStore.Application.Interfaces.FacadPatterns
{
    public interface IHomePageFacad
    {
        AddNewSliderService AddNewSliderService { get; }
        IGetSliderService GetSliderService { get; } 
        AddHomePageImageService AddHomePageImageService { get; }
        IGetHomePageImagesService GetHomePageImagesService { get; }

    }
}
