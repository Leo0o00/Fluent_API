using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fluent_API.Migrations
{
    /// <inheritdoc />
    public partial class DatosInicialesAñadidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb71235eb"),
                column: "FechaCreacion",
                value: new DateTime(2024, 1, 9, 12, 23, 29, 241, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-7d85-4c29-9ad0-7c6eb70236eb"),
                column: "FechaCreacion",
                value: new DateTime(2024, 1, 9, 12, 23, 29, 241, DateTimeKind.Local).AddTicks(9850));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb71235eb"),
                column: "FechaCreacion",
                value: new DateTime(2024, 1, 9, 12, 19, 49, 400, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-7d85-4c29-9ad0-7c6eb70236eb"),
                column: "FechaCreacion",
                value: new DateTime(2024, 1, 9, 12, 19, 49, 400, DateTimeKind.Local).AddTicks(5274));
        }
    }
}
