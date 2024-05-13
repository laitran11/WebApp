using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Column("InvoiceId")]
        public string Id { get; set; }
        [NotMapped]
        public string CartId { get; set; }
        public byte StatusId { get; set; }
        public int AddressId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Address Address { get; set; }
        public Status Status { get; set; }
    }
}
