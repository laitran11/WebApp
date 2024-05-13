using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class InvoiceExt
    {
        [Column("InvoiceId")]
        public string Id { get; set; }
        [NotMapped]
        public string CartId { get; set; }
        public byte StatusId { get; set; }
        public int AddressId { get; set; }
        public string StatusName { get; set; }
        public string AddressName { get; set; }
        public string WardName { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public string Phone { get; set; }
        [NotMapped]
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
