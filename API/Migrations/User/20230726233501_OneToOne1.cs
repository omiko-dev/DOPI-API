using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations.User
{
    /// <inheritdoc />
    public partial class OneToOne1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TokenExpires", "tokenCreate" },
                values: new object[] { new DateTime(2023, 7, 28, 3, 35, 1, 36, DateTimeKind.Local).AddTicks(548), new DateTime(2023, 7, 27, 3, 35, 1, 36, DateTimeKind.Local).AddTicks(533) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TokenExpires", "tokenCreate" },
                values: new object[] { new DateTime(2023, 7, 28, 3, 12, 41, 897, DateTimeKind.Local).AddTicks(4306), new DateTime(2023, 7, 27, 3, 12, 41, 897, DateTimeKind.Local).AddTicks(4296) });
        }
    }
}
