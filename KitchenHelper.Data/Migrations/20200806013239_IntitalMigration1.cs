using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class IntitalMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredientInformation_Measurements_MeasurementId",
                table: "RecipeIngredientInformation");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredientInformation_MeasurementId",
                table: "RecipeIngredientInformation");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeIngredientInformationId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "MeasurementId",
                table: "RecipeIngredientInformation");

            migrationBuilder.AddColumn<int>(
                name: "RecipeIngredientInformationId",
                table: "Measurements",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_RecipeIngredientInformationId",
                table: "Measurements",
                column: "RecipeIngredientInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeIngredientInformationId",
                table: "Ingredients",
                column: "RecipeIngredientInformationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_RecipeIngredientInformation_RecipeIngredientInformationId",
                table: "Measurements",
                column: "RecipeIngredientInformationId",
                principalTable: "RecipeIngredientInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_RecipeIngredientInformation_RecipeIngredientInformationId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_RecipeIngredientInformationId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeIngredientInformationId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeIngredientInformationId",
                table: "Measurements");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementId",
                table: "RecipeIngredientInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientInformation_MeasurementId",
                table: "RecipeIngredientInformation",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeIngredientInformationId",
                table: "Ingredients",
                column: "RecipeIngredientInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredientInformation_Measurements_MeasurementId",
                table: "RecipeIngredientInformation",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
