using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Excercise8.Migrations
{
    /// <inheritdoc />
    public partial class WithData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "drhouse@gmail.com", "Gregory", "House" },
                    { 2, "drmurphy@gmail.com ", "Shoun", "Murphy" },
                    { 3, "drFrankenshtein@gmail.com", "Wiktor", "Frankenstein" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "paracetamol", "Apap", "Przeciwbolowy" },
                    { 2, "Kwas acetylosalicylowy", "Aspiryna", "Przeciwzapalny" },
                    { 3, "Lotarydyna", "Claritine", "Przeciw alergiczny" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maks", "Janas" },
                    { 2, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne", "Johnson" },
                    { 3, new DateTime(1982, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Son", "Goku" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 12, 13, 57, 24, 528, DateTimeKind.Local).AddTicks(8824), new DateTime(2023, 5, 12, 13, 57, 24, 528, DateTimeKind.Local).AddTicks(8869), 1, 3 },
                    { 2, new DateTime(2023, 5, 12, 13, 57, 24, 528, DateTimeKind.Local).AddTicks(8873), new DateTime(2023, 5, 12, 13, 57, 24, 528, DateTimeKind.Local).AddTicks(8875), 2, 1 },
                    { 3, new DateTime(2023, 5, 12, 13, 57, 24, 528, DateTimeKind.Local).AddTicks(8878), new DateTime(2023, 5, 12, 13, 57, 24, 528, DateTimeKind.Local).AddTicks(8880), 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 1, 2, "Rano i wieczorem", 2 },
                    { 2, 3, "Po kazdym posilku", 1 },
                    { 3, 1, "Przed snem", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicament",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}
