using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    
    public class CategoryRepository : Repository
    {
        public CategoryRepository(EStoreContext context) : base(context)
        {
        }

        public List<Category> GetCategories()
        {
            return context.Categories.Where(p=>p.ParentId ==null).Include(p=> p.Children).ToList();
        }
    }
}
