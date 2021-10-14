using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomePetCare.App.Persistencia.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Propietarios_PropietarioId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Veterinarios_VeterinarioId",
                table: "Mascotas");

            migrationBuilder.DropForeignKey(
                name: "FK_Mascotas_Visita_VisitaId",
                table: "Mascotas");

            migrationBuilder.DropTable(
                name: "Visita");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Visita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita", x => x.Id);
                });

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Veterinarios_VeterinarioId",
                table: "Mascotas",
                column: "VeterinarioId",
                principalTable: "Veterinarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mascotas_Visita_VisitaId",
                table: "Mascotas",
                column: "VisitaId",
                principalTable: "Visita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
