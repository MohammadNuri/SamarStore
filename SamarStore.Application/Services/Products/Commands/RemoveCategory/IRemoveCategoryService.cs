using SamarStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.Products.Commands.RemoveCategory
{
	public interface IRemoveCategoryService
    {
        ResultDto Execute(long CatId);
    }
}
