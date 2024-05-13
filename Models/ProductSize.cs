using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("ProductSize")]
    public class ProductSize
    {
        public int ProductId { get; set; }
        public string Size { get; set; }
        public bool IsSoldOut { get; set; }

        public Product Product { get; set; }
    }
}
