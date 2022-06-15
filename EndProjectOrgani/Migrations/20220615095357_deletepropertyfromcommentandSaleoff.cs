using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProjectOrgani.Migrations
{
    public partial class deletepropertyfromcommentandSaleoff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_SaleOffId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "SaleOffId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleOffId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SaleOffId",
                table: "Comments",
                column: "SaleOffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments",
                column: "SaleOffId",
                principalTable: "SaleOffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
