using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(SiteProvider provider) : base(provider)
        {
        }

        [HttpGet("/{controller=home}/{action=index}/{p?}")]
        public async Task<IActionResult> Index(int p = 1)
        {
            //ViewBag.categories = await provider.Category.GetCategories();
            LoadData();
            return View(await provider.Product.GetProducts(p));
        }

        public async Task<IActionResult> Detail(int id)
        {
            LoadData();
            //Console.WriteLine(await provider.Product.GetProduct(id));
            return View(await provider.Product.GetProduct(id));

        }

        [HttpGet("/home/subcategory/{id}/{p?}")]
        public async Task<IActionResult> SubCategory(byte id, int p = 1)
        {
            LoadData();
            //ViewBag.categories = await provider.Category.GetCategories();
            return View(await provider.Product.GetProductsByCategory(id,p));
        }

        async void LoadData()
        {
            ViewBag.categories = await provider.Category.GetCategories();
        }
        


    }
}
