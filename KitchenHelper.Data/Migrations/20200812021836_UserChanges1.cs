using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class UserChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRecipe_Recipes_RecipeId",
                table: "UsersRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRecipe_User_UserId",
                table: "UsersRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRecipe",
                table: "UsersRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "UsersRecipe",
                newName: "UsersRecipes");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UsersRecipe_RecipeId",
                table: "UsersRecipes",
                newName: "IX_UsersRecipes_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRecipes",
                table: "UsersRecipes",
                columns: new[] { "UserId", "RecipeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRecipes_Recipes_RecipeId",
                table: "UsersRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRecipes_Users_UserId",
                table: "UsersRecipes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRecipes_Recipes_RecipeId",
                table: "UsersRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRecipes_Users_UserId",
                table: "UsersRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRecipes",
                table: "UsersRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UsersRecipes",
                newName: "UsersRecipe");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_UsersRecipes_RecipeId",
                table: "UsersRecipe",
                newName: "IX_UsersRecipe_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRecipe",
                table: "UsersRecipe",
                columns: new[] { "UserId", "RecipeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRecipe_Recipes_RecipeId",
                table: "UsersRecipe",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRecipe_User_UserId",
                table: "UsersRecipe",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
