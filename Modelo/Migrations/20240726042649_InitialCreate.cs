using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modelo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    TecnicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreyApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<long>(type: "bigint", nullable: false),
                    Legajo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadTickets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.TecnicoId);
                });

            migrationBuilder.CreateTable(
                name: "Universidades",
                columns: table => new
                {
                    UniversidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUniversidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universidades", x => x.UniversidadId);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionSede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversidadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.SedeId);
                    table.ForeignKey(
                        name: "FK_Sedes_Universidades_UniversidadId",
                        column: x => x.UniversidadId,
                        principalTable: "Universidades",
                        principalColumn: "UniversidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computadoras",
                columns: table => new
                {
                    ComputadoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoComputadora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaboratorioId = table.Column<int>(type: "int", nullable: false),
                    NombreSede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionComputadora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    condicion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computadoras", x => x.ComputadoraId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputadoraId = table.Column<int>(type: "int", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreSede = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescripcionTicket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TecnicoId = table.Column<int>(type: "int", nullable: false),
                    categoria = table.Column<int>(type: "int", nullable: false),
                    urgencia = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Computadoras_ComputadoraId",
                        column: x => x.ComputadoraId,
                        principalTable: "Computadoras",
                        principalColumn: "ComputadoraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "TecnicoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorios",
                columns: table => new
                {
                    LaboratorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreLaboratorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadMaxima = table.Column<int>(type: "int", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorios", x => x.LaboratorioId);
                    table.ForeignKey(
                        name: "FK_Laboratorios_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Laboratorios_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computadoras_LaboratorioId",
                table: "Computadoras",
                column: "LaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorios_SedeId",
                table: "Laboratorios",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratorios_TicketId",
                table: "Laboratorios",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_UniversidadId",
                table: "Sedes",
                column: "UniversidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ComputadoraId",
                table: "Tickets",
                column: "ComputadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TecnicoId",
                table: "Tickets",
                column: "TecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computadoras_Laboratorios_LaboratorioId",
                table: "Computadoras",
                column: "LaboratorioId",
                principalTable: "Laboratorios",
                principalColumn: "LaboratorioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computadoras_Laboratorios_LaboratorioId",
                table: "Computadoras");

            migrationBuilder.DropTable(
                name: "Laboratorios");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Universidades");

            migrationBuilder.DropTable(
                name: "Computadoras");

            migrationBuilder.DropTable(
                name: "Tecnicos");
        }
    }
}
