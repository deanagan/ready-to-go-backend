using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class ModifiedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Full Marathon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CheckLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "T-shirt");
        }
    }
}
