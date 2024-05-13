using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class MemberRepository : Repository
    {
        public MemberRepository(EStoreContext context) : base(context)
        {
        }
        public Member Login(LoginModel obj)
        {
            string pwd = obj.Usr + "@?@#!?#" + obj.Pwd;
            //return context.Members.Select(p=>new Member
            //{
            //    Id = p.Id,
            //    Username= p.Username,
            //    Email= p.Email,
            //    Gender= p.Gender
            //}).Where(p=> (p.Username == obj.Usr || p.Email == obj.Usr) && p.Password == Helper.Hash(pwd)).SingleOrDefault();
            return context.Members.FromSqlRaw<Member>("EXEC LoginMember @Usr,@Pwd", new SqlParameter[]
            {
                new SqlParameter("@Usr", obj.Usr),
                new SqlParameter("Pwd", Helper.Hash(pwd))
            }).AsEnumerable().Select(p=>new Member
            {
                Id = p.Id,
                Username= p.Username,
                Email= p.Email,
                Gender= p.Gender
            }).SingleOrDefault();
        }


        public int Add(RegisterModel obj)
        {
            string pwd = obj.Usr + "@?@#!?#" + obj.Pwd;
            context.Members.Add(new Member
            {
                Id = obj.Id,
                Username = obj.Usr,
                Gender = obj.Gen,
                Email = obj.Eml,
                // Naive
                PasswordStr = Helper.HashString(pwd),
                Password = Helper.Hash(pwd)
            });
            return context.SaveChanges();
        }
    }
}
