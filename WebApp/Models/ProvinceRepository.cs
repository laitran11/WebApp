namespace WebApp.Models
{
    public class ProvinceRepository : Repository
    {
        public ProvinceRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<Province>> GetProvinces()
        {
            return await Get<List<Province>>("/api/province");
        }
        public async Task<List<District>> GetDistrictsByProvince(byte id)
        {
            return await Get<List<District>>($"/api/province/district/{id}");
        }
        public async Task<List<District>> GetWardsByDistrict(byte id)
        {
            return await Get<List<District>>($"/api/province/ward/{id}");
        }
    }
}
