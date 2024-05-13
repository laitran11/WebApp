namespace WebApp.Models
{
    public class ProductRepository : Repository
    {
        public ProductRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<Product> GetProduct(int id)
        { 
            using(HttpClient client = new HttpClient { BaseAddress = uri})
            {
                HttpResponseMessage message = await client.GetAsync($"/api/product/detail/{id}");
                if(message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<Product>();
                }
                return null;
            }
        }


        public async Task<List<Product>> GetProducts(int page)
        {
            using(HttpClient client = new HttpClient { BaseAddress= uri })
            {
                HttpResponseMessage message = await client.GetAsync($"/api/product/{page}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<List<Product>>();
                }
                return null;
            }
        }
        public async Task<List<Product>> GetProductsByCategory(byte id,int page)
        {
            using (HttpClient client = new HttpClient { BaseAddress = uri })
            {
                HttpResponseMessage message = await client.GetAsync($"/api/product/category/{id}/{page}");
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<List<Product>>();
                }
                return null;
            }
        }
    }
}
