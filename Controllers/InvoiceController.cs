using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : BaseController
    {
        public InvoiceController(SiteProvider provider) : base(provider)
        {
        }
        [HttpPost]
        public int Post(Invoice obj)
        {
            return provider.Invoice.Add(obj);
        }
        [HttpGet("{id}")]
        public Invoice Get(string id)
        {
            return provider.Invoice.GetInvoice(id);
        }
        [HttpGet("ext/{id}")]
        public InvoiceExt GetExt(string id)
        {
            return provider.Invoice.GetInvoiceExt(id);
        }

    }
}
