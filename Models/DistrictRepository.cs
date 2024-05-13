namespace WebApi.Models
{
    public class DistrictRepository : Repository
    {
        public DistrictRepository(EStoreContext context) : base(context)
        {
        }
        public List<District> GetDistrictsByProvince(byte id)
        {
            return context.Districts.Where(p => p.ProvinceId == id).ToList();
        }


    }
}
