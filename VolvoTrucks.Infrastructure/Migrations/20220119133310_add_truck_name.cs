using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolvoTrucks.Infrastructure.Migrations
{
    public partial class add_truck_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Truck",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Truck");
        }
    }
}
