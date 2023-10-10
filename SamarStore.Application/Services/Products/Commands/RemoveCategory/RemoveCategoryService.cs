using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Products.Commands.RemoveCategory
{
	public class RemoveCategoryService : IRemoveCategoryService
    {
        private readonly IDataBaseContext _context;
        public RemoveCategoryService(IDataBaseContext dataBaseContext)
        {
            _context = dataBaseContext; 
        }

        public ResultDto Execute(long CatId)
        {
            var category = _context.Categories.Find(CatId);
            if (category == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,  
                    Message = "دسته بندی پیدا نشد"
                }; 
            }
            category.IsRemoved = true;  
            category.RemoveTime = DateTime.Now;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت حذف شد"

            }; 
        }
    }
}
