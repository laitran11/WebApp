using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Invoice
    {
        public string Id { get; set; }
        public string CartId { get; set; }
        public byte StatusId { get; set; }
        public int AddressId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string StatusName { get; set; }
        public string AddressName { get; set; }
        public string WardName { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string Phone { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
