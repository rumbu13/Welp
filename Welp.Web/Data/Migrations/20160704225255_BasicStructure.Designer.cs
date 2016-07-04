using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Welp.Web.Data;

namespace Welp.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160704225255_BasicStructure")]
    partial class BasicStructure
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

                    b.Property<DateTime>("AvailableFrom");

                    b.Property<DateTime>("AvailableTo");

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

            modelBuilder.Entity("Welp.Web.Models.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Counties");
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

            modelBuilder.Entity("Welp.Web.Models.Profile", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .HasAnnotation("MaxLength", 150);

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
                        .WithMany()
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Welp.Web.Models.Profile", "Profile")
                        .WithMany("Addresses")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("Welp.Web.Models.Locality", b =>
                {
                    b.HasOne("Welp.Web.Models.County", "County")
                        .WithMany("Localities")
                        .HasForeignKey("CountyId")
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
