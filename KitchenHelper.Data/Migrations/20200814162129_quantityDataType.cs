using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class quantityDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "RecipeIngredientInformation",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "RecipeIngredientInformation",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
