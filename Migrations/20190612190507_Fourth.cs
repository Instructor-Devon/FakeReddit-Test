using Microsoft.EntityFrameworkCore.Migrations;

namespace EFFunzies.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Users",
                type: "VARCHAR(45)",
                nullable: true);
        }
    }
}
