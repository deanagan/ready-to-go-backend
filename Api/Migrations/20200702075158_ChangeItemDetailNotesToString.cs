using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class ChangeItemDetailNotesToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "ItemDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notes",
                value: "Some notes");

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Notes",
                value: "Some notes");

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Notes",
                value: "Some notes");

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Notes",
                value: "Some notes");

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Notes",
                value: "Some notes");

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Notes",
                value: "Some notes");

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Notes",
                value: "Some notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Notes",
                table: "ItemDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Notes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Notes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Notes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Notes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Notes",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Notes",
                value: 0);
        }
    }
}
