using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class CartRepository : Repository
    {
        public CartRepository(EStoreContext context) : base(context)
        {
        }
        public int Add(Cart obj)
        {
            return context.Database.ExecuteSqlRaw("AddCart @Id,@ProductId,@Size,@Quantity", new SqlParameter[]
            {
                new SqlParameter("@Id",obj.Id),
                new SqlParameter("@ProductId",obj.ProductId),
                new SqlParameter("@Size",obj.Size),
                new SqlParameter("@Quantity", obj.Quantity)
            });
        }
        public List<Cart> GetCarts(string id)
        {
            return context.Cart.FromSqlRaw<Cart>("GetCarts @Id", new SqlParameter("Id", id)).ToList();
        }

    }
}
