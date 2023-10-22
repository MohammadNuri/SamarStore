using SamarStore.Common.Dto;

namespace SamarStore.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(long ProductId, Guid BrowserId);
        ResultDto RemoveFromCart(long ProductId, Guid BrowserId);
        ResultDto<CartDto> GetCarts(Guid BrowserId, long? UserId);
        ResultDto Add(long CartItemId);
        ResultDto LowOff(long CartItemId);
    }
}
