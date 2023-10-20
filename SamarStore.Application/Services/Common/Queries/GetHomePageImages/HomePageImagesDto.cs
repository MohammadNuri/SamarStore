using SamarStore.Domain.Entities.HomePage;

namespace SamarStore.Application.Services.Common.Queries.GetHomePageImages
{
    public class HomePageImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; } = string.Empty; 
        public string Link { get; set; } = string.Empty;
        public ImageLocation ImageLocation { get; set; }
    }
}
