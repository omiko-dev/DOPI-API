using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations.User
{
    /// <inheritdoc />
    public partial class FInnalyTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProduct_Users_UserId",
                table: "UserProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProduct",
                table: "UserProduct");

            migrationBuilder.DropIndex(
                name: "IX_UserProduct_UserId",
                table: "UserProduct");

            migrationBuilder.RenameTable(
                name: "UserProduct",
                newName: "Cart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Users_UserId",
                table: "Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "UserProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProduct",
                table: "UserProduct",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_UserId",
                table: "UserProduct",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProduct_Users_UserId",
                table: "UserProduct",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
