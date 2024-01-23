using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car.Data.Migrations
{
    public partial class Migrat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "CarSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarSet",
                table: "CarSet",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CarSet",
                table: "CarSet");

            migrationBuilder.RenameTable(
                name: "CarSet",
                newName: "Cars");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");
        }
    }
}
