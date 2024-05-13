using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CartController : BaseController
    {
        const string CartId = "cart";
        public CartController(SiteProvider provider) : base(provider)
        {
        }
        public async Task<IActionResult> Index()
        {
            string id = Request.Cookies[CartId];
            if(!string.IsNullOrEmpty(id))
            {
                return View( await provider.Cart.GetCarts(id));
            }
            return Redirect("/");
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(Invoice obj)
        {
            obj.Id = Guid.NewGuid().ToString().Replace("-","");
            obj.CartId = Request.Cookies[CartId];
            int ret = await provider.Invoice.Post(obj);
            if(ret > 0)
            {
                return Redirect($"/invoice/detail/{obj.Id}");
            }
            return View(obj);
        }


        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            ViewBag.provinces = new SelectList(await provider.Province.GetProvinces(), "Id", "Name");
            ViewBag.Addresses = await provider.Address.GetAddresses(Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Address(Address obj)
        {
            obj.MemberId = Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier));
            int ret = await provider.Address.Add(obj);
            return Redirect("/cart/checkout");
        }
        [HttpPost]
        public async Task<IActionResult> Add(Cart obj)
        {
            //Console.WriteLine($"{obj.ProductId},{obj.Quantity},{obj.Size}");
            //Cookies vs Session
            string id = Request.Cookies[CartId];
            if(string.IsNullOrEmpty(id))
            {
                obj.Id = Helper.RandomString(16);
                Response.Cookies.Append(CartId, obj.Id, new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(7)
                });
            }
            else
            {
                obj.Id = id;
            }

            
            //obj.Id = Helper.RandomString(16);
            int ret = await provider.Cart.Add(obj);
            if(ret > 0)
            {
                return Redirect("/cart");
            }
            return Redirect("/cart/error");
            
            
            //return View();
        }


    }
}
