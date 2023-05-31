using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlaces_API.Migrations
{
    public partial class NullableFalse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "PlacesNumbers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 30, 20, 11, 44, 48, DateTimeKind.Local).AddTicks(276), new DateTime(2023, 5, 30, 20, 11, 44, 48, DateTimeKind.Local).AddTicks(283) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 30, 20, 11, 44, 48, DateTimeKind.Local).AddTicks(285), new DateTime(2023, 5, 30, 20, 11, 44, 48, DateTimeKind.Local).AddTicks(285) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 30, 20, 11, 44, 48, DateTimeKind.Local).AddTicks(286), new DateTime(2023, 5, 30, 20, 11, 44, 48, DateTimeKind.Local).AddTicks(287) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SpecialDetails",
                table: "PlacesNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 11, 0, 5, 34, 669, DateTimeKind.Local).AddTicks(7574), new DateTime(2023, 5, 11, 0, 5, 34, 669, DateTimeKind.Local).AddTicks(7582) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 11, 0, 5, 34, 669, DateTimeKind.Local).AddTicks(7584), new DateTime(2023, 5, 11, 0, 5, 34, 669, DateTimeKind.Local).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 11, 0, 5, 34, 669, DateTimeKind.Local).AddTicks(7585), new DateTime(2023, 5, 11, 0, 5, 34, 669, DateTimeKind.Local).AddTicks(7586) });
        }
    }
}
