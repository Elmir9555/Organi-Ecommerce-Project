using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProjectOrgani.Migrations
{
    public partial class addemailtosubscribee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Subscribes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Subscribes");
        }
    }
}
