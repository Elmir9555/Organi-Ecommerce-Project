using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProjectOrgani.Migrations
{
    public partial class createclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Fullname = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Profession = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleOffs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    OldPrice = table.Column<decimal>(nullable: false),
                    NewPrice = table.Column<decimal>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleOffDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(nullable: false),
                    Availability = table.Column<bool>(nullable: false),
                    StarCount = table.Column<int>(nullable: false),
                    SaleOffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOffDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleOffDetails_SaleOffs_SaleOffId",
                        column: x => x.SaleOffId,
                        principalTable: "SaleOffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogDetails_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifatedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: false),
                    SaleOffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_SaleOffs_SaleOffId",
                        column: x => x.SaleOffId,
                        principalTable: "SaleOffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogDetails_BlogId",
                table: "BlogDetails",
                column: "BlogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_OwnerId",
                table: "Blogs",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SaleOffId",
                table: "Comments",
                column: "SaleOffId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOffDetails_SaleOffId",
                table: "SaleOffDetails",
                column: "SaleOffId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogDetails");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SaleOffDetails");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "SaleOffs");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
