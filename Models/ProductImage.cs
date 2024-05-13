using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("ProductImage")]
    public class ProductImage
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public Product Product { get; set; }
    }
}
