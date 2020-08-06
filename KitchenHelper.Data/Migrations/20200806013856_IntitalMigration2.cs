using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class IntitalMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[] { 1, "Test", "A nice cold glass of milk", "Cup of Milk" });

            migrationBuilder.InsertData(
                table: "RecipeIngredientInformation",
                columns: new[] { "Id", "Quantity", "RecipeId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "RecipeStep",
                columns: new[] { "Id", "Order", "RecipeId", "Step" },
                values: new object[] { 1, 1, 1, "Drink Milk" });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeIngredientInformationId" },
                values: new object[] { 1, "Milk", 1 });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Name", "RecipeIngredientInformationId", "ShortHand" },
                values: new object[] { 1, "Cup", 1, "C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Measurements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeStep",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeIngredientInformation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
