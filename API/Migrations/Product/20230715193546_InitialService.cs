using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations.Product
{
    /// <inheritdoc />
    public partial class InitialService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Allergens",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergens",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "products");
        }
    }
}
