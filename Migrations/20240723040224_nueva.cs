using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaKinesiologia.Migrations
{
    /// <inheritdoc />
    public partial class nueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kinesiologos",
                columns: table => new
                {
                    IdKinesiologo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kinesiologos", x => x.IdKinesiologo);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antecedente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObraSocial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Lesiones",
                columns: table => new
                {
                    IdLesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Medico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Consideraciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesiones", x => x.IdLesion);
                    table.ForeignKey(
                        name: "FK_Lesiones_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    IdEvaluacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreTabla1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila1T1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila2T1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila3T1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila4T1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila5T1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreTabla2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila1T2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila2T2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila3T2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila4T2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila5T2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdKinesiologo = table.Column<int>(type: "int", nullable: false),
                    IdLesion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.IdEvaluacion);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Kinesiologos_IdKinesiologo",
                        column: x => x.IdKinesiologo,
                        principalTable: "Kinesiologos",
                        principalColumn: "IdKinesiologo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Lesiones_IdLesion",
                        column: x => x.IdLesion,
                        principalTable: "Lesiones",
                        principalColumn: "IdLesion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    IdPlanGimnasio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TituloColumna1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloColumna2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TituloColumna3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fila5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLesion = table.Column<int>(type: "int", nullable: true),
                    IdKinesiologo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.IdPlanGimnasio);
                    table.ForeignKey(
                        name: "FK_Planes_Kinesiologos_IdKinesiologo",
                        column: x => x.IdKinesiologo,
                        principalTable: "Kinesiologos",
                        principalColumn: "IdKinesiologo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planes_Lesiones_IdLesion",
                        column: x => x.IdLesion,
                        principalTable: "Lesiones",
                        principalColumn: "IdLesion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    IdSesion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLesion = table.Column<int>(type: "int", nullable: true),
                    IdKinesiologo = table.Column<int>(type: "int", nullable: false),
                    IdPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.IdSesion);
                    table.ForeignKey(
                        name: "FK_Sesiones_Kinesiologos_IdKinesiologo",
                        column: x => x.IdKinesiologo,
                        principalTable: "Kinesiologos",
                        principalColumn: "IdKinesiologo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sesiones_Lesiones_IdLesion",
                        column: x => x.IdLesion,
                        principalTable: "Lesiones",
                        principalColumn: "IdLesion");
                    table.ForeignKey(
                        name: "FK_Sesiones_Pacientes_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_IdKinesiologo",
                table: "Evaluaciones",
                column: "IdKinesiologo");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluaciones_IdLesion",
                table: "Evaluaciones",
                column: "IdLesion");

            migrationBuilder.CreateIndex(
                name: "IX_Lesiones_IdPaciente",
                table: "Lesiones",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_IdKinesiologo",
                table: "Planes",
                column: "IdKinesiologo");

            migrationBuilder.CreateIndex(
                name: "IX_Planes_IdLesion",
                table: "Planes",
                column: "IdLesion");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_IdKinesiologo",
                table: "Sesiones",
                column: "IdKinesiologo");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_IdLesion",
                table: "Sesiones",
                column: "IdLesion");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_IdPaciente",
                table: "Sesiones",
                column: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Kinesiologos");

            migrationBuilder.DropTable(
                name: "Lesiones");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
