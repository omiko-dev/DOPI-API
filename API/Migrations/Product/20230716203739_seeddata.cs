using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations.Product
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Product_Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 7, 17, 0, 37, 39, 163, DateTimeKind.Local).AddTicks(9589), new DateTime(2023, 7, 17, 0, 37, 39, 163, DateTimeKind.Local).AddTicks(9606) });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Product_Id",
                keyValue: 2,
                columns: new[] { "Allergens", "CreatedAt", "ImageURL", "Ingredients", "UpdatedAt" },
                values: new object[] { "[\"Milk\"]", new DateTime(2023, 7, 17, 0, 37, 39, 163, DateTimeKind.Local).AddTicks(9740), "[\"https://plus.unsplash.com/premium_photo-1677678736767-7641af9cb43c?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80\",\"https://plus.unsplash.com/premium_photo-1677678736472-3f7498116754?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=687&q=80\"]", "[\"Sugar\",\"Cocoa butter\",\"Milk powder\",\"Cocoa mass\",\"Vanilla extract\"]", new DateTime(2023, 7, 17, 0, 37, 39, 163, DateTimeKind.Local).AddTicks(9741) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Product_Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Product_Id",
                keyValue: 2,
                columns: new[] { "Allergens", "CreatedAt", "ImageURL", "Ingredients", "UpdatedAt" },
                values: new object[] { null, null, null, null, null });
        }
    }
}
