using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class mockdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RecipeIngredientInformation",
                columns: new[] { "Id", "IngredientId", "MeasurementId", "Quantity", "RecipeId" },
                values: new object[] { 2, 1, 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredientInformation",
                columns: new[] { "Id", "IngredientId", "MeasurementId", "Quantity", "RecipeId" },
                values: new object[] { 3, 2, 2, 4, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredientInformation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeIngredientInformation",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
