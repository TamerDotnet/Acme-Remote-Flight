using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeRemoteFilghts.Migrations
{
    public partial class AddCityToObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Flights_CityToId",
                table: "Flights",
                column: "CityToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Cities_CityToId",
                table: "Flights",
                column: "CityToId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Cities_CityToId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_CityToId",
                table: "Flights");
        }
    }
}
