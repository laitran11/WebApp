using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Status")]
    public class Status
    {
        [Column("StatusId")]
        public byte Id { get; set; }
        [Column("StatusName")]
        public string Name { get; set; }
        public List<Invoice> Invoice { get; set; }

    }
}
