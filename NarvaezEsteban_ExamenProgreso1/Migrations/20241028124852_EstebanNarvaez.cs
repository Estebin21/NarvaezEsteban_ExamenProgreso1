using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NarvaezEsteban_ExamenProgreso1.Migrations
{
    /// <inheritdoc />
    public partial class EstebanNarvaez : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celular",
                columns: table => new
                {
                    IdCelular = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    año = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celular", x => x.IdCelular);
                });

            migrationBuilder.CreateTable(
                name: "Narvaez",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<float>(type: "real", nullable: false),
                    Nacionalidad = table.Column<bool>(type: "bit", nullable: false),
                    Fechanacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    IdCelular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narvaez", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narvaez_Celular_IdCelular",
                        column: x => x.IdCelular,
                        principalTable: "Celular",
                        principalColumn: "IdCelular",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narvaez_IdCelular",
                table: "Narvaez",
                column: "IdCelular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narvaez");

            migrationBuilder.DropTable(
                name: "Celular");
        }
    }
}
