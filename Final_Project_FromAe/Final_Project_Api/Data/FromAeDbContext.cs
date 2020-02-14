using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Api.Data
{
    public class FromAeDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public FromAeDbContext(DbContextOptions<FromAeDbContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }

        public DbSet<Marka> Markas { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductCategory>().HasKey( x => new { x.CategoryId, x.ProductId });
            builder.Entity<ProductProperty>().HasKey(x => new { x.ProductId, x.PropertyId });

            builder.Entity<ProductCategory>().HasOne(x => x.Product).WithMany(x => x.ProductCategories);
            builder.Entity<ProductCategory>().HasOne(x => x.Category).WithMany(x => x.ProductCategories);
            
            builder.Entity<ProductProperty>().HasOne(x => x.Product).WithMany(x => x.ProductProperties);
            builder.Entity<ProductProperty>().HasOne(x => x.Property).WithMany(x => x.ProductProperties);

            base.OnModelCreating(builder);
        }

    }
}
