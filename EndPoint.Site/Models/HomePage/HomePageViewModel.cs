using SamarStore.Application.Services.Common.Queries.GetHomePageImages;
using SamarStore.Application.Services.Common.Queries.GetSlider;
using SamarStore.Application.Services.Products.Queries.GetProductForSite;
using SamarStore.Domain.Entities.HomePage;

namespace EndPoint.Site.Models.HomePage
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImagesDto> HomePageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; } 
        public List<ProductForSiteDto> Mobile { get; set; } 

    }
}
