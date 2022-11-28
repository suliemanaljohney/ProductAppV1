using Microsoft.EntityFrameworkCore;
using ProductAppV1.Shared;

namespace BlazorProductApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Fenty Beauty",
                    Description = "it helps to have singer and business powerhouse Rihanna at the helm.",
                    Price = 2,
                    CategoryId = 1

                },
                  new Product
                  {
                      Id = 2,
                      Name = "Ikea",
                      Description = "Putting together their furniture may be a tough task, but at least Ikea supports your relaxation too",
                      Price = 4,
                      CategoryId = 2

                  },
                    new Product
                    {
                        Id = 3,
                        Name = "Swarovski",
                        Description = "For more than a century, Swarovski has put the sparkle in gowns, tiaras, jewelry, sculptures, and even luxury cars",
                        Price = 20,
                        CategoryId = 3

                    },
                      new Product
                      {
                          Id = 4,
                          Name = "Dove",
                          Description = "Dove’s ‘Real Beauty’ campaign was far ahead of other brands in promoting body positivity and self-acceptance.",
                          Price = 6,
                          CategoryId = 4

                      },
                       new Product
                       {
                           Id = 5,
                           Name = "Soothing Cleanser",
                           Description = "Deep-clean your complexion with SkinCeuticals' foam face wash, which is infused with glycerin and cucumber extract",
                           Price = 15,
                           CategoryId = 4

                       },
                         new Product
                         {
                             Id = 6,
                             Name = "Daily Facial Cleanser",
                             Description = "With a powder-fresh scent and mild suds, Cetaphil's dermatologist-recommended face wash.",
                             Price = 10,
                             CategoryId = 4

                         }
                );
            modelBuilder.Entity<Category>().HasData
                (
                      new Category { Id = 1, Name = "High-end foundation makeup" },
                      new Category { Id = 2, Name = "Bedding" },
                      new Category { Id = 3, Name = "Jewelry" },
                      new Category { Id = 4, Name = "Skin care" },
                      new Category { Id = 5, Name = "Grocery essentials" },
                      new Category { Id = 6, Name = "Green household cleaning supplies" },
                      new Category { Id = 7, Name = "Eco-friendly outerwear" }
                );
            modelBuilder.Entity<ProductCategory>().HasData
                (
                      new ProductCategory { Id = 1, ProductId = 1, CategoryId = 1 },
                      new ProductCategory { Id = 2, ProductId = 1, CategoryId = 4 }
                );
            modelBuilder.Entity<User>().HasData
                 (
                       new User
                       {
                           Id = 1,
                           Username = "MiKE",
                           Password = "123456789",
                           Firstname = "Mike",
                           Surname = "Mikel",
                           Email = "Mike@gmail.com",
                           Address = "Damascus",
                           Phone = "0937396587",
                           Role = "StandardUser"

                       },
                        new User
                        {
                            Id = 2,
                            Username = "admin123",
                            Password = "Admin123",
                            Firstname = "Admin",
                            Surname = "Admin",
                            Email = "Admin@gmail.com",
                            Address = "Damascus",
                            Phone = "0937366587",
                            Role = "Admin"

                        }
                        );
        }

        public DbSet<Product> Producs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
