using SamarStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.Common.Queries.GetCategories
{
    public interface IGetCategoriesService
	{
		ResultDto<List<CategoriesDto>> Execute();
	}
}
