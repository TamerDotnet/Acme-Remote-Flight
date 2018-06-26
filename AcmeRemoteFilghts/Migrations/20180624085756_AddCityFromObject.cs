using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeRemoteFilghts.Migrations
{
    public partial class AddCityFromObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Flights_CityFromId",
                table: "Flights",
                column: "CityFromId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cities_CityFromId",
                table: "Flights",
                column: "CityFromId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cities_CityFromId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_CityFromId",
                table: "Flights");
        }
    }
}
