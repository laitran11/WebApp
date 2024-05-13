using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class InvoiceRepository : Repository
    {
        public InvoiceRepository(EStoreContext context) : base(context)
        {
        }
        public int Add(Invoice obj)
        {
            if(string.IsNullOrEmpty(obj.Id))
            {
                obj.Id = Guid.NewGuid().ToString().Replace("-", "");
            }
            return context.Database.ExecuteSqlRaw("AddInvoice @InvoiceId, @CartId, @AddressId", new SqlParameter[]
            {
                new SqlParameter("@InvoiceId",obj.Id),
                new SqlParameter("@CartId", obj.CartId),
                new SqlParameter("@AddressId", obj.AddressId)
            });
        }
       
        public Invoice GetInvoice(string id)
        {
            return context.Invoices.Include(p=> p.Address).Select(p=> new Invoice
            {
                Id = p.Id,
                InvoiceDate= p.InvoiceDate,
                Address = new Address
                {
                    Name = p.Address.Name,
                    Phone= p.Address.Phone,
                    WardId= p.Address.WardId,
                    Ward = new Ward
                    {
                        Id = p.Address.Ward.Id,
                        Name = p.Address.Ward.Name,
                        District = new District
                        {
                            Id = p.Address.Ward.District.Id,
                            Name = p.Address.Ward.District.Name,
                            Province = new Province
                            {
                                Id = p.Address.Ward.District.Province.Id,
                                Name = p.Address.Ward.District.Province.Name,
                            }
                        }
                    }
                },
                StatusId = p.StatusId,
                Status = new Status
                {
                    Id = p.Status.Id,
                    Name = p.Status.Name
                },
            }).SingleOrDefault(p =>p.Id == id);
        }
        public InvoiceExt GetInvoiceExt(string id)
        {
            InvoiceExt obj = context.InvoiceExts.FromSqlRaw<InvoiceExt>("EXEC GetInvoiceById @Id", new SqlParameter("@Id", id)).AsEnumerable().SingleOrDefault();
            if(obj != null)
            {
                obj.InvoiceDetails = context.InvoiceDetails.FromSqlRaw<InvoiceDetail>("EXEC GetInvoiceDetailById @Id", new SqlParameter("@Id", id)).ToList();
                return obj;
            }
            return null;
        }
        
    }
}
