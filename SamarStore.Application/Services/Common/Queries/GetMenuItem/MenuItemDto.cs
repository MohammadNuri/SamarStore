namespace SamarStore.Application.Services.Common.Queries.GetMenuItem
{
	public class MenuItemDto
    {
        public long CatId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<MenuItemDto> Child { get; set; } = new List<MenuItemDto>();
    }
}
