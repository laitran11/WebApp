using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(SiteProvider provider) : base(provider)
        {
        }
        [Authorize]
        public string Get()
        {
            return "Welcome";
        }
        [HttpPost("login")]
        public object Login(LoginModel obj)
        {
            Member member = provider.Member.Login(obj);
            if (member != null)
            {
                string token = Helper.CreateToken(member);
                return new
                {
                    Token = token,
                    Member = member
                };
            }
            return null;
        }

        [HttpPost("register")]
        public int Register(RegisterModel obj)
        {
            
            Random random = new Random();
            obj.Id = random.NextInt64();
            return provider.Member.Add(obj);
        }
        //[HttpPost("login")]
        //public Member Register(LoginModel obj)
        //{
        //    Member member = provider.Member.Login(obj);
            
        //    return member;
        //}



    }
}
