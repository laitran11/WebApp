namespace WebApp.Models
{
    public class CartRepository : Repository
    {
        public CartRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<List<Cart>> GetCarts(string id)
        {
            return await Get<List<Cart>>($"/api/cart/{id}");
        }


        public async Task<int> Add(Cart obj)
        {
            using(HttpClient client = new HttpClient { BaseAddress = uri}) 
            {
                HttpResponseMessage message = await client.PostAsJsonAsync<Cart>("/api/cart", obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<int>();
                }
                return -1;
            }
        }


    }
}
