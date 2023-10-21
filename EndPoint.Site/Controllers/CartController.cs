using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Services.Carts;
using SamarStore.Domain.Entities.Carts;

namespace EndPoint.Site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger cookiesManeger;
        public CartController(ICartService cartService)
        {
            _cartService = cartService; 
            cookiesManeger = new CookiesManeger();
        }

        public IActionResult Index()
        {
            var userId = ClaimUtility.GetUserId(User);

            var result = _cartService.GetCarts(cookiesManeger.GetBrowserId(HttpContext),userId);

            return View(result.Data);
        }

        public IActionResult AddToCart(long ProductId, string returnUrl)
        {
           
            var resultAdd = _cartService.AddToCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));


            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                // Redirect the user back to the returnUrl
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public IActionResult Add(long CartItemId)
        {

            _cartService.Add(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult LowOff(long CartItemId)
        {

            _cartService.LowOff(CartItemId);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(long ProductId, string returnUrl)
        {
            _cartService.RemoveFromCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                // Redirect the user back to the returnUrl
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult DecrementCartItemCount(long ProductId, string returnUrl)
        {

            _cartService.DecrementCartItemCount(ProductId, cookiesManeger.GetBrowserId(HttpContext));

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                // Redirect the user back to the returnUrl
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        
    }
}
