using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    ShortHand = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    MeasurementId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientInformation_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientInformation_Measurements_MeasurementId",
                        column: x => x.MeasurementId,
                        principalTable: "Measurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredientInformation_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(nullable: false),
                    Step = table.Column<string>(maxLength: 2500, nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeStep_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Milk" },
                    { 2, "Cookie" }
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "Id", "Name", "ShortHand" },
                values: new object[,]
                {
                    { 1, "Cup", "C" },
                    { 2, "Each", "Each" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Category", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Test", "A nice cold glass of milk", "Cup of Milk" },
                    { 2, "Test", "A nice cold glass of milk with cookies", "Cup of Milk With Cookies" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredientInformation",
                columns: new[] { "Id", "IngredientId", "MeasurementId", "Quantity", "RecipeId" },
                values: new object[] { 1, 1, 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "RecipeStep",
                columns: new[] { "Id", "Order", "RecipeId", "Step" },
                values: new object[,]
                {
                    { 1, 1, 1, "Drink Milk" },
                    { 2, 1, 2, "Drink Milk" },
                    { 3, 2, 2, "Eat Cookie" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientInformation_IngredientId",
                table: "RecipeIngredientInformation",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientInformation_MeasurementId",
                table: "RecipeIngredientInformation",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientInformation_RecipeId",
                table: "RecipeIngredientInformation",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeStep_RecipeId",
                table: "RecipeStep",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredientInformation");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
