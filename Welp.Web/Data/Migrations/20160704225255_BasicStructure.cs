using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Welp.Web.Data.Migrations
{
    public partial class BasicStructure : Migration
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
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: true),
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
                    AvailableFrom = table.Column<DateTime>(nullable: false),
                    AvailableTo = table.Column<DateTime>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LocalityId",
                table: "Addresses",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProfileId",
                table: "Addresses",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_CountyId",
                table: "Localities",
                column: "CountyId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "TagLines");

            migrationBuilder.DropTable(
                name: "DropItems");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
