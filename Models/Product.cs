using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Product")]
    public class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }
        [Column("ProductName")]
        public string Name { get; set; }
        [Column("ProductCode")]
        public string Code { get; set; }
        public byte CategoryId { get; set; }

        public  int Price{ get; set; }

        public string Color { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        //public Cart Cart { get; set; }
    }
}
