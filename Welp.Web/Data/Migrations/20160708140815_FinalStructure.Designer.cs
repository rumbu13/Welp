using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Welp.Web.Data;

namespace Welp.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160708140815_FinalStructure")]
    partial class FinalStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Welp.Web.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<bool>("IsDefault");

                    b.Property<double>("Latitude");

                    b.Property<int>("LocalityId");

                    b.Property<double>("Longitude");

                    b.Property<string>("ProfileId");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Welp.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Welp.Web.Models.ClientInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("InvoiceDataId");

                    b.Property<int>("LastState");

                    b.Property<string>("ProviderAccount");

                    b.Property<string>("ProviderAddress")
                        .IsRequired();

                    b.Property<string>("ProviderBank");

                    b.Property<string>("ProviderContact")
                        .IsRequired();

                    b.Property<int>("ProviderLocalityId");

                    b.Property<string>("ProviderName")
                        .IsRequired();

                    b.Property<string>("ProviderRegistrationNo");

                    b.Property<string>("ProviderTaxCode");

                    b.Property<int?>("ReverseInvoiceId");

                    b.Property<decimal>("TotalGross");

                    b.Property<decimal>("TotalNet");

                    b.Property<decimal>("TotalVAT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("InvoiceDataId");

                    b.HasIndex("ProviderLocalityId");

                    b.HasIndex("ReverseInvoiceId");

                    b.ToTable("ClientInvoices");
                });

            modelBuilder.Entity("Welp.Web.Models.ClientInvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<decimal>("Gross");

                    b.Property<int>("InvoiceId");

                    b.Property<decimal>("Net");

                    b.Property<int>("OrderItemId");

                    b.Property<decimal>("VAT");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("OrderItemId")
                        .IsUnique();

                    b.ToTable("ClientInvoiceItems");
                });

            modelBuilder.Entity("Welp.Web.Models.ClientInvoiceStateHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InvoiceId");

                    b.Property<int>("State");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("ClientInvoiceStates");
                });

            modelBuilder.Entity("Welp.Web.Models.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("Welp.Web.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Question")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("Welp.Web.Models.FAQCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Icon");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("FAQCategories");
                });

            modelBuilder.Entity("Welp.Web.Models.InvoiceData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Bank");

                    b.Property<string>("Contact")
                        .IsRequired();

                    b.Property<bool>("IsDefault");

                    b.Property<int>("LocalityId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("ProfileId");

                    b.Property<string>("RegistrationNo");

                    b.Property<string>("TaxCode");

                    b.Property<bool>("VATFree");

                    b.Property<bool>("VATOnCash");

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.HasIndex("ProfileId");

                    b.ToTable("InvoiceData");
                });

            modelBuilder.Entity("Welp.Web.Models.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountyId");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Welp.Web.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientProfileId")
                        .IsRequired();

                    b.Property<bool>("IsOnline");

                    b.Property<DateTime>("RequestTimestamp");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("ClientProfileId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Welp.Web.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientInvoiceItemId");

                    b.Property<string>("DeliveryAddress");

                    b.Property<double>("DeliveryLatitude");

                    b.Property<double>("DeliveryLongitude");

                    b.Property<bool>("IsOnline");

                    b.Property<int>("LastState");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProfileId");

                    b.Property<int>("Rating");

                    b.Property<string>("SourceAddress");

                    b.Property<double>("SourceLatitude");

                    b.Property<double>("SourceLongitude");

                    b.Property<int?>("WelperInvoiceItemId");

                    b.Property<string>("WelperProfileId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClientInvoiceItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("WelperInvoiceItemId")
                        .IsUnique();

                    b.HasIndex("WelperProfileId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Welp.Web.Models.OrderStateHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OrderItemId");

                    b.Property<int>("State");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("OrderItemId");

                    b.ToTable("OrderStates");
                });

            modelBuilder.Entity("Welp.Web.Models.Profile", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<double>("LastKnownLatitude");

                    b.Property<double>("LastKnownLongitude");

                    b.Property<DateTime>("LastKnownTimestamp");

                    b.Property<string>("LastName")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("PhoneNo")
                        .HasAnnotation("MaxLength", 40);

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Welp.Web.Models.TagLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Probability");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 25);

                    b.HasKey("Id");

                    b.ToTable("TagLines");
                });

            modelBuilder.Entity("Welp.Web.Models.WelperInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientAccount");

                    b.Property<string>("ClientAddress")
                        .IsRequired();

                    b.Property<string>("ClientBank");

                    b.Property<string>("ClientContact")
                        .IsRequired();

                    b.Property<int>("ClientLocalityId");

                    b.Property<string>("ClientName")
                        .IsRequired();

                    b.Property<string>("ClientRegistrationNo");

                    b.Property<string>("ClientTaxCode");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("DueDate");

                    b.Property<int>("InvoiceDataId");

                    b.Property<int>("LastState");

                    b.Property<int?>("ReverseInvoiceId");

                    b.Property<decimal>("TotalGross");

                    b.Property<decimal>("TotalNet");

                    b.Property<decimal>("TotalVAT");

                    b.Property<bool>("VATFree");

                    b.Property<bool>("VATOnCash");

                    b.Property<string>("WelperId");

                    b.HasKey("Id");

                    b.HasIndex("ClientLocalityId");

                    b.HasIndex("InvoiceDataId");

                    b.HasIndex("ReverseInvoiceId");

                    b.HasIndex("WelperId");

                    b.ToTable("WelperInvoices");
                });

            modelBuilder.Entity("Welp.Web.Models.WelperInvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<decimal>("Gross");

                    b.Property<int>("InvoiceId");

                    b.Property<decimal>("Net");

                    b.Property<int>("OrderItemId");

                    b.Property<decimal>("VAT");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("OrderItemId");

                    b.ToTable("WelperInvoiceItems");
                });

            modelBuilder.Entity("Welp.Web.Models.WelperInvoiceStateHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InvoiceId");

                    b.Property<int>("State");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("WelperInvoiceStates");
                });

            modelBuilder.Entity("Welp.Web.Models.WelpService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanBePerformedOnline");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("IncludedPrestations");

                    b.Property<string>("LargeIcon");

                    b.Property<string>("MediumIcon");

                    b.Property<decimal>("OnlineDiscount");

                    b.Property<decimal>("Price");

                    b.Property<string>("SmallIcon");

                    b.Property<int>("StandardDuration");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 150);

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("WelpServiceCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("WelpServiceCategoryId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Welp.Web.Models.WelpServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LargeIcon");

                    b.Property<string>("MediumIcon");

                    b.Property<string>("SmallIcon");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Welp.Web.Models.WelpServiceOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanBePerformedOnline");

                    b.Property<string>("Description");

                    b.Property<decimal?>("IncreaseOrDecreaseFixed");

                    b.Property<decimal?>("IncreaseOrDecreasePercent");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Type");

                    b.Property<int>("WelpServiceId");

                    b.HasKey("Id");

                    b.HasIndex("WelpServiceId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Welp.Web.Models.WelpServiceOptionDropItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanBePerformedOnline");

                    b.Property<string>("Description");

                    b.Property<decimal?>("IncreaseOrDecreaseFixed");

                    b.Property<decimal?>("IncreaseOrDecreasePercent");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("WelpServiceOptionId");

                    b.HasKey("Id");

                    b.HasIndex("WelpServiceOptionId");

                    b.ToTable("DropItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Welp.Web.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Welp.Web.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.Address", b =>
                {
                    b.HasOne("Welp.Web.Models.Locality", "Locality")
                        .WithMany("Addresses")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.Profile", "Profile")
                        .WithMany("Addresses")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("Welp.Web.Models.ClientInvoice", b =>
                {
                    b.HasOne("Welp.Web.Models.Profile", "Client")
                        .WithMany("ClientInvoices")
                        .HasForeignKey("ClientId");

                    b.HasOne("Welp.Web.Models.InvoiceData", "InvoiceData")
                        .WithMany()
                        .HasForeignKey("InvoiceDataId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.Locality", "ProviderLocality")
                        .WithMany("ClientInvoices")
                        .HasForeignKey("ProviderLocalityId");

                    b.HasOne("Welp.Web.Models.ClientInvoice", "ReverseInvoice")
                        .WithMany()
                        .HasForeignKey("ReverseInvoiceId");
                });

            modelBuilder.Entity("Welp.Web.Models.ClientInvoiceItem", b =>
                {
                    b.HasOne("Welp.Web.Models.ClientInvoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.OrderItem", "OrderItem")
                        .WithOne()
                        .HasForeignKey("Welp.Web.Models.ClientInvoiceItem", "OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.ClientInvoiceStateHistory", b =>
                {
                    b.HasOne("Welp.Web.Models.ClientInvoice", "Invoice")
                        .WithMany("History")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.FAQ", b =>
                {
                    b.HasOne("Welp.Web.Models.FAQCategory", "Category")
                        .WithMany("FAQs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.InvoiceData", b =>
                {
                    b.HasOne("Welp.Web.Models.Locality", "Locality")
                        .WithMany()
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.Profile", "Profile")
                        .WithMany("InvoiceDatas")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("Welp.Web.Models.Locality", b =>
                {
                    b.HasOne("Welp.Web.Models.County", "County")
                        .WithMany("Localities")
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.Order", b =>
                {
                    b.HasOne("Welp.Web.Models.Profile", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientProfileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.OrderItem", b =>
                {
                    b.HasOne("Welp.Web.Models.ClientInvoiceItem", "ClientInvoiceItem")
                        .WithMany()
                        .HasForeignKey("ClientInvoiceItemId");

                    b.HasOne("Welp.Web.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.Profile")
                        .WithMany("Jobs")
                        .HasForeignKey("ProfileId");

                    b.HasOne("Welp.Web.Models.WelperInvoiceItem", "WelperInvoiceItem")
                        .WithOne()
                        .HasForeignKey("Welp.Web.Models.OrderItem", "WelperInvoiceItemId");

                    b.HasOne("Welp.Web.Models.Profile", "Welper")
                        .WithMany()
                        .HasForeignKey("WelperProfileId");
                });

            modelBuilder.Entity("Welp.Web.Models.OrderStateHistory", b =>
                {
                    b.HasOne("Welp.Web.Models.OrderItem", "OrderItem")
                        .WithMany("History")
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.WelperInvoice", b =>
                {
                    b.HasOne("Welp.Web.Models.Locality", "ClientLocality")
                        .WithMany("WelperInvoices")
                        .HasForeignKey("ClientLocalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.InvoiceData", "InvoiceData")
                        .WithMany()
                        .HasForeignKey("InvoiceDataId");

                    b.HasOne("Welp.Web.Models.WelperInvoice", "ReverseInvoice")
                        .WithMany()
                        .HasForeignKey("ReverseInvoiceId");

                    b.HasOne("Welp.Web.Models.Profile", "Welper")
                        .WithMany("WelperInvoices")
                        .HasForeignKey("WelperId");
                });

            modelBuilder.Entity("Welp.Web.Models.WelperInvoiceItem", b =>
                {
                    b.HasOne("Welp.Web.Models.WelperInvoice", "Invoice")
                        .WithMany("InvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.OrderItem", "OrderItem")
                        .WithMany()
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.WelperInvoiceStateHistory", b =>
                {
                    b.HasOne("Welp.Web.Models.WelperInvoice", "Invoice")
                        .WithMany("History")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.WelpService", b =>
                {
                    b.HasOne("Welp.Web.Models.WelpServiceCategory", "Category")
                        .WithMany("Services")
                        .HasForeignKey("WelpServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.WelpServiceOption", b =>
                {
                    b.HasOne("Welp.Web.Models.WelpService", "Service")
                        .WithMany("Options")
                        .HasForeignKey("WelpServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Welp.Web.Models.WelpServiceOptionDropItem", b =>
                {
                    b.HasOne("Welp.Web.Models.WelpServiceOption", "Option")
                        .WithMany("DropDownItems")
                        .HasForeignKey("WelpServiceOptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
