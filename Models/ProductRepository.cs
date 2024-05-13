using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class ProductRepository : Repository
    {
        public ProductRepository(EStoreContext context) : base(context)
        {
        }
        // Simple
        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }
        public IEnumerable<object> GetProducts(int page,int size)
        {
            // simple
            return context.Products.Include(p => p.ProductImages).Select(p => new {p.Id,p.Name,p.Price, p.Code,p.CategoryId,ImageUrl = p.ProductImages.FirstOrDefault().ImageUrl}).OrderBy(p=>p.Id).Skip((page-1)*size).Take(size).ToList();
        }
        public IEnumerable<object> GetProductsByCategories(byte id,int page, int size)
        {
            // simple
            return context.Products.Where(p=>p.CategoryId == id).Include(p => p.ProductImages).Select(p => new { p.Id, p.Name, p.Price, p.Code, p.CategoryId, ImageUrl = p.ProductImages.FirstOrDefault().ImageUrl }).OrderBy(p => p.Id).Skip((page - 1) * size).Take(size).ToList();
        }
        //public Product GetProduct(int id)
        //{
        //    return context.Products.Find(id);
        //}
        public object GetProduct(int id)
        {
            return context.Products.Include(p => p.ProductSizes).Select(p =>
            new
            {
                p.Id,
                p.Name,
                p.Price,
                p.Code,
                p.CategoryId,
                p.Color,
                ProductSizes = p.ProductSizes.Select(q => new { q.Size, q.IsSoldOut}),
                ProductImages = p.ProductImages.Select(q => new { q.ImageUrl})
            }).SingleOrDefault(p=>p.Id== id);
        }
    }
}
