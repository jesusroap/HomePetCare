using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePetCare.App.Persistencia.Migrations
{
    public partial class Inicial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PropietarioId",
                table: "Propietarios",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Propietarios",
                newName: "PropietarioId");
        }
    }
}
