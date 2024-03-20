using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Excercise8.Migrations
{
    /// <inheritdoc />
    public partial class zad10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 19, 15, 24, 18, 621, DateTimeKind.Local).AddTicks(5951), new DateTime(2023, 5, 19, 15, 24, 18, 621, DateTimeKind.Local).AddTicks(5996) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 19, 15, 24, 18, 621, DateTimeKind.Local).AddTicks(6004), new DateTime(2023, 5, 19, 15, 24, 18, 621, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 19, 15, 24, 18, 621, DateTimeKind.Local).AddTicks(6011), new DateTime(2023, 5, 19, 15, 24, 18, 621, DateTimeKind.Local).AddTicks(6014) });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "ID", "Login", "Password" },
                values: new object[] { 1, "maXo", "password" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7290), new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7332) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7337), new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7338) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 3,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7341), new DateTime(2023, 5, 12, 17, 13, 35, 729, DateTimeKind.Local).AddTicks(7343) });
        }
    }
}
