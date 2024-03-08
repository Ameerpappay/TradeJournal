using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e4929cd-f3a4-41b8-b7d7-ee4050f2d0eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e75dd866-e22b-4376-9fe8-8304db44038a");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Trade",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Trade",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Strategies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Strategies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Image",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Image",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a5b1baa-4387-4115-84a4-3e77c7ad3eed", "dadba0cc-99cf-45ce-8dd6-44353d6b9595", "Admin", "ADMIN" },
                    { "b780aebe-7e4c-45bf-9343-926d72c376b3", "4d4f5517-9002-49d4-8190-496a28e4ac47", "Trader", "TRADER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trade_CreatedById",
                table: "Trade",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_UpdatedById",
                table: "Trade",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_CreatedById",
                table: "Strategies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Strategies_UpdatedById",
                table: "Strategies",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CreatedById",
                table: "Image",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Image_UpdatedById",
                table: "Image",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UpdatedById",
                table: "Image",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedById",
                table: "Strategies",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedById",
                table: "Strategies",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trade_AspNetUsers_UpdatedById",
                table: "Trade",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_CreatedById",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UpdatedById",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_CreatedById",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Strategies_AspNetUsers_UpdatedById",
                table: "Strategies");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_CreatedById",
                table: "Trade");

            migrationBuilder.DropForeignKey(
                name: "FK_Trade_AspNetUsers_UpdatedById",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_CreatedById",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Trade_UpdatedById",
                table: "Trade");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_CreatedById",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Strategies_UpdatedById",
                table: "Strategies");

            migrationBuilder.DropIndex(
                name: "IX_Image_CreatedById",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_UpdatedById",
                table: "Image");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a5b1baa-4387-4115-84a4-3e77c7ad3eed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b780aebe-7e4c-45bf-9343-926d72c376b3");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Trade");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Strategies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e4929cd-f3a4-41b8-b7d7-ee4050f2d0eb", "b5eb2d26-4491-4f37-99f1-73f9f3778c71", "Trader", "TRADER" },
                    { "e75dd866-e22b-4376-9fe8-8304db44038a", "9aa43226-c0eb-472d-9e5d-b1d16a2ac432", "Admin", "ADMIN" }
                });
        }
    }
}
