using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlaces_API.Migrations
{
    public partial class SeedPlacesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Comment", "CreatedDate", "Details", "LastDate", "Location", "Name", "Rate" },
                values: new object[] { 1, "Você paga pelo local, lindo. Não pela comida.", new DateTime(2022, 9, 19, 3, 12, 0, 427, DateTimeKind.Local).AddTicks(6664), "Um restaurante tematizado ao estilo medieval.", new DateTime(2022, 9, 19, 3, 12, 0, 427, DateTimeKind.Local).AddTicks(6671), "St. Bueno. T2", "Tavernna", 8.4000000000000004 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Comment", "CreatedDate", "Details", "LastDate", "Location", "Name", "Rate" },
                values: new object[] { 2, "A comida está mais do que aprovada.", new DateTime(2022, 9, 19, 3, 12, 0, 427, DateTimeKind.Local).AddTicks(6673), "Um bom local para uma bebida.", new DateTime(2022, 9, 19, 3, 12, 0, 427, DateTimeKind.Local).AddTicks(6673), "St. Bela Vista", "OFFICINA", 8.5 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Comment", "CreatedDate", "Details", "LastDate", "Location", "Name", "Rate" },
                values: new object[] { 3, "A comida e atendimento são exemplares. Ótimo local.", new DateTime(2022, 9, 19, 3, 12, 0, 427, DateTimeKind.Local).AddTicks(6674), "Um restaurante/sanduicheria muito gostosa.", new DateTime(2022, 9, 19, 3, 12, 0, 427, DateTimeKind.Local).AddTicks(6674), "Próximo ao Flamboyant Shopping", "LIFE BOX", 9.1999999999999993 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
