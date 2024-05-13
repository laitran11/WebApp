namespace WebApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int WardId { get; set; }
        public bool IsDefault { get; set; }
        public long MemberId { get; set; }


    }
}
