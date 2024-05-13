using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        int size = 9;

        public ProductController(SiteProvider provider) : base(provider)
        {
        }
        [HttpGet("{p?}")]
        public IEnumerable<object> GetProducts(int p =1)
        {
            return provider.Product.GetProducts(p,size);
        }
        [HttpGet("category/{id}/{p?}")]
        public IEnumerable<object> GetProductsByCategory(byte id, int p = 1)
        {
            return provider.Product.GetProductsByCategories(id, p,size);
        }
        [HttpGet("detail/{id}")]
        public object Detail(int id)
        {
            return provider.Product.GetProduct(id);
        }
    }
}
