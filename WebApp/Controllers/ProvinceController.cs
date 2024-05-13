using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProvinceController : BaseController
    {
        public ProvinceController(SiteProvider provider) : base(provider)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Districts(byte id)
        {
            return Json(await provider.Province.GetDistrictsByProvince(id));
        }
        public async Task<IActionResult> Wards(byte id)
        {
            return Json(await provider.Province.GetWardsByDistrict(id));
        }
    }
}
