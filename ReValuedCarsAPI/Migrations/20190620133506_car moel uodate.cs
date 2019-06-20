using Microsoft.EntityFrameworkCore.Migrations;

namespace ReValuedCarsAPI.Migrations
{
    public partial class carmoeluodate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityID",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "StateID",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PinCode",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateID",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }
    }
}
