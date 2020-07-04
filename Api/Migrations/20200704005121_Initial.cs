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
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ready = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckListToItemDetails",
                columns: table => new
                {
                    CheckListId = table.Column<int>(nullable: false),
                    ItemDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListToItemDetails", x => new { x.ItemDetailId, x.CheckListId });
                    table.ForeignKey(
                        name: "FK_CheckListToItemDetails_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckListToItemDetails_ItemDetails_ItemDetailId",
                        column: x => x.ItemDetailId,
                        principalTable: "ItemDetails",
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
                table: "Items",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Extra T-shirts", "T-shirt" },
                    { 2, "Extra Pants", "Pants" },
                    { 3, "Empty Bottle", "Water Bottle" },
                    { 4, "Bring the electric one!", "Toothbrush" },
                    { 5, "Speedo Green Snorkel", "Snorkel" },
                    { 6, "Banana Shaped Floatie", "Floaties" }
                });

            migrationBuilder.InsertData(
                table: "ItemDetails",
                columns: new[] { "Id", "ItemId", "Notes", "Quantity", "Ready" },
                values: new object[,]
                {
                    { 1, 1, "Some notes", 3, false },
                    { 7, 1, "Some notes", 6, false },
                    { 2, 2, "Some notes", 1, false },
                    { 3, 3, "Some notes", 1, false },
                    { 4, 4, "Some notes", 1, false },
                    { 5, 5, "Some notes", 1, false },
                    { 6, 6, "Some notes", 1, false }
                });

            migrationBuilder.InsertData(
                table: "CheckListToItemDetails",
                columns: new[] { "ItemDetailId", "CheckListId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 7, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckListToItemDetails_CheckListId",
                table: "CheckListToItemDetails",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_ItemId",
                table: "ItemDetails",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListToItemDetails");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "ItemDetails");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
