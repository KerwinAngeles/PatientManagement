using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfiPropertyLabResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LaboratoryTestResults_IdLaboratoryTest",
                table: "LaboratoryTestResults");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTestResults_IdLaboratoryTest",
                table: "LaboratoryTestResults",
                column: "IdLaboratoryTest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LaboratoryTestResults_IdLaboratoryTest",
                table: "LaboratoryTestResults");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryTestResults_IdLaboratoryTest",
                table: "LaboratoryTestResults",
                column: "IdLaboratoryTest",
                unique: true);
        }
    }
}
