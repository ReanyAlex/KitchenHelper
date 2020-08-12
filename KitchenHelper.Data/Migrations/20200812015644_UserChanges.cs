using Microsoft.EntityFrameworkCore.Migrations;

namespace KitchenHelper.API.Data.Migrations
{
    public partial class UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRecipe_Users_UserId",
                table: "UsersRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRecipe",
                table: "UsersRecipe");

            migrationBuilder.DropIndex(
                name: "IX_UsersRecipe_UserId",
                table: "UsersRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersRecipe");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRecipe",
                table: "UsersRecipe",
                columns: new[] { "UserId", "RecipeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRecipe_User_UserId",
                table: "UsersRecipe",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "User",
                newName: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersRecipe",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRecipe",
                table: "UsersRecipe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRecipe_UserId",
                table: "UsersRecipe",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRecipe_Users_UserId",
                table: "UsersRecipe",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
