using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.HomePage.Commands.AddNewSlider
{
    public interface IAddNewSliderService
    {
        ResultDto Execute(IFormFile file, string? link);
    }
}
