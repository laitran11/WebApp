namespace WebApp.Models
{
    public class AddressRepository : Repository
    {
        public AddressRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> Add(Address obj)
        {
            return await Post("/api/address", obj);
        }
        public async Task<List<Address>> GetAddresses(long id)
        {
            return await Get<List<Address>>($"/api/address/{id}");
        }
    }
}
