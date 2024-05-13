using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : BaseController
    {
        public ProvinceController(SiteProvider provider) : base(provider)
        {
        }
        public List<Province> GetProvinces()
        {
            return provider.Province.GetProvinces();
        }
        [HttpGet("district/{id}")]
        public List<District> GetDistricts(byte id)
        {
            return provider.District.GetDistrictsByProvince(id);
        }
        [HttpGet("ward/{id}")]
        public List<Ward> GetWards(byte id)
        {
            return provider.Ward.GetWardsByDistrict(id);
        }
    }
}
