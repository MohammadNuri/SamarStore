using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Carts;

namespace EndPoint.Site.Controllers
{
    [Authorize("Customer")]
    public class PayController : Controller
    {
        private readonly IFinancesFacad _financesFacad;
        private readonly ICartService _cartService;
        private readonly CookiesManager _cookiesManeger;
        public PayController(IFinancesFacad financesFacad, ICartService cartService)
        {
            _financesFacad = financesFacad;
            _cartService = cartService;
            _cookiesManeger = new CookiesManager();
        }
        public IActionResult Index()
        {

            long? userId = ClaimUtility.GetUserId(User);

            var cart = _cartService.GetCarts(_cookiesManeger.GetBrowserId(HttpContext), userId);

            if(cart.Data.SumAmount > 0)
            {
                var requestPay = _financesFacad.AddRequestPayService.Execute(cart.Data.SumAmount, userId.Value);
                //ارسال به درگلاه پرداخت
            }
            else
            {
                return RedirectToAction("Index", "Cart");
            }

            return View();
        }
    }
}
