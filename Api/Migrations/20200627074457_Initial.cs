using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Ready = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemDetails_Id",
                        column: x => x.Id,
                        principalTable: "ItemDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckListToItems",
                columns: table => new
                {
                    CheckListId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListToItems", x => new { x.ItemId, x.CheckListId });
                    table.ForeignKey(
                        name: "FK_CheckListToItems_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckListToItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CheckLists",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This is a checklist for my full marathon!", "Full Marathon" },
                    { 2, "Trip to Jervis Bay!", "Jervis Bay Trip" }
                });

            migrationBuilder.InsertData(
                table: "ItemDetails",
                columns: new[] { "Id", "Description", "ItemId", "Quantity", "Ready" },
                values: new object[,]
                {
                    { 1, "Extra T-shirts", 0, 3, false },
                    { 2, "Extra Pants", 0, 1, false },
                    { 3, "Empty Bottle", 0, 1, false },
                    { 4, "Bring the electric one!", 0, 1, false },
                    { 5, "Speedo Green Snorkel", 0, 1, false },
                    { 6, "Banana Shaped Floatie", 0, 1, false }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T-shirt" },
                    { 2, "Pants" },
                    { 3, "Water Bottle" },
                    { 4, "Toothbrush" },
                    { 5, "Snorkel" },
                    { 6, "Floaties" }
                });

            migrationBuilder.InsertData(
                table: "CheckListToItems",
                columns: new[] { "ItemId", "CheckListId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckListToItems_CheckListId",
                table: "CheckListToItems",
                column: "CheckListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListToItems");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemDetails");
        }
    }
}
