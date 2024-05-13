using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    [Table("Member")]
    public class Member
    {
        [Column("MemberId")]
        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string PasswordStr { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }

    }
}
