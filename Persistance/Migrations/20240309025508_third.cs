using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a5b1baa-4387-4115-84a4-3e77c7ad3eed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b780aebe-7e4c-45bf-9343-926d72c376b3");

            migrationBuilder.AddColumn<Guid>(
                name: "Identifier",
                table: "Trade",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Identifier",
                table: "Strategies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Identifier",
                table: "Image",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a5b1baa-4387-4115-84a4-3e77c7ad3eed", "dadba0cc-99cf-45ce-8dd6-44353d6b9595", "Admin", "ADMIN" },
                    { "b780aebe-7e4c-45bf-9343-926d72c376b3", "4d4f5517-9002-49d4-8190-496a28e4ac47", "Trader", "TRADER" }
                });
        }
    }
}
