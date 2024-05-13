namespace WebApi.Models
{
    public class WardRepository : Repository
    {
        public WardRepository(EStoreContext context) : base(context)
        {
        }
        public List<Ward> GetWardsByDistrict(short id)
        {
            return context.Wards.Where(p => p.DistrictId == id).ToList();
        }

    }
}
