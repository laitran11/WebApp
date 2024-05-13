namespace WebApp.Models
{
    public class InvoiceRepository : Repository
    {
        public InvoiceRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> Post(Invoice obj)
        {
            return await Post<Invoice>("/api/invoice", obj);
        }
        public async Task<Invoice> GetInvoice(string id)
        {
            return await Get<Invoice>($"/api/invoice/ext/{id}");
        }
    }
}
