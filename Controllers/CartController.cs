using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseController
    {
        public CartController(SiteProvider provider) : base(provider)
        {
        }

        [HttpPost]
        public int Post(Cart obj)
        {
            return provider.Cart.Add(obj);
        }
        [HttpGet("{id}")]
        public List<Cart> GetCarts(string id)
        {
            return provider.Cart.GetCarts(id);
        }
        
    }
}
