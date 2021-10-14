using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePetCare.App.Persistencia.Migrations
{
    public partial class Inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreVeterinario",
                table: "Mascotas",
                newName: "VeterinarioNombre");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVisita",
                table: "Mascotas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recomendaciones",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaVisita",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Recomendaciones",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "VeterinarioNombre",
                table: "Mascotas",
                newName: "NombreVeterinario");
        }
    }
}
