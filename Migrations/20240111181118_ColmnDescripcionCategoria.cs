using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fluent_API.Migrations
{
    /// <inheritdoc />
    public partial class ColmnDescripcionCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Categoria");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-7d85-4d28-9ad0-7c6eb71235eb"),
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Esta es una descripcion", new DateTime(2024, 1, 11, 12, 11, 18, 336, DateTimeKind.Local).AddTicks(442) });

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-8d85-4c29-9ad0-7c6eb70236eb"),
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Esta es una descripcion", new DateTime(2024, 1, 11, 12, 11, 18, 336, DateTimeKind.Local).AddTicks(486) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Tarea");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb70235eb"),
                column: "Descripcion",
                value: "Esta es una descripcion");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("907f7cf7-7d85-4c28-9ad0-7c6eb70236eb"),
                column: "Descripcion",
                value: "Esta es una descripcion");

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-7d85-4d28-9ad0-7c6eb71235eb"),
                column: "FechaCreacion",
                value: new DateTime(2024, 1, 10, 21, 50, 13, 541, DateTimeKind.Local).AddTicks(8003));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("907f7cf7-8d85-4c29-9ad0-7c6eb70236eb"),
                column: "FechaCreacion",
                value: new DateTime(2024, 1, 10, 21, 50, 13, 541, DateTimeKind.Local).AddTicks(8042));
        }
    }
}
