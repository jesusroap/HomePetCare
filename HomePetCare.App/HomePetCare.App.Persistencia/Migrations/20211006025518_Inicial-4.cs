using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePetCare.App.Persistencia.Migrations
{
    public partial class Inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombrePropietario",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreVeterinario",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TarjetaProfesional",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Veterinario_Apellido",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Veterinario_Telefono",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "NombrePropietario",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "NombreVeterinario",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "TarjetaProfesional",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Veterinario_Apellido",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Veterinario_Telefono",
                table: "Mascotas");
        }
    }
}
