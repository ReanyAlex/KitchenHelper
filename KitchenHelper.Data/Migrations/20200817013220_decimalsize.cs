using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class decimalsize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "RecipeIngredientInformation",
                type: "decimal(16, 4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "RecipeIngredientInformation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 4)");
        }
    }
}
