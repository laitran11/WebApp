namespace WebApi.Models
{
    public class RegisterModel
    {
        public long Id { get; set; }
        public string Usr { get; set; }
        public string Pwd { get; set; }
        public string Eml { get; set; }
        public bool Gen { get; set; }
    }
}
