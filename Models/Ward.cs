using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Ward")]
    public class Ward
    {
        [Column("WardId")]
        public int Id { get; set; }
        public short DistrictId { get; set; }
        [Column("WardName")]
        public string Name { get; set; }
        public List<Address> Address { get; set; }
        public District District { get; set; }
    }
}
