namespace WebApp.Models
{
    public class Category
    {
        public byte Id { get; set; }
        public string Name { get; set; }

        public List<Category> Children { get; set; }

    }
}
