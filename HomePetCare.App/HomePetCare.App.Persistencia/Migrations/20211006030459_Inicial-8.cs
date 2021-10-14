using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePetCare.App.Persistencia.Migrations
{
    public partial class Inicial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropietarioId",
                table: "Mascotas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarioId",
                table: "Mascotas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VisitaId",
                table: "Mascotas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_PropietarioId",
                table: "Mascotas",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_VeterinarioId",
                table: "Mascotas",
                column: "VeterinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_VisitaId",
                table: "Mascotas",
                column: "VisitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Propietarios_PropietarioId",
                table: "Mascotas",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "PropietarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Veterinarios_VeterinarioId",
                table: "Mascotas",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Visitas_VisitaId",
                table: "Mascotas",
                column: "VisitaId",
                principalTable: "Visitas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Propietarios_PropietarioId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Veterinarios_VeterinarioId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Visitas_VisitaId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_PropietarioId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_VeterinarioId",
                table: "Mascotas");

            migrationBuilder.DropIndex(
                name: "IX_Mascotas_VisitaId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "PropietarioId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "VeterinarioId",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "VisitaId",
                table: "Mascotas");
        }
    }
}
