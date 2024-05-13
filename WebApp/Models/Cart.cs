namespace WebApp.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public short Quantity { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }

    }
}
