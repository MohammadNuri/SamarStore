using SamarStore.Application.Interfaces.Context;
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

	public class GetCategoriesService : IGetCategoriesService
	{
		private readonly IDataBaseContext _context;
		public GetCategoriesService(IDataBaseContext dataBaseContext)
		{
			_context = dataBaseContext;
		}
		public ResultDto<List<CategoriesDto>> Execute()
		{
			var categories = _context.Categories
				.Where(p => p.ParentCategoryId == null)
				.ToList()
				.Select(p => new CategoriesDto
				{
					CategoryName = p.Name,
					CatId = p.Id,
				}).ToList();

			return new ResultDto<List<CategoriesDto>>()
			{
				Data = categories,
				IsSuccess = true,
			};
		}
	}

	public class CategoriesDto
	{
		public long CatId { get; set; }
		public string CategoryName { get; set; }

	}
}
