using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlaces_API.Migrations
{
    public partial class foreignKeyPlacesInPlacesNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "PlacesNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_PlacesNumbers_PlaceId",
                table: "PlacesNumbers",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacesNumbers_Places_PlaceId",
                table: "PlacesNumbers",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlacesNumbers_Places_PlaceId",
                table: "PlacesNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PlacesNumbers_PlaceId",
                table: "PlacesNumbers");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "PlacesNumbers");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3666), new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3675) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3676), new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LastDate" },
                values: new object[] { new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3677), new DateTime(2023, 5, 10, 23, 48, 17, 65, DateTimeKind.Local).AddTicks(3677) });
        }
    }
}
