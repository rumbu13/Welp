using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Welp.Web.Data.Migrations
{
    public partial class FinalStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Icon = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: true),
                    LastKnownLatitude = table.Column<double>(nullable: false),
                    LastKnownLongitude = table.Column<double>(nullable: false),
                    LastKnownTimestamp = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: true),
                    PhoneNo = table.Column<string>(maxLength: 40, nullable: true),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Probability = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LargeIcon = table.Column<string>(nullable: true),
                    MediumIcon = table.Column<string>(nullable: true),
                    SmallIcon = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountyId = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localities_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQs_FAQCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FAQCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientProfileId = table.Column<string>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false),
                    RequestTimestamp = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Profiles_ClientProfileId",
                        column: x => x.ClientProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanBePerformedOnline = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    IncludedPrestations = table.Column<string>(nullable: true),
                    LargeIcon = table.Column<string>(nullable: true),
                    MediumIcon = table.Column<string>(nullable: true),
                    OnlineDiscount = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SmallIcon = table.Column<string>(nullable: true),
                    StandardDuration = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 150, nullable: false),
                    Title = table.Column<string>(nullable: false),
                    WelpServiceCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Categories_WelpServiceCategoryId",
                        column: x => x.WelpServiceCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contact = table.Column<string>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    LocalityId = table.Column<int>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    ProfileId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    Bank = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    LocalityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProfileId = table.Column<string>(nullable: true),
                    RegistrationNo = table.Column<string>(nullable: true),
                    TaxCode = table.Column<string>(nullable: true),
                    VATFree = table.Column<bool>(nullable: false),
                    VATOnCash = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceData_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceData_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanBePerformedOnline = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IncreaseOrDecreaseFixed = table.Column<decimal>(nullable: true),
                    IncreaseOrDecreasePercent = table.Column<decimal>(nullable: true),
                    Text = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    WelpServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Services_WelpServiceId",
                        column: x => x.WelpServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    InvoiceDataId = table.Column<int>(nullable: false),
                    LastState = table.Column<int>(nullable: false),
                    ProviderAccount = table.Column<string>(nullable: true),
                    ProviderAddress = table.Column<string>(nullable: false),
                    ProviderBank = table.Column<string>(nullable: true),
                    ProviderContact = table.Column<string>(nullable: false),
                    ProviderLocalityId = table.Column<int>(nullable: false),
                    ProviderName = table.Column<string>(nullable: false),
                    ProviderRegistrationNo = table.Column<string>(nullable: true),
                    ProviderTaxCode = table.Column<string>(nullable: true),
                    ReverseInvoiceId = table.Column<int>(nullable: true),
                    TotalGross = table.Column<decimal>(nullable: false),
                    TotalNet = table.Column<decimal>(nullable: false),
                    TotalVAT = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientInvoices_Profiles_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientInvoices_InvoiceData_InvoiceDataId",
                        column: x => x.InvoiceDataId,
                        principalTable: "InvoiceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientInvoices_Localities_ProviderLocalityId",
                        column: x => x.ProviderLocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientInvoices_ClientInvoices_ReverseInvoiceId",
                        column: x => x.ReverseInvoiceId,
                        principalTable: "ClientInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WelperInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientAccount = table.Column<string>(nullable: true),
                    ClientAddress = table.Column<string>(nullable: false),
                    ClientBank = table.Column<string>(nullable: true),
                    ClientContact = table.Column<string>(nullable: false),
                    ClientLocalityId = table.Column<int>(nullable: false),
                    ClientName = table.Column<string>(nullable: false),
                    ClientRegistrationNo = table.Column<string>(nullable: true),
                    ClientTaxCode = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    InvoiceDataId = table.Column<int>(nullable: false),
                    LastState = table.Column<int>(nullable: false),
                    ReverseInvoiceId = table.Column<int>(nullable: true),
                    TotalGross = table.Column<decimal>(nullable: false),
                    TotalNet = table.Column<decimal>(nullable: false),
                    TotalVAT = table.Column<decimal>(nullable: false),
                    VATFree = table.Column<bool>(nullable: false),
                    VATOnCash = table.Column<bool>(nullable: false),
                    WelperId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WelperInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WelperInvoices_Localities_ClientLocalityId",
                        column: x => x.ClientLocalityId,
                        principalTable: "Localities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WelperInvoices_InvoiceData_InvoiceDataId",
                        column: x => x.InvoiceDataId,
                        principalTable: "InvoiceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WelperInvoices_WelperInvoices_ReverseInvoiceId",
                        column: x => x.ReverseInvoiceId,
                        principalTable: "WelperInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WelperInvoices_Profiles_WelperId",
                        column: x => x.WelperId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DropItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanBePerformedOnline = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IncreaseOrDecreaseFixed = table.Column<decimal>(nullable: true),
                    IncreaseOrDecreasePercent = table.Column<decimal>(nullable: true),
                    Text = table.Column<string>(maxLength: 100, nullable: false),
                    WelpServiceOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropItems_Options_WelpServiceOptionId",
                        column: x => x.WelpServiceOptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientInvoiceStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInvoiceStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientInvoiceStates_ClientInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "ClientInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WelperInvoiceStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WelperInvoiceStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WelperInvoiceStates_WelperInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "WelperInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientInvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Gross = table.Column<decimal>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    Net = table.Column<decimal>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientInvoiceItems_ClientInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "ClientInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientInvoiceItemId = table.Column<int>(nullable: true),
                    DeliveryAddress = table.Column<string>(nullable: true),
                    DeliveryLatitude = table.Column<double>(nullable: false),
                    DeliveryLongitude = table.Column<double>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false),
                    LastState = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ProfileId = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    SourceAddress = table.Column<string>(nullable: true),
                    SourceLatitude = table.Column<double>(nullable: false),
                    SourceLongitude = table.Column<double>(nullable: false),
                    WelperInvoiceItemId = table.Column<int>(nullable: true),
                    WelperProfileId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_ClientInvoiceItems_ClientInvoiceItemId",
                        column: x => x.ClientInvoiceItemId,
                        principalTable: "ClientInvoiceItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Profiles_WelperProfileId",
                        column: x => x.WelperProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderItemId = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStates_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WelperInvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Gross = table.Column<decimal>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    Net = table.Column<decimal>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WelperInvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WelperInvoiceItems_WelperInvoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "WelperInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WelperInvoiceItems_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LocalityId",
                table: "Addresses",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProfileId",
                table: "Addresses",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoices_ClientId",
                table: "ClientInvoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoices_InvoiceDataId",
                table: "ClientInvoices",
                column: "InvoiceDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoices_ProviderLocalityId",
                table: "ClientInvoices",
                column: "ProviderLocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoices_ReverseInvoiceId",
                table: "ClientInvoices",
                column: "ReverseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoiceItems_InvoiceId",
                table: "ClientInvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoiceItems_OrderItemId",
                table: "ClientInvoiceItems",
                column: "OrderItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientInvoiceStates_InvoiceId",
                table: "ClientInvoiceStates",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQs_CategoryId",
                table: "FAQs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceData_LocalityId",
                table: "InvoiceData",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceData_ProfileId",
                table: "InvoiceData",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_CountyId",
                table: "Localities",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientProfileId",
                table: "Orders",
                column: "ClientProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ClientInvoiceItemId",
                table: "OrderItems",
                column: "ClientInvoiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProfileId",
                table: "OrderItems",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_WelperInvoiceItemId",
                table: "OrderItems",
                column: "WelperInvoiceItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_WelperProfileId",
                table: "OrderItems",
                column: "WelperProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStates_OrderItemId",
                table: "OrderStates",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WelperInvoices_ClientLocalityId",
                table: "WelperInvoices",
                column: "ClientLocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_WelperInvoices_InvoiceDataId",
                table: "WelperInvoices",
                column: "InvoiceDataId");

            migrationBuilder.CreateIndex(
                name: "IX_WelperInvoices_ReverseInvoiceId",
                table: "WelperInvoices",
                column: "ReverseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WelperInvoices_WelperId",
                table: "WelperInvoices",
                column: "WelperId");

            migrationBuilder.CreateIndex(
                name: "IX_WelperInvoiceItems_InvoiceId",
                table: "WelperInvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_WelperInvoiceItems_OrderItemId",
                table: "WelperInvoiceItems",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WelperInvoiceStates_InvoiceId",
                table: "WelperInvoiceStates",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_WelpServiceCategoryId",
                table: "Services",
                column: "WelpServiceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_WelpServiceId",
                table: "Options",
                column: "WelpServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DropItems_WelpServiceOptionId",
                table: "DropItems",
                column: "WelpServiceOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientInvoiceItems_OrderItems_OrderItemId",
                table: "ClientInvoiceItems",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_WelperInvoiceItems_WelperInvoiceItemId",
                table: "OrderItems",
                column: "WelperInvoiceItemId",
                principalTable: "WelperInvoiceItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_Localities_ProviderLocalityId",
                table: "ClientInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceData_Localities_LocalityId",
                table: "InvoiceData");

            migrationBuilder.DropForeignKey(
                name: "FK_WelperInvoices_Localities_ClientLocalityId",
                table: "WelperInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_Profiles_ClientId",
                table: "ClientInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceData_Profiles_ProfileId",
                table: "InvoiceData");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Profiles_ClientProfileId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Profiles_ProfileId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Profiles_WelperProfileId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WelperInvoices_Profiles_WelperId",
                table: "WelperInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoices_InvoiceData_InvoiceDataId",
                table: "ClientInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_WelperInvoices_InvoiceData_InvoiceDataId",
                table: "WelperInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoiceItems_ClientInvoices_InvoiceId",
                table: "ClientInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientInvoiceItems_OrderItems_OrderItemId",
                table: "ClientInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WelperInvoiceItems_OrderItems_OrderItemId",
                table: "WelperInvoiceItems");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ClientInvoiceStates");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "OrderStates");

            migrationBuilder.DropTable(
                name: "TagLines");

            migrationBuilder.DropTable(
                name: "WelperInvoiceStates");

            migrationBuilder.DropTable(
                name: "DropItems");

            migrationBuilder.DropTable(
                name: "FAQCategories");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "InvoiceData");

            migrationBuilder.DropTable(
                name: "ClientInvoices");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ClientInvoiceItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WelperInvoiceItems");

            migrationBuilder.DropTable(
                name: "WelperInvoices");
        }
    }
}
