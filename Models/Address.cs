using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Address")]
    public class Address
    {
        [Column("AddressId")]
        public int Id { get; set; }
        [Column("AddressName")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public int WardId { get; set; }
        public long MemberId { get; set; }
        public bool IsDefault { get; set; }

        public List<Invoice> Invoice { get; set; }
        public Ward Ward { get; set; }

    }
}
