using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlaces_API.Migrations
{
    public partial class startingMyDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlacesNumbers",
                columns: table => new
                {
                    PlaceNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesNumbers", x => x.PlaceNo);
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Comment", "CreatedDate", "Details", "LastDate", "Location", "Name", "Rate" },
                values: new object[] { 1, "Você paga pelo local, lindo. Não pela comida.", new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3666), "Um restaurante tematizado ao estilo medieval.", new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3675), "St. Bueno. T2", "Tavernna", 8.4000000000000004 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Comment", "CreatedDate", "Details", "LastDate", "Location", "Name", "Rate" },
                values: new object[] { 2, "A comida está mais do que aprovada.", new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3676), "Um bom local para uma bebida.", new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3676), "St. Bela Vista", "OFFICINA", 8.5 });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Comment", "CreatedDate", "Details", "LastDate", "Location", "Name", "Rate" },
                values: new object[] { 3, "A comida e atendimento são exemplares. Ótimo local.", new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3677), "Um restaurante/sanduicheria muito gostosa.", new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3677), "Próximo ao Flamboyant Shopping", "LIFE BOX", 9.1999999999999993 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "PlacesNumbers");
        }
    }
}
