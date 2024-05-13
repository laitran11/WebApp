namespace WebApp.Models
{
    public class CategoryRepository :Repository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        //IConfiguration configuration;

        public async Task<List<Category>> GetCategories()
        {
            using(HttpClient client = new HttpClient { BaseAddress = uri})
            {
                HttpResponseMessage message = await client.GetAsync("/api/category");
                if(message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<List<Category>>();
                }
                return null;

            }
        }


    }
}
