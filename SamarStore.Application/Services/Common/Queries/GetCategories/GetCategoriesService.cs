using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Common.Queries.GetCategories
{
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
}
