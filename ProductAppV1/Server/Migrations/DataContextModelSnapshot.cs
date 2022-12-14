// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductAppV1.Server.Data;

#nullable disable

namespace ProductAppV1.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductAppV1.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "High-end foundation makeup"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bedding"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Jewelry"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Skin care"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Grocery essentials"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Green household cleaning supplies"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Eco-friendly outerwear"
                        });
                });

            modelBuilder.Entity("ProductAppV1.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "it helps to have singer and business powerhouse Rihanna at the helm.",
                            Name = "Fenty Beauty",
                            Price = 2.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Putting together their furniture may be a tough task, but at least Ikea supports your relaxation too",
                            Name = "Ikea",
                            Price = 4.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "For more than a century, Swarovski has put the sparkle in gowns, tiaras, jewelry, sculptures, and even luxury cars",
                            Name = "Swarovski",
                            Price = 20.0
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "Dove’s ‘Real Beauty’ campaign was far ahead of other brands in promoting body positivity and self-acceptance.",
                            Name = "Dove",
                            Price = 6.0
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 4,
                            Description = "Deep-clean your complexion with SkinCeuticals' foam face wash, which is infused with glycerin and cucumber extract",
                            Name = "Soothing Cleanser",
                            Price = 15.0
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 4,
                            Description = "With a powder-fresh scent and mild suds, Cetaphil's dermatologist-recommended face wash.",
                            Name = "Daily Facial Cleanser",
                            Price = 10.0
                        });
                });

            modelBuilder.Entity("ProductAppV1.Shared.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("ProductAppV1.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Damascus",
                            Email = "Mike@gmail.com",
                            Firstname = "Mike",
                            Password = "123456789",
                            Phone = "0937396587",
                            Role = "StandardUser",
                            Surname = "Mikel",
                            Username = "MiKE"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Damascus",
                            Email = "Admin@gmail.com",
                            Firstname = "Admin",
                            Password = "Admin123",
                            Phone = "0937366587",
                            Role = "Admin",
                            Surname = "Admin",
                            Username = "admin123"
                        });
                });

            modelBuilder.Entity("ProductAppV1.Shared.Product", b =>
                {
                    b.HasOne("ProductAppV1.Shared.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductAppV1.Shared.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
