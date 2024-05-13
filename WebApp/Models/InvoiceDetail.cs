namespace WebApp.Models
{
    public class InvoiceDetail
    {
        public string InvoiceId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public short Quantity { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; }
    }
}
