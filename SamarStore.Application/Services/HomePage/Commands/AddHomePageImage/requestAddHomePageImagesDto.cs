using Microsoft.AspNetCore.Http;
using SamarStore.Domain.Entities.HomePage;

namespace SamarStore.Application.Services.HomePage.Commands.AddHomePageImage
{
    public class requestAddHomePageImagesDto
    {
        public IFormFile File { get; set; }
        public string Link { get; set; } = string.Empty;    
        public ImageLocation ImageLocation { get; set; }
    }
}
