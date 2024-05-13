using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class InvoiceController : BaseController
    {
        public InvoiceController(SiteProvider provider) : base(provider)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Detail(string id)
        {
            return View(await provider.Invoice.GetInvoice(id));
        }
    }
}
