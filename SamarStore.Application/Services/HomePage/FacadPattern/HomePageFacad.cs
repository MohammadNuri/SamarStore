using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Common.Queries.GetHomePageImages;
using SamarStore.Application.Services.Common.Queries.GetSlider;
using SamarStore.Application.Services.HomePage.Commands.AddHomePageImage;
using SamarStore.Application.Services.HomePage.Commands.AddNewSlider;

namespace SamarStore.Application.Services.HomePage.FacadPattern
{
    public class HomePageFacad : IHomePageFacad
    {
        private readonly IDataBaseContext _context;
        public HomePageFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private AddNewSliderService _addNewSlider;
        public AddNewSliderService AddNewSliderService
        {
            get
            {
                return _addNewSlider = _addNewSlider ?? new AddNewSliderService(_context);
            }
        }

		private IGetSliderService _getSlider;
		public IGetSliderService GetSliderService
        {
            get
            {
				return _getSlider = _getSlider ?? new GetSliderService(_context);
			}
        }

        private AddHomePageImageService _addHomePageImage;
        public AddHomePageImageService AddHomePageImageService
        {
            get
            {
                return _addHomePageImage = _addHomePageImage ?? new AddHomePageImageService(_context);
            }
        }

        private IGetHomePageImagesService _getHomePageImages;   
        public IGetHomePageImagesService GetHomePageImagesService
        {
            get
            {
                return _getHomePageImages = _getHomePageImages ?? new GetHomePageImagesService(_context);
            }
        }
    }
}
