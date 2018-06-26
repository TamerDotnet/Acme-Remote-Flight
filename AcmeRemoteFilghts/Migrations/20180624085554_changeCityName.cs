using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeRemoteFilghts.Migrations
{
    public partial class changeCityName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityTo",
                table: "Flights",
                newName: "CityToId");

            migrationBuilder.RenameColumn(
                name: "CityFrom",
                table: "Flights",
                newName: "CityFromId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityToId",
                table: "Flights",
                newName: "CityTo");

            migrationBuilder.RenameColumn(
                name: "CityFromId",
                table: "Flights",
                newName: "CityFrom");
        }
    }
}
