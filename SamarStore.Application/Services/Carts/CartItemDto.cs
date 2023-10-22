namespace SamarStore.Application.Services.Carts
{
    public class CartItemDto
    {
        public long Id { get; set; }
        public string Product { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Count { get; set; }
        public int Price { get; set; }
    }

}
