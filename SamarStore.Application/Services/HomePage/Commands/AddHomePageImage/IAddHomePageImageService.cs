using SamarStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.HomePage.Commands.AddHomePageImage
{
    public interface IAddHomePageImageService
    {
        ResultDto Execute(requestAddHomePageImagesDto request);
    }
}
