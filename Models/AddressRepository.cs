namespace WebApi.Models
{
    public class AddressRepository : Repository
    {
        public AddressRepository(EStoreContext context) : base(context)
        {
        }
        public int Add(Address obj)
        {
            context.Addresses.Add(obj);
            return context.SaveChanges();
        }
        public List<Address> GetAddresses(long id)
        {
            return context.Addresses.Where(p=>p.MemberId== id).ToList();
        }
    }
}
