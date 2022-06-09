using Microsoft.EntityFrameworkCore.Migrations;

namespace Cwiczenia6_mp_s21108.Migrations
{
    public partial class AddedSeededData6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 2 },
                column: "Details",
                value: "Szczegóły");

            migrationBuilder.UpdateData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 },
                column: "Details",
                value: "Szczegóły");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 2 },
                column: "Details",
                value: "Szczegóły 1");

            migrationBuilder.UpdateData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 1 },
                column: "Details",
                value: "Szczegóły 2");
        }
    }
}
