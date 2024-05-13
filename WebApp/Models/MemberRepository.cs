namespace WebApp.Models
{
    public class MemberRepository : Repository
    {
        public MemberRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<ResponseLogin> Login(LoginModel obj)
        {
            using(HttpClient client = new HttpClient { BaseAddress = uri })
            {
                HttpResponseMessage message = await client.PostAsJsonAsync<LoginModel>("/api/auth/login",obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<ResponseLogin>();
                }
                return null;
            }
        }
        public async Task<int> Add(RegisterModel obj)
        {
            using (HttpClient client = new HttpClient { BaseAddress = uri })
            {
                HttpResponseMessage message = await client.PostAsJsonAsync<RegisterModel>("/api/auth/register", obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<int>();
                }
                return -1;
            }
        }
    }
}
