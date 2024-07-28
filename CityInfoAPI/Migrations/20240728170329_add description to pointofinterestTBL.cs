using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfoAPI.Migrations
{
    public partial class adddescriptiontopointofinterestTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PointOfInterest",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PointOfInterest");
        }
    }
}
