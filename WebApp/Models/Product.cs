namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public byte CategoryId { get; set; }
        public string  Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        public List<ProductSize> ProductSizes { get; set; }

    }
}
