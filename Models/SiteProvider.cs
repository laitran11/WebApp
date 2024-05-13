namespace WebApi.Models
{
    public class SiteProvider : Provider
    {
        public SiteProvider(IConfiguration configuration) : base(configuration)
        {
        }
        InvoiceRepository invoice;
        public InvoiceRepository Invoice
        {
            get
            {
                if (invoice is null)
                {
                    invoice = new InvoiceRepository(Context);
                }
                return invoice;
            }
        }
        CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if(category is null)
                {
                    category = new CategoryRepository(Context);
                }
                return category;
            }
        }
        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product is null)
                {
                    product = new ProductRepository(Context);
                }
                return product;
            }
        }
        CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                if (cart is null)
                {
                    cart = new CartRepository(Context);
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
                    member = new MemberRepository(Context);
                }
                return member;
            }
        }
        ProvinceRepository province;
        public ProvinceRepository Province
        {
            get
            {
                if (province is null)
                {
                    province = new ProvinceRepository(Context);
                }
                return province;
            }
        }
        DistrictRepository district;
        public DistrictRepository District
        {
            get
            {
                if (district is null)
                {
                    district = new DistrictRepository(Context);
                }
                return district;
            }
        }
        WardRepository ward;
        public WardRepository Ward
        {
            get
            {
                if (ward is null)
                {
                    ward = new WardRepository(Context);
                }
                return ward;
            }
        }
        AddressRepository address;
        public AddressRepository Address
        {
            get
            {
                if (address is null)
                {
                    address = new AddressRepository(Context);
                }
                return address;
            }
        }
    }
}
