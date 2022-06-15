using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProjectOrgani.Migrations
{
    public partial class addbyname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ByName",
                table: "Comments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ByName",
                table: "Comments");
        }
    }
}
