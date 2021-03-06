using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProjectOrgani.Migrations
{
    public partial class deletepropertyfromcommentt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "SaleOffId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments",
                column: "SaleOffId",
                principalTable: "SaleOffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "SaleOffId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_SaleOffs_SaleOffId",
                table: "Comments",
                column: "SaleOffId",
                principalTable: "SaleOffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
