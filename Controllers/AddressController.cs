using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        public AddressController(SiteProvider provider) : base(provider)
        {
        }
        [HttpPost]
        public int Add(Address obj)
        {
            return provider.Address.Add(obj);
        }
        [HttpGet("{id}")]
        public List<Address> GetAddresses(long id)
        {
            return provider.Address.GetAddresses(id);
        }
    }
}
