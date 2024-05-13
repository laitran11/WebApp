
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models{
    public class EStoreContext : DbContext{
        IConfiguration configuration;
        public EStoreContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<InvoiceExt> InvoiceExts { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }

        public DbSet<Ward> Wards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSize> productSizes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Cart> Cart { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductImage>().HasKey(p => new { p.ProductId, p.ImageUrl });
            modelBuilder.Entity<ProductSize>().HasKey(p => new { p.ProductId, p.Size });
            modelBuilder.Entity<Cart>().HasKey(p => new { p.Id, p.ProductId,p.Size });
            modelBuilder.Entity<InvoiceDetail>().HasKey(p => new { p.InvoiceId, p.ProductId, p.Size });
        
        }
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Estore"));
        }
    }
    
}