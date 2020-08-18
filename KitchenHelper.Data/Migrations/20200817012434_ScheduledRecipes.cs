using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class ScheduledRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    ScheduledDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledRecipes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledRecipes_RecipeId",
                table: "ScheduledRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledRecipes_UserId",
                table: "ScheduledRecipes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledRecipes");
        }
    }
}
