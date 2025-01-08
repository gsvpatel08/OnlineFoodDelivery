using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineFoodDelivery.Migrations
{
    /// <inheritdoc />
    public partial class fooditemmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AvailabilityStatus = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Restaurantid = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.ItemID);

                    table.ForeignKey(
                        name: "FK_FoodItems_FoodCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FoodCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict); // Change Cascade to Restrict

                    table.ForeignKey(
                        name: "FK_FoodItems_Restaurant_Restaurantid",
                        column: x => x.Restaurantid,
                        principalTable: "Restaurant",
                        principalColumn: "RestaurantID",
                        onDelete: ReferentialAction.Restrict); // Change Cascade to Restrict
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CategoryId",
                table: "FoodItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_Restaurantid",
                table: "FoodItems",
                column: "Restaurantid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");
        }
    }
}
