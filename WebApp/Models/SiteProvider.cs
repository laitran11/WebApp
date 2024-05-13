namespace WebApp.Models
{
    public class SiteProvider
    {
		IConfiguration configuration;
		public SiteProvider(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
        InvoiceRepository invoice;

        public InvoiceRepository Invoice
        {
            get
            {
                if (invoice == null)
                {
                    invoice = new InvoiceRepository(configuration);
                }
                return invoice;
            }

        }
        CategoryRepository category;

		public CategoryRepository Category
		{
			get { 
				if(category == null)
				{
					category = new CategoryRepository(configuration);
				}
				return category; 
			}
		
		}
        ProductRepository product;

        public ProductRepository Product
        {
            get
            {
                if (product == null)
                {
                    product = new ProductRepository(configuration);
                }
                return product;
            }

        }
        CartRepository cart;

        public CartRepository Cart
        {
            get
            {
                if (cart == null)
                {
                    cart = new CartRepository(configuration);
                }
                return cart;
            }

        }
        MemberRepository member;
        public MemberRepository Member
        {
            get
            {
                if (member is null)
                {
                    member = new MemberRepository(configuration);
                }
                return member;
            }
        }
        AddressRepository address;
        public AddressRepository Address
        {
            get
            {
                if (address is null)
                {
                    address = new AddressRepository(configuration);
                }
                return address;
            }
        }
        ProvinceRepository province;
        public ProvinceRepository Province
        {
            get
            {
                if (province is null)
                {
                    province = new ProvinceRepository(configuration);
                }
                return province;
            }
        }
    }
}
