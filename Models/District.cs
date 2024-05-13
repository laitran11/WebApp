using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("District")]
    public class District
    {
        [Column("DistrictId")]
        public short Id { get; set; }
        public byte ProvinceId { get; set; }
        [Column("DistrictName")]
        public string Name { get; set; }
        public List<Ward> Wards { get; set; }
        public Province Province { get; set; }
    }
}
