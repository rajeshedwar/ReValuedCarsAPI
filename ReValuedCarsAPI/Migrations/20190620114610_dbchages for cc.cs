using Microsoft.EntityFrameworkCore.Migrations;

namespace ReValuedCarsAPI.Migrations
{
    public partial class dbchagesforcc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "Models",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CC",
                table: "Models");
        }
    }
}
