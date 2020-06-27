using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class UpdatedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckListToItemDetails",
                keyColumns: new[] { "ItemDetailId", "CheckListId" },
                keyValues: new object[] { 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CheckListToItemDetails",
                columns: new[] { "ItemDetailId", "CheckListId" },
                values: new object[] { 1, 2 });
        }
    }
}
