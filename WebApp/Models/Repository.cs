namespace WebApp.Models
{
    public class Repository
    {
        protected Uri uri;
        public Repository(IConfiguration configuration)
        {
            uri = new Uri(configuration.GetValue<string>("Urls:Api"));
        }
        protected async Task<T> Get<T>(string url) where T : class
        {
            using(HttpClient client = new HttpClient { BaseAddress = uri})
            {
                HttpResponseMessage message = await client.GetAsync(url);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<T>();
                }
                return null;
            }
        }
        protected async Task<int> Post<T>(string url, T obj) where T : class
        {
            using (HttpClient client = new HttpClient { BaseAddress = uri })
            {
                HttpResponseMessage message = await client.PostAsJsonAsync<T>(url, obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<int>();
                }
                return 1;
            }
        }
        

    }
}
