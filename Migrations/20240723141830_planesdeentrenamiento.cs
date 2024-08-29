using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaKinesiologia.Migrations
{
    /// <inheritdoc />
    public partial class planesdeentrenamiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Planes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planes_IdPaciente",
                table: "Planes",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Planes_Pacientes_IdPaciente",
                table: "Planes",
                column: "IdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planes_Pacientes_IdPaciente",
                table: "Planes");

            migrationBuilder.DropIndex(
                name: "IX_Planes_IdPaciente",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Planes");
        }
    }
}
