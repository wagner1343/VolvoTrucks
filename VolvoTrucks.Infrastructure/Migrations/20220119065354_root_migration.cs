using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VolvoTrucks.Infrastructure.Migrations
{
    public partial class root_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TruckModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TruckModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturingYear = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelYear = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Truck_TruckModel_ModelId",
                        column: x => x.ModelId,
                        principalTable: "TruckModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TruckModel",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { -2, new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FH" });

            migrationBuilder.InsertData(
                table: "TruckModel",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[] { -1, new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FM" });

            migrationBuilder.CreateIndex(
                name: "IX_Truck_ModelId",
                table: "Truck",
                column: "ModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "TruckModel");
        }
    }
}
