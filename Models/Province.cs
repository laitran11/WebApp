using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Province")]
    public class Province
    {
        [Column("ProvinceId")]
        public byte Id { get; set; }
        [Column("ProvinceName")]
        public string Name { get; set; }
        public List<District> Districts { get; set; }
    }
}
