using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class MoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckListToItems",
                keyColumns: new[] { "ItemId", "CheckListId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "CheckLists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Trip to Jervis Bay!", "Jervis Bay Trip" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ItemDetailId", "Name" },
                values: new object[] { 5, 5, "Snorkel" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ItemDetailId", "Name" },
                values: new object[] { 6, 6, "Floaties" });

            migrationBuilder.InsertData(
                table: "CheckListToItems",
                columns: new[] { "ItemId", "CheckListId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "ItemDetails",
                columns: new[] { "Id", "Description", "Quantity", "Ready" },
                values: new object[,]
                {
                    { 5, "Speedo Green Snorkel", 1, false },
                    { 6, "Banana Shaped Floatie", 1, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CheckListToItems",
                keyColumns: new[] { "ItemId", "CheckListId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CheckListToItems",
                keyColumns: new[] { "ItemId", "CheckListId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CheckListToItems",
                keyColumns: new[] { "ItemId", "CheckListId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CheckListToItems",
                keyColumns: new[] { "ItemId", "CheckListId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CheckListToItems",
                keyColumns: new[] { "ItemId", "CheckListId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ItemDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CheckLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "CheckListToItems",
                columns: new[] { "ItemId", "CheckListId" },
                values: new object[] { 4, 1 });
        }
    }
}
