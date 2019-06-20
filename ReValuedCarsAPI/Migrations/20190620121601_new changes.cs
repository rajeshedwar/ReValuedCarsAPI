using Microsoft.EntityFrameworkCore.Migrations;

namespace ReValuedCarsAPI.Migrations
{
    public partial class newchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MakeYear",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MakeYear",
                table: "Cars");
        }
    }
}
