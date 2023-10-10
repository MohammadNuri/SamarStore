using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Common.Queries.GetMenuItem
{
	public interface IGetMenuItemService
    {
        ResultDto<List<MenuItemDto>> Execute();
    }
}
