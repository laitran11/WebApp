namespace WebApi.Models
{
    public abstract class Provider : IDisposable
    {
        EStoreContext context;
        IConfiguration configuration;
        public Provider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected EStoreContext Context
        {
            get 
            { 
                if(context is null)
                {
                    context = new EStoreContext(configuration);
                }
                return context;
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
