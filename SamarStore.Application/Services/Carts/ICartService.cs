using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Dto;
using SamarStore.Domain.Entities.Carts;

namespace SamarStore.Application.Services.Carts
{
    public interface ICartService
    {
        ResultDto AddToCart(long ProductId, Guid BrowserId);
        ResultDto RemoveFromCart(long ProductId, Guid BrowserId);
        ResultDto<CartDto> GetCarts(Guid BrowserId, long? UserId);

        ResultDto Add(long CartItemId);
        ResultDto LowOff(long CartItemId);
        ResultDto DecrementCartItemCount(long ProductId, Guid BrowserId);
    }


    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Add(long CartItemId)
        {
            var cartItem = _context.CartItems.Find(CartItemId);
            cartItem.Count++;
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto AddToCart(long ProductId, Guid BrowserId)
        {
            var cart = _context.Carts
                .Include(c => c.CartItems)
                .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                .FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId = BrowserId,
                };
                _context.Carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;
            }

            var product = _context.Products.Find(ProductId);

            var cartItem = _context.CartItems.Where(p => p.ProductId == ProductId && p.CartId == cart.Id).FirstOrDefault();

            if (cartItem != null)
            {
                cartItem.Count++;
                _context.SaveChanges();
            }
            else
            {
                CartItem newCartItem = new CartItem()
                {
                    Cart = cart,
                    Count = 1,
                    Price = product.Price,
                    Product = product,
                };
                _context.CartItems.Add(newCartItem);
                _context.SaveChanges();
            }
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"محصول {product.Name} با موفقیت به سبد خرید اضافه شد"
            };
        }

        public ResultDto<CartDto> GetCarts(Guid BrowserId, long? UserId)
        {
            var cart = _context.Carts
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.ProductImages)
                .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                .OrderByDescending(p => p.Id)
                .FirstOrDefault();

            if(UserId != null)
            {
                var user = _context.Users.Find(UserId);
                cart.User = user;
                _context.SaveChanges();
            }

            return new ResultDto<CartDto>()
            {
                Data = new CartDto()
                {
                    ProductCount = cart.CartItems.Count(),
                    SumAmount = cart.CartItems.Sum(p => p.Price * p.Count),
                    CartItems = cart.CartItems.Select(p => new CartItemDto
                    {
                        Id = p.Id,
                        Image = p.Product?.ProductImages?.FirstOrDefault()?.Src ?? "",
                        Count = p.Count,
                        Price = p.Price,
                        Product = p.Product.Name
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }

        public ResultDto LowOff(long CartItemId)
        {

            var cartItem = _context.CartItems.Find(CartItemId);

            if (cartItem.Count <= 1)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                };
            }

            cartItem.Count--;

            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
            };
        }

        public ResultDto RemoveFromCart(long ProductId, Guid BrowserId)
        {
            var cartItem = _context.CartItems.Where(p => p.Cart.BrowserId == BrowserId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.IsRemoved = true;
                cartItem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };
            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };
            }
        }

        public ResultDto DecrementCartItemCount(long ProductId, Guid BrowserId)
        {
            var cart = _context.Carts
                .Include(c => c.CartItems)
                .Where(p => p.BrowserId == BrowserId && p.Finished == false)
                .FirstOrDefault();

            if (cart != null)
            {
                var cartItem = _context.CartItems.Where(p => p.ProductId == ProductId && p.CartId == cart.Id).FirstOrDefault();

                var product = _context.Products.Find(ProductId);

                if (cartItem != null)
                {
                    if (cartItem.Count > 1)
                    {
                        cartItem.Count--;
                        _context.SaveChanges();

                        return new ResultDto
                        {
                            IsSuccess = true,
                            Message = $"تعداد محصول {cartItem.Product.Name} در سبد خرید کاهش یافت"
                        };
                    }
                    else
                    {
                        // If the count is 1, remove the product from the cart
                        cartItem.IsRemoved = true;
                        cartItem.RemoveTime = DateTime.Now;
                        _context.SaveChanges();

                        return new ResultDto
                        {
                            IsSuccess = true,
                            Message = $"محصول {cartItem.Product.Name} از سبد خرید حذف شد"
                        };
                    }
                }
            }

            return new ResultDto
            {
                IsSuccess = false,
                Message = "محصول یافت نشد"
            };
        }
    }



    public class CartDto
    {
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
    public class CartItemDto
    {
        public long Id { get; set; }
        public string Product { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
