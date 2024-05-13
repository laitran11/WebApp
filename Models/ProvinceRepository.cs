namespace WebApi.Models
{
    public class ProvinceRepository : Repository
    {
        public ProvinceRepository(EStoreContext context) : base(context)
        {
        }
        public List<Province> GetProvinces()
        {
            return context.Provinces.ToList();
        }
    }
}
