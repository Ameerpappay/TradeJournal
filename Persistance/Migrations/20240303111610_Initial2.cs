using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92682c1e-5a05-47a4-b346-c45bb814d41b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c88c4318-f2b4-43d6-978b-71ccc21707bc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e4929cd-f3a4-41b8-b7d7-ee4050f2d0eb", "b5eb2d26-4491-4f37-99f1-73f9f3778c71", "Trader", "TRADER" },
                    { "e75dd866-e22b-4376-9fe8-8304db44038a", "9aa43226-c0eb-472d-9e5d-b1d16a2ac432", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e4929cd-f3a4-41b8-b7d7-ee4050f2d0eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e75dd866-e22b-4376-9fe8-8304db44038a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92682c1e-5a05-47a4-b346-c45bb814d41b", "f9af6019-d6c2-43bc-bf3d-a17d99a4ae0c", "Trader", null },
                    { "c88c4318-f2b4-43d6-978b-71ccc21707bc", "146f2620-9a5b-4fec-a704-86535c25f712", "Admin", null }
                });
        }
    }
}
