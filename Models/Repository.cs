namespace WebApi.Models
{
    public abstract class Repository
    {
        protected EStoreContext context;
        public Repository(EStoreContext context)
        {
            this.context = context;
        }
        
    }
}
