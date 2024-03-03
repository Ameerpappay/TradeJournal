using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92682c1e-5a05-47a4-b346-c45bb814d41b", "f9af6019-d6c2-43bc-bf3d-a17d99a4ae0c", "Trader", null },
                    { "c88c4318-f2b4-43d6-978b-71ccc21707bc", "146f2620-9a5b-4fec-a704-86535c25f712", "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92682c1e-5a05-47a4-b346-c45bb814d41b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c88c4318-f2b4-43d6-978b-71ccc21707bc");
        }
    }
}
